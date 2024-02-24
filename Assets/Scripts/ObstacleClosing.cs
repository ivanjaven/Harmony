using UnityEngine;
using System.Collections;

public class RectangleClosing : MonoBehaviour
{
    [SerializeField] Transform rectangle1;
    [SerializeField] Transform rectangle2;
    [SerializeField] float closingSpeed = 1f;
    [SerializeField] float reopenDelay = 1f; // Delay in seconds before reopening

    bool isClosing = false;
    Vector3 originalPosition1;
    Vector3 originalPosition2;

    void Start()
    {
        // Store the original positions of the rectangles
        originalPosition1 = rectangle1.position;
        originalPosition2 = rectangle2.position;
    }

    void Update()
    {
        if (isClosing)
        {
            CloseRectangles();
        }
    }

    void CloseRectangles()
    {
        // Calculate the midpoint between the two rectangles
        Vector3 midpoint = (originalPosition1 + originalPosition2) / 2f;
        
        // Move the rectangles towards the midpoint to close the gap
        rectangle1.position = Vector3.MoveTowards(rectangle1.position, midpoint, closingSpeed * Time.deltaTime);
        rectangle2.position = Vector3.MoveTowards(rectangle2.position, midpoint, closingSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            isClosing = true;
            StartCoroutine(ReopenRectanglesAfterDelay());
        }
    }

    IEnumerator ReopenRectanglesAfterDelay()
    {
        yield return new WaitForSeconds(reopenDelay);
        
        // Move the rectangles back to their original positions
        rectangle1.position = originalPosition1;
        rectangle2.position = originalPosition2;
        
        // Reset the closing flag
        isClosing = false;
    }
}