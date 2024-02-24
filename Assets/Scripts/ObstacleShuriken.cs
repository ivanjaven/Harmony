using UnityEngine;
using DG.Tweening;

public class ObstacleShuriken : MonoBehaviour
{
    [SerializeField] Vector2 startOffset = new Vector2(-5f, 0f); // Adjust the start position if needed
    [SerializeField] Vector2 endOffset = new Vector2(5f, 0f); // Adjust the end position if needed

    [SerializeField] Transform shuriken;
    [SerializeField] float throwDuration = 2f;
    [SerializeField] float returnDuration = 1f; 

    bool isTriggered = false;

      private Vector2 originalPosition;

    void Start()
    {
        // Set the start position of the shuriken
        transform.position = (Vector2)transform.position + startOffset;
    
          originalPosition = transform.position;
    }

    void Update()
    {
        if (isTriggered)
        {
          ThrowShuriken();
        }
    }

    void ThrowShuriken(){
          // Calculate the end position
            Vector2 endPosition = (Vector2)transform.position + endOffset;

            // Move the shuriken to the end position over time
            transform.DOMove(endPosition, throwDuration).SetEase(Ease.Linear);

            ReturnToOriginalPosition();
            
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            isTriggered = true;
          
        }
    }

      void ReturnToOriginalPosition()
    {
        // Wait for the specified duration before returning to the original position
        StartCoroutine(ReturnCoroutine());
    }

    System.Collections.IEnumerator ReturnCoroutine()
    {
         yield return new WaitForSeconds(returnDuration);
        
        // Move the rectangles back to their original positions
        shuriken.position = originalPosition;
        
        isTriggered = false;
    }
}