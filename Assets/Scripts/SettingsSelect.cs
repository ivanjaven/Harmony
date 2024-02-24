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

    public void OnClickBack(){
        Shop.SetActive(false);
        SettingsSelector.SetActive(true);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickQuit(){
        Application.Quit();
    }
}
