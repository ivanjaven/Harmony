using UnityEngine;

public class SkinShop : MonoBehaviour
{
    public SkinShopDatabase skinDatabase;
    public GameObject skinItemPrefab;
    public Transform contentPanel;

    // public Transform buyMenuPanel;
    // public Transform useMenuPanel;

    void Start()
    {
        // buyMenuPanel.gameObject.SetActive(false);
        PopulateShop();
    }

    void PopulateShop()
    {
        for (int i = 0; i < skinDatabase.SkinsCount; i++)
        {
            Skin skin = skinDatabase.GetSkin(i);
            GameObject skinItem = Instantiate(skinItemPrefab, contentPanel);
            SkinItemUI skinItemUI = skinItem.GetComponent<SkinItemUI>();

            // Set skin item UI properties
            skinItemUI.SetSkinImages(skin.ball1, skin.ball2, skin.obstacle);
            skinItemUI.SetSkinName(skin.name);
            skinItemUI.SetSkinPrice(skin.price);

            // Check if skin is purchased and set UI accordingly
            if (skin.isPurchased)
            {
                skinItemUI.SetSkinAsPurchased();
            }
            else
            {
                // Attach purchase event to button
                skinItemUI.OnItemPurchase(i, PurchaseSkin);
            }
        }
    }

    void PurchaseSkin(int skinIndex)
    {
        skinDatabase.PurchaseCharacter(skinIndex);
        // Refresh UI after purchase (optional)
        PopulateShop();
    }

    public void BuySkin(){
      // buyMenuPanel.gameObject.SetActive(false);
    }
}