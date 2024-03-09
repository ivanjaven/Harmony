
using UnityEngine;
using UnityEngine.SceneManagement;


public class DefaultPlayLevel : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenScene(){ // When pressing play at home screen, the scene loaded was the latest level
        SaveGameData.SetGameMode("Default");
        // SaveGameData.setActiveLevel(1);
        // SaveGameData.setCurrentLevel(1);
        // SaveGameData.setUnlockedLevel(1);
        if(LoadGameData.GetCurrentLevel() <= 1)
            SceneManager.LoadScene("level1");
           
        else SceneManager.LoadScene("level"+LoadGameData.GetCurrentLevel());
 
    }
}
