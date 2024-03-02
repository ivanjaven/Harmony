
using UnityEngine;
using UnityEngine.SceneManagement;


public class DefaultPlayLevel : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenScene(){ // When pressing play at home screen, the scene loaded was the latest level
        SaveGameData.setGameMode("Default");
        int level = LoadGameData.getCurrentLevel();
        // SaveGameData.setCurrentLevel(1);
        // SaveGameData.setUnlockedLevel(1);
        if(level == 0) {
            SceneManager.LoadScene("level" + level+1);
        }
        else {
            SceneManager.LoadScene("level" + level);
        }
    }
}
