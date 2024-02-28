using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameData : MonoBehaviour
{
    // Start is called before the first frame update
    public static int getCurrentLevel(){ // get the data of current level (latest level)
        return PlayerPrefs.GetInt("currentLevel");
    }
    public static int getActiveLevel(){ // get the data of active level (when the use select level from the level section)
        return PlayerPrefs.GetInt("activeLevel");
    }
    public static string getGameMode(){ // get the game mode if default (latest) or level select
        return PlayerPrefs.GetString("mode");
    }
    public static int getUnlockedLevel(){ // get the number of unclocked or finished levels
        return PlayerPrefs.GetInt("UnlockedLevel");
    }
}
