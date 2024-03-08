using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameData : MonoBehaviour
{
    // Start is called before the first frame update
    public static void setCurrentLevel(int level){
        PlayerPrefs.SetInt("currentLevel", level);
    }

    public static void setActiveLevel(int level){
        PlayerPrefs.SetInt("activeLevel", level);
    }

    public static void setGameMode(String mode){
        PlayerPrefs.SetString("mode", mode);
    }
    public static void setUnlockedLevel(int level){
        PlayerPrefs.SetInt("UnlockedLevel", level);
    }
    public static void setCurrentSkin(int index){
        PlayerPrefs.SetInt("currentSkin", index);
    }
}
