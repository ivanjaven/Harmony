using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SkinShopDatabase", menuName = "Shopping/Skins shop database")]
public class SkinShopDatabase : ScriptableObject
{
    public Skin[] skins;

    public int SkinsCount{
        get{
            return skins.Length;
        }
    }

    public Skin GetSkin (int index){
        return skins[index];
    }

    public string GetName(int index){
        return skins[index].name;
    }

    public void PurchaseCharacter (int index){
        skins[index].isPurchased = true;
    }
}
