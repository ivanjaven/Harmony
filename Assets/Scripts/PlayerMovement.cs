using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
	#region Singleton class: PlayerMovement

	public static PlayerMovement Instance;
	public GameObject mainUI;

	void Awake ()
	{
		if (Instance == null)
			Instance = this;
		
	}

	#endregion

	[SerializeField] CircleCollider2D redBallCollider;
	[SerializeField] CircleCollider2D blueBallCollider;

	[SerializeField] CircleCollider2D playerCollider;

	[SerializeField] float speed;
	[SerializeField] float rotationSpeed;

	Rigidbody2D rb;
	Vector3 startPosition;
	Camera cam;
	float touchPosX = 0f;

	

	void Start ()
	{
		string mode = LoadGameData.GetGameMode();
		int level = mode == "Default"? LoadGameData.GetCurrentLevel() : LoadGameData.GetActiveLevel();
		
		speed = (float) (3 + (level * 0.1));
		rotationSpeed = (float) (170 + (level * 4));

		startPosition = transform.position;

		rb = GetComponent<Rigidbody2D> ();

		cam = Camera.main;

		MoveUp ();

		mainUI = GameObject.Find("MainUI");
	}

	void Update ()
	{
		if (!GameManager.Instance.isGameover) {
			//mobile inputs (touch on screen sides)
			if (Input.GetMouseButtonDown (0))
				touchPosX = cam.ScreenToWorldPoint (Input.mousePosition).x;

			if (Input.GetMouseButton (0)) {
				if (touchPosX > 0.01f)
					RotateRight ();
				else
					RotateLeft ();
			} else
				rb.angularVelocity = 0f;


			//Unity editor inputs < & > keys
			#if UNITY_EDITOR
			if (Input.GetKey (KeyCode.LeftArrow))
				RotateLeft ();
			else if (Input.GetKey (KeyCode.RightArrow))
				RotateRight ();

			//stop rotation when key is released
			if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow))
				rb.angularVelocity = 0f;
			#endif

		}
	}

	void MoveUp ()
	{
		rb.velocity = Vector2.up * speed;
	}

	void RotateLeft ()
	{
		rb.angularVelocity = rotationSpeed;
	}

	void RotateRight ()
	{
		rb.angularVelocity = -rotationSpeed;
	}

	public void Restart ()
	{
		playerCollider.enabled = false;
		redBallCollider.enabled = false;
		blueBallCollider.enabled = false;
		rb.angularVelocity = 0f;
		rb.velocity = Vector2.zero;

		//back to start position
		transform
			.DORotate (Vector3.zero, 1f)
			.SetDelay (1f)
			.SetEase (Ease.InOutBack);

		transform
			.DOMove (startPosition, 1f)
			.SetDelay (1f)
			.SetEase (Ease.OutFlash)

			.OnComplete (() => {
				playerCollider.enabled = true;
				redBallCollider.enabled = true;
				blueBallCollider.enabled = true;

			GameManager.Instance.isGameover = false;

			MoveUp ();
		});
	}

	 void OnTriggerEnter2D(Collider2D other) // when the player reach the (white) levelend mark
    {
        if (other.CompareTag("LevelEnd"))
        {
						int level;

						
						if(LoadGameData.GetGameMode() == "Default")	{
							level = LoadGameData.GetCurrentLevel();
						}
						else {
							level = LoadGameData.GetActiveLevel();
						}

						if(level > 1){
							
							if(level >= LoadGameData.GetCurrentLevel()) // if the game is not yet finished
								SaveGameData.SetCoinValue(LoadGameData.GetCoinValue() + level * 15); // add coins per level end 

							else
								SaveGameData.SetCoinValue(LoadGameData.GetCoinValue() + level * 2); // add coins per level end 

							Transform coinAdd = mainUI.transform.Find("CoinAdd");

							TransitionAddCoin(coinAdd); // transition the adding of coin in the UI 
						}

            transform.DORotate(Vector3.zero, 1f); // reset the placement of player
						
            Destroy(other.gameObject);

            StartCoroutine(DelayedSceneLoad()); // start loading next scene with 1 second delay
        }
    }

    IEnumerator DelayedSceneLoad()
    {

        yield return new WaitForSeconds(1f); // delay time
 
				string gameMode = LoadGameData.GetGameMode(); //check the mode of game the player chose
				 
				 // initial data if the game is newly installed
				if(LoadGameData.GetCurrentLevel() <= 1){
					SaveGameData.SetCurrentLevel(1);
				}
				if(LoadGameData.GetActiveLevel() <= 1){
					SaveGameData.SetActiveLevel(1);
				}

        int currentLevelIndex = gameMode == "Default"? LoadGameData.GetCurrentLevel() : LoadGameData.GetActiveLevel();
				
        if (currentLevelIndex < SceneManager.sceneCountInBuildSettings - 3)
        {
					if(gameMode == "Default" || LoadGameData.GetCurrentLevel() == LoadGameData.GetActiveLevel()){ // The default will also be trigger if the active level is equal to current (latest) level
						SaveGameData.SetCurrentLevel(currentLevelIndex + 1);
						SaveGameData.SetUnlockedLevel(currentLevelIndex + 1);
						if(gameMode != "LevelSelect")
            	SceneManager.LoadSceneAsync(LoadGameData.GetCurrentLevel());
					}
					if(gameMode == "LevelSelect"){
						SaveGameData.SetActiveLevel(currentLevelIndex + 1);
						if(currentLevelIndex > LoadGameData.GetUnlockedLevel())
							SaveGameData.SetUnlockedLevel(currentLevelIndex + 1);
            SceneManager.LoadSceneAsync(LoadGameData.GetActiveLevel());
					}
        }	

				else {
					Debug.Log("You win the game");
					yield return new WaitForSeconds(2f);
					SceneManager.LoadScene("WinningScene");
				}
    }

		void TransitionAddCoin(Transform coinAdd){
			coinAdd.gameObject.SetActive(true);
						 coinAdd.DOMoveY(coinAdd.position.y + 60f, 1f)
                    .SetEase(Ease.OutQuad)
                    .OnComplete(() =>
                    {
                        // Fade out the TextMeshProUGUI component attached to the "CoinAdd" GameObject
                        TextMeshProUGUI coinAddText = coinAdd.GetComponent<TextMeshProUGUI>();
                        if (coinAddText != null)
                        {
                            coinAddText.DOFade(0f, 1f).OnComplete(() =>
                            {
                                coinAdd.gameObject.SetActive(false);
                            });
                        }
                        else
                        {
                            Debug.LogWarning("TextMeshProUGUI component not found on 'CoinAdd' GameObject.");
                        }
                    });

		}
}
