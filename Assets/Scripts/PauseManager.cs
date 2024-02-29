using UnityEngine;
using UnityEngine.Events;

public class PauseManager : MonoBehaviour
{
    [SerializeField] public UnityEvent onPause;
    [SerializeField] public UnityEvent onResume;

    private bool isPaused; // Track pause state

    void Update()
    {
        // Check for "Escape" key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused; // Toggle pause state

        if (isPaused)
        {
            Time.timeScale = 0f;
            onPause.Invoke(); // Invoke the onPause event
        }
        else
        {
            Time.timeScale = 1f;
            onResume.Invoke(); // Invoke the onResume event
        }
    }
}