// using Unity.VisualScripting;
// using UnityEditor;
// using UnityEngine;
// using Cinemachine;

// public class SkinManager : MonoBehaviour
// {

//     public void Start(){
//         ChangeSkin();
//     }
//     public PlayerObstacleSkinDatabase skinDatabase;
//     public CinemachineVirtualCamera virtualCamera;

//     // Change the skin of the player object with the "Player" tag
//     public void ChangeSkin()
//     {
//         GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
//         int index = LoadGameData.getCurrentSkin();
//         if (playerObject != null)
//         {
//             PlayerObstacleSkin selectedSkin = skinDatabase.GetSkin(index);
//             if (selectedSkin != null) // Check if the selected skin exists
//             {
//                 Debug.Log(selectedSkin);
//                 // Instantiate the selected player prefab and destroy the old one
//                 GameObject newPlayerPrefab = Instantiate(selectedSkin.playerPrefab, playerObject.transform.position, playerObject.transform.rotation);
//                 Destroy(playerObject);

//                 // Optionally, you may want to copy other components or data from the old player object to the new one

//                 // Optionally, set the new player prefab's tag to "Player" if needed
//                 newPlayerPrefab.tag = "Player";
  
//                 virtualCamera.Follow = newPlayerPrefab.transform;
//             }
//             else
//             {
//                 Debug.LogError("Skin with index " + index + " not found in the database.");
//             }
//         }
//         else
//         {
//             Debug.LogWarning("No player object found with the tag 'Player'. Make sure your player object has the correct tag.");
//         }
//     }
    
// }

using UnityEngine;
using Cinemachine;

public class SkinManager : MonoBehaviour
{
    public PlayerObstacleSkinDatabase skinDatabase;
    public CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        ChangeSkin();
    }

    // Change the skin of the player object with the "Player" tag
    public void ChangeSkin()
    {
        int index = LoadGameData.getCurrentSkin();
        PlayerObstacleSkin selectedSkin = skinDatabase.GetSkin(index);
        if (selectedSkin != null) // Check if the selected skin exists
        {
            // Instantiate the selected player prefab
            GameObject newPlayerPrefab = Instantiate(selectedSkin.playerPrefab, Vector3.zero, Quaternion.identity);

            // Optionally, set the tag of the new player prefab to "Player"
            newPlayerPrefab.tag = "Player";

            // Update the Cinemachine Virtual Camera's follow target to track the new player prefab
            if (virtualCamera != null)
            {
                virtualCamera.Follow = newPlayerPrefab.transform;
            }
            else
            {
                Debug.LogWarning("Cinemachine Virtual Camera reference is not set in the SkinManager.");
            }
        }
        else
        {
            Debug.LogError("Skin with index " + index + " not found in the database.");
        }
    }
}