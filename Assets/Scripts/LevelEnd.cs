using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{

    public void UnLockNewLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex >= LoadGameData.getCurrentLevel()){
            SaveGameData.setCurrentLevel(SceneManager.GetActiveScene().buildIndex + 1);
            SaveGameData.setUnlockedLevel(LoadGameData.getUnlockedLevel() + 1);
            PlayerPrefs.Save();
        }
    }
}
