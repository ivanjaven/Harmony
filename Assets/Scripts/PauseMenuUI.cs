using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI; // Reference your UI element
    [SerializeField] private GameObject sceneUI; // Reference your UI element
    
    // bool isPause = true;

    // void Update()
    // {
  
    // }

    public void Pause(){
        pauseUI.SetActive(true);
        sceneUI.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Continue(){
        pauseUI.SetActive(false);
        sceneUI.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Exit(){
         Time.timeScale = 1f;
        SceneManager.LoadScene("home");
    }
}