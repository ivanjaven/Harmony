
using UnityEngine;

public class HomeScript : MonoBehaviour
{
    #region Singleton class: HomeScript

    // [SerializeField] float rotationSpeed

    public GameObject LevelSelector, Settings, Shop, newPlayerPrefab;
    public PlayerObstacleSkinDatabase skinShopDatabase;

	#endregion
    void Start()
    {
        LevelSelector.SetActive(false);
        Settings.SetActive(false);
        Shop.SetActive(false);
        newPlayerPrefab = skinShopDatabase.GetSkin(LoadGameData.GetCurrentSkin()).playerPrefab;
        SetPlayer();
    }

    void SetPlayer()
    {
        // Find the existing player GameObject
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            // Instantiate the new player prefab at the position and rotation of the existing player
            GameObject newPlayer = Instantiate(newPlayerPrefab, playerObject.transform.position, playerObject.transform.rotation);

            // Copy the Transform properties (position, rotation, scale) from the existing player to the new player
            newPlayer.transform.SetParent(playerObject.transform.parent); // Maintain the same parent as the existing player
            newPlayer.transform.localScale = playerObject.transform.localScale;

            // Remove the embedded script (e.g., PlayerMovement) from the new player
            Destroy(newPlayer.GetComponent<PlayerMovement>());

            HomeUnliRotate unliRotateScript = newPlayer.AddComponent<HomeUnliRotate>();

            // Call the SetRotationSpeed function of the HomeUnliRotate script and pass 150 to it
            unliRotateScript.SetRotationSpeed(150);

            // Destroy the existing player
            Destroy(playerObject);
        }
        else
        {
            Debug.LogError("Player object not found. Make sure your player object has the correct tag.");
        }
    }
 
}