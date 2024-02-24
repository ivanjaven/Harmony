
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.SceneManagement;

public class DefaultPlayLevel : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenScene(){
        SaveGameData.setGameMode("Default");
        SaveGameData.setCurrentLevel(1);
        SceneManager.LoadScene("level" + LoadGameData.getCurrentLevel());
    }
}
