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
        MarkSkinAsPurchased(index);
    }

      private void SaveSkinData(Skin skin)
    {
            PlayerPrefs.SetInt("Skin_" + skin.name + "_Purchased", skin.isPurchased ? 1 : 0);

    }

     public void MarkSkinAsPurchased(int skinIndex)
    {
        Skin skin = GetSkin(skinIndex);
        if (skin.name != null)
        {
            SaveSkinData(skin);
        }
    }
}
