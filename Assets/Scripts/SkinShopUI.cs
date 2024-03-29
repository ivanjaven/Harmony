using UnityEngine;
using TMPro;

public class SkinShop : MonoBehaviour
{
    public SkinShopDatabase skinDatabase;
    public GameObject skinItemPrefab, coinItem;
    public Transform contentPanel;
    public TextMeshProUGUI coins;

    void Start()
    {
        // SaveGameData.SetCoinValue(1000); // for testing purposes
        PlayerPrefs.SetInt("Skin_" + "Ball_1" + "_Purchased", 1); // always make ball_1 purchase
        PopulateShop();
        DisplayCoins();
    }

    public void PopulateShop()
    {

        foreach (Transform child in contentPanel)
        {
            // Destroy each child object
            Destroy(child.gameObject);
        }
        for (int i = 0; i < skinDatabase.SkinsCount; i++)
        {
            Skin skin = skinDatabase.GetSkin(i);
            GameObject skinItem = Instantiate(skinItemPrefab, contentPanel);
            SkinItemUI skinItemUI = skinItem.GetComponent<SkinItemUI>();

            // Set skin item UI properties
            skinItemUI.SetSkinImages(skin.ball1, skin.ball2, skin.obstacle);
            skinItemUI.SetSkinName(skin.name);
            skinItemUI.SetSkinPrice(skin.price);
            skinItemUI.SetIndex(skin.index);

            if(i == LoadGameData.GetCurrentSkin()){
                skinItemUI.SetSelectedBackgroundSprite();
            }

            // Check if skin is purchased and set UI accordingly

            if(PlayerPrefs.GetInt("Skin_" + skin.name + "_Purchased") == 1){
                skin.isPurchased = true;
                skinItemUI.SetSkinAsPurchased();
            }   
        }
    }

    public void PurchaseSkin(int skinIndex)
    {
        skinDatabase.PurchaseCharacter(skinIndex);
    }

    public void DisplayCoins(){
        coins.text = LoadGameData.GetCoinValue().ToString();
    }

    public void UpdateCoins(int value){
        coins.text = value.ToString();
    }
   
}

