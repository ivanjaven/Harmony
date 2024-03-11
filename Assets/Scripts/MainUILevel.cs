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

        coinAdd.gameObject.SetActive(false); // inactive the + coin first
        coinAdd.text = "+" + (levelMode * 15).ToString(); // set the coinAdd text 
        coins.text = LoadGameData.GetCoinValue().ToString(); // display the current coin value
        level.text = "Level " + levelMode.ToString(); 
    }
}
