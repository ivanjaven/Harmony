
using UnityEngine;
using Cinemachine;

public class SkinManager : MonoBehaviour
{
    public PlayerObstacleSkinDatabase skinDatabase;
    public CinemachineVirtualCamera virtualCamera;
    private Sprite newSprite;

    void Start()
    {
        Debug.Log(skinDatabase.GetObstacle(LoadGameData.getCurrentSkin()));
        newSprite = skinDatabase.GetObstacle(LoadGameData.getCurrentSkin());
        ChangeSkin();
        ChangeObstacleSprites();
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

    public void ChangeObstacleSprites()
    {
        // Find the parent GameObject named "Obstacles"
        GameObject obstacleParent = GameObject.Find("Obstacles");

        // Check if the parent GameObject was found
        if (obstacleParent != null)
        {
            // Loop through all children of the "Obstacles" GameObject
            foreach (Transform obstacleTransform in obstacleParent.transform)
            {
                // Get the GameObject of the obstacle prefab
                GameObject obstaclePrefab = obstacleTransform.gameObject;

                // Get the SpriteRenderer component of the obstacle prefab
                SpriteRenderer spriteRenderer = obstaclePrefab.GetComponent<SpriteRenderer>();

                // Check if SpriteRenderer component exists
                if (spriteRenderer != null)
                {
                    // Get the name of the obstacle prefab
                    string obstacleName = obstaclePrefab.name.ToLower(); // Convert to lower case for case-insensitive comparison

                    // Check if the name contains "closing" or "block"
                    if(obstacleName.Contains("shuriken") || obstacleName.Contains("axe")) continue; // skin the shuriken and axe

                    if (obstacleName.Contains("closing") || obstacleName.Contains("block"))
                    {
                        // Change the sprite of the obstacle prefab's children
                        foreach (Transform childTransform in obstacleTransform)
                        {
                            SpriteRenderer childSpriteRenderer = childTransform.GetComponent<SpriteRenderer>();
                            if(childSpriteRenderer.name.Contains("identifier")) continue; // skin the closing identifier
                            
                            if (childSpriteRenderer != null)
                            {
                                // Change the sprite of the child obstacle prefab
                                childSpriteRenderer.sprite = newSprite;
                            }
                            else
                            {
                                Debug.LogWarning("SpriteRenderer component not found in child obstacle prefab: " + childTransform.name);
                            }
                        }
                    }
                    else
                    {
                        // Change the sprite of the obstacle prefab
                        spriteRenderer.sprite = newSprite;
                    }
                }
                else
                {
                    Debug.LogWarning("SpriteRenderer component not found in obstacle prefab: " + obstaclePrefab.name);
                }
            }
        }
        else
        {
            Debug.LogWarning("Parent GameObject named 'Obstacles' not found.");
        }
    }
}