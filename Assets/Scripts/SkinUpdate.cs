using UnityEngine;

public class SkinUpdate : MonoBehaviour
{
    public GameObject playerPrefab; // Reference to the Player prefab

    // ChangeSkin method to update the sprites of Ball_1 and Ball_2
    public void ChangeSkin(Sprite ball1Sprite, Sprite ball2Sprite)
    {
        if (playerPrefab != null)
        {
            // Instantiate the Player prefab
            GameObject player = Instantiate(playerPrefab);

            // Find the child objects Ball_1 and Ball_2
            Transform ball1Transform = player.transform.Find("Ball_1");
            Transform ball2Transform = player.transform.Find("Ball_2");

            // Check if Ball_1 and Ball_2 are found
            if (ball1Transform != null && ball2Transform != null)
            {
                // Get the SpriteRenderer components of Ball_1 and Ball_2
                SpriteRenderer ball1Renderer = ball1Transform.GetComponent<SpriteRenderer>();
                SpriteRenderer ball2Renderer = ball2Transform.GetComponent<SpriteRenderer>();

                Debug.Log(ball1Renderer);

                // Change the sprites
                if (ball1Renderer != null && ball2Renderer != null)
                {
                    ball1Renderer.sprite = ball1Sprite;
                    ball2Renderer.sprite = ball2Sprite;
                    Debug.Log(ball1Sprite);
                    // playerPrefab = player;
                }
                else
                {
                    Debug.LogError("SpriteRenderer component not found on Ball_1 or Ball_2.");
                }
            }
            else
            {
                Debug.LogError("Ball_1 or Ball_2 not found in the Player prefab.");
            }
        }
        else
        {
            Debug.LogError("Player prefab is not assigned.");
        }
    }
}