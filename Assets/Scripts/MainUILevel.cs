using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainUILevel : MonoBehaviour
{
    public TextMeshProUGUI coins;
    public TextMeshProUGUI level;
    public TextMeshProUGUI coinAdd;

    void Start()
    {
        string mode = LoadGameData.GetGameMode();
        int levelMode = mode == "Default"? LoadGameData.GetCurrentLevel() : LoadGameData.GetActiveLevel(); // get the right level
        int reward;

        coinAdd.gameObject.SetActive(false); // inactive the + coin first

        if(levelMode == 0) levelMode = 1; // No inital level

        if(levelMode >= LoadGameData.GetCurrentLevel()) reward = levelMode * 15;
        else reward = levelMode * 2;

        coinAdd.text = "+" + reward.ToString(); // set the coinAdd text 
        coins.text = LoadGameData.GetCoinValue().ToString(); // display the current coin value
        level.text = "Level " + levelMode.ToString(); 
    }
}
