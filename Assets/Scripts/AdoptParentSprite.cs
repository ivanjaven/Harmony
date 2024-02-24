using UnityEngine;

public class AdoptParentSprite : MonoBehaviour
{
    void Start()
    {
        // Get the SpriteRenderer component of the parent
        SpriteRenderer parentSpriteRenderer = GetComponent<SpriteRenderer>();

        if (parentSpriteRenderer != null)
        {
            // Get the children of the parent GameObject
            Transform[] children = GetComponentsInChildren<Transform>();

            // Iterate through each child
            foreach (Transform child in children)
            {
                // Skip the parent itself
                if (child == transform)
                    continue;

                // Get the SpriteRenderer component of the child
                SpriteRenderer childSpriteRenderer = child.GetComponent<SpriteRenderer>();

                // If the child has a SpriteRenderer component, assign the sprite of the parent to it
                if (childSpriteRenderer != null)
                {
                    childSpriteRenderer.sprite = parentSpriteRenderer.sprite;
                }
            }
        }
        else
        {
            Debug.LogWarning("Parent GameObject does not have a SpriteRenderer component.");
        }
    }
}