using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionManager : MonoBehaviour
{
    public static int currentLevel;
    public Button[] buttons;

    private void Awake()
    {
        int unlockedLevel;
        if(PlayerPrefs.HasKey("UnlockedLevel")){
            unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel");
        }
        else{
            PlayerPrefs.SetInt("UnlockedLevel", 1);
            unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel");
        }
    
        for(int i = 0; i < buttons.Length; i++){
            buttons[i].interactable = false;
        }
        for(int i = 0; i < unlockedLevel; i++){
            buttons[i].interactable = true;
        }
    }

    public void OnClickBack(){
        this.gameObject.SetActive(false);
    }

    public void OnClickLevel(int levelNumber){
        currentLevel = levelNumber;
        SaveGameData.setGameMode("LevelSelect");
        SaveGameData.setActiveLevel(levelNumber);
        SceneManager.LoadScene("level" + currentLevel);
    }
}
