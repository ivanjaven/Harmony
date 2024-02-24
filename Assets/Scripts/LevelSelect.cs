using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
     public GameObject OptionsMenu, LevelSelector;
    
    public void OnClickLevels(){
        LevelSelector.SetActive(true);
    }

    public void OnClickQuit(){
        Application.Quit();
    }
}
