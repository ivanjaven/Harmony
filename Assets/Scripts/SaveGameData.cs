using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameData : MonoBehaviour
{
    // Start is called before the first frame update
    public static void SetCurrentLevel(int level){
        PlayerPrefs.SetInt("currentLevel", level);
    }

    public static void SetActiveLevel(int level){
        PlayerPrefs.SetInt("activeLevel", level);
    }

    public static void SetGameMode(String mode){
        PlayerPrefs.SetString("mode", mode);
    }
    public static void SetUnlockedLevel(int level){
        PlayerPrefs.SetInt("UnlockedLevel", level);
    }
    public static void SetCurrentSkin(int index){
        PlayerPrefs.SetInt("currentSkin", index);
    }
    public static void SetCoinValue(int index){
        PlayerPrefs.SetInt("coins", index);
    }
}
