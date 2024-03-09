using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionManager : MonoBehaviour
{
    public Button[] buttons;

    private void Awake()
    {
        int unlockedLevel;
        if(PlayerPrefs.HasKey("UnlockedLevel")){ //Check if the unlockedlevel exists in playerprefs
            unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel"); 
        }
        else{  // set it if it didn't exists
            PlayerPrefs.SetInt("UnlockedLevel", 1);
            unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel");
        }
    
        for(int i = 0; i < buttons.Length; i++){ // itterate through all the level buttons and assign it as not interactable
            buttons[i].interactable = false;
        }
        for(int i = 0; i < unlockedLevel; i++){ // itterate through the count of unlocked levels to make all of it interactable
            buttons[i].interactable = true;
        }
    }

    public void OnClickBack(){
        this.gameObject.SetActive(false);
    }

    public void OnClickLevel(int levelNumber){ //load the level number passed by the button and save it as active level
        SaveGameData.SetGameMode("LevelSelect");
        SaveGameData.SetActiveLevel(levelNumber);
        SceneManager.LoadScene("level" + levelNumber);
    }

    public void OnClickEndless(){
        SceneManager.LoadScene("Endless");
    }
}
