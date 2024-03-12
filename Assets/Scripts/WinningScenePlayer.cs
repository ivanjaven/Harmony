using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningScenePlayer : MonoBehaviour
{
    private Sprite newSprite;
    public PlayerObstacleSkinDatabase skinDatabase;
    
    // Start is called before the first frame update
    void Start()
    {
        newSprite = skinDatabase.GetObstacle(LoadGameData.GetCurrentSkin());
        ChangeSkin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      public void ChangeSkin()
    {
        int index = LoadGameData.GetCurrentSkin();
        PlayerObstacleSkin selectedSkin = skinDatabase.GetSkin(index);
        if (selectedSkin != null) // Check if the selected skin exists
        {
            // Instantiate the selected player prefab
            GameObject newPlayerPrefab = Instantiate(selectedSkin.playerPrefab, Vector3.zero, Quaternion.identity);
            newPlayerPrefab.transform.position -= Vector3.up * 3f;

            // Optionally, set the tag of the new player prefab to "Player"
            newPlayerPrefab.tag = "Player";

             MonoBehaviour[] scripts = newPlayerPrefab.GetComponents<MonoBehaviour>();

            // Iterate through each script and destroy it
            foreach (MonoBehaviour script in scripts)
            {
                if (script != this) // Make sure not to destroy the script of the WinningScenePlayer itself
                {
                    Destroy(script);
                }
            }

            HomeUnliRotate homeUnliRotateScript = newPlayerPrefab.AddComponent<HomeUnliRotate>();
            homeUnliRotateScript.rotationSpeed = 150;

            WinningScene winningSceneScript = newPlayerPrefab.AddComponent<WinningScene>();
            GameObject winningUI = GameObject.Find("WinningUI");
            winningSceneScript.mainUI = winningUI;
            
        }
        else
        {
            Debug.LogError("Skin with index " + index + " not found in the database.");
        }
    }
}
