using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	#region Singleton class: PlayerMovement

	public static PlayerMovement Instance;

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
		startPosition = transform.position;

		rb = GetComponent<Rigidbody2D> ();

		cam = Camera.main;

		MoveUp ();
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
            transform.DORotate(Vector3.zero, 1f);
						
            Destroy(other.gameObject);

            StartCoroutine(DelayedSceneLoad()); // start loading next scene with 1 second delay
        }
    }

    IEnumerator DelayedSceneLoad()
    {

        yield return new WaitForSeconds(1f); // delay time
 
				string gameMode = LoadGameData.getGameMode(); //check the mode of game the player chose

				 
				 // initial data if the game is newly installed
				if(LoadGameData.getCurrentLevel() <= 1){
					SaveGameData.setCurrentLevel(1);
				}
				if(LoadGameData.getActiveLevel() <= 1){
					SaveGameData.setActiveLevel(1);
				}

        int currentLevelIndex = gameMode == "Default"? LoadGameData.getCurrentLevel() : LoadGameData.getActiveLevel();

				Debug.Log(currentLevelIndex);
				
        if (currentLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
					if(gameMode == "Default" || LoadGameData.getCurrentLevel() == LoadGameData.getActiveLevel()){ // The default will also be trigger if the active level is equal to current (latest) level
						SaveGameData.setCurrentLevel(++currentLevelIndex);
						SaveGameData.setUnlockedLevel(currentLevelIndex);
            SceneManager.LoadSceneAsync(LoadGameData.getCurrentLevel());
					}
					else if(gameMode == "LevelSelect"){
						SaveGameData.setActiveLevel(++currentLevelIndex);
            SceneManager.LoadSceneAsync(LoadGameData.getActiveLevel());
					}
        }	
    }
}
