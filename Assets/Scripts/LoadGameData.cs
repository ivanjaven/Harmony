using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameData : MonoBehaviour
{
    // Start is called before the first frame update
    public static int getCurrentLevel(){
        return PlayerPrefs.GetInt("currentLevel");
    }
    public static int getActiveLevel(){
        return PlayerPrefs.GetInt("activeLevel");
    }
    public static string getGameMode(){
        return PlayerPrefs.GetString("mode");
    }
    public static int getUnlockedLevel(){
        return PlayerPrefs.GetInt("UnlockedLevel");
    }
}
