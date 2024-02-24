using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelectionManager : MonoBehaviour
{
    public static int currentLevel;
    public void OnClickBack(){
        this.gameObject.SetActive(false);
    }

    public void OnClickLevel(int levelNumber){
        currentLevel = levelNumber;
        SaveGameData.setGameMode("LevelSelect");
        SaveGameData.setActiveLevel(levelNumber);
        SceneManager.LoadScene("level" + currentLevel);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
