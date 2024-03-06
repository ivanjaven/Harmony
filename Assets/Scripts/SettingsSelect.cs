using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsSelect : MonoBehaviour
{
     public GameObject SettingsSelector, Shop;
    
    public void OnClickSettings(){
        SettingsSelector.SetActive(true);
    }
    public void OnClickShop(){
        SettingsSelector.SetActive(false);
        Shop.SetActive(true);
    }

    public void OnClickBackToSettings(){
        Shop.SetActive(false);
        SettingsSelector.SetActive(true);
    }
    
    public void OnClickBackToHome(){
        SettingsSelector.SetActive(false);
    }

    public void OnClickQuit(){
        Application.Quit();
    }
}
