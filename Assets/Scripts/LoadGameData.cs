using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameData : MonoBehaviour
{
    public static int GetCurrentLevel(){ // get the data of current level (latest level)
        return PlayerPrefs.GetInt("currentLevel");
    }
    public static int GetActiveLevel(){ // get the data of active level (when the use select level from the level section)
        return PlayerPrefs.GetInt("activeLevel");
    }
    public static string GetGameMode(){ // get the game mode if default (latest) or level select
        return PlayerPrefs.GetString("mode");
    }
    public static int GetUnlockedLevel(){ // get the number of unclocked or finished levels
        return PlayerPrefs.GetInt("UnlockedLevel");
    }
    public static int GetCurrentSkin(){ // get the number of unclocked or finished levels
        return PlayerPrefs.GetInt("currentSkin");
    }
    public static int GetCoinValue(){ // get the number of unclocked or finished levels
        return PlayerPrefs.GetInt("coins");
    }
}
