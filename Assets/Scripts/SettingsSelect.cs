using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("Home");
    }

    public void OnClickQuit(){
        Application.Quit();
    }
}
