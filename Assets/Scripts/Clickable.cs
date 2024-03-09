using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clickable : MonoBehaviour // This class is use to fix the buttons default clicking treshold behavior
{
    public float alphaTreshold = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = alphaTreshold;
        SaveGameData.SetGameMode("LevelSelect"); // set the game to LevelSelect each time level button was clicked
    }
}
