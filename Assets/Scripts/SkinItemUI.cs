
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class SkinItemUI : MonoBehaviour
{

  [Space(20f)]
  [SerializeField] Image ball1;
  [SerializeField] Image ball2;
  [SerializeField] Image obstacle;
  [SerializeField] Image obstacle2;

  [SerializeField] TMP_Text skinName;
  [SerializeField] TMP_Text skinPrice;
  [SerializeField] Button skinPurchase;
  [SerializeField] SkinShop skinShop;

  [SerializeField] Image itemBackgroundImage;
  [SerializeField] int index;

  SkinItemUI skinItemUI;
  // public float shakeDuration = 3f; // Duration of the shake effect
  // public float shakeStrength = 50.0f; // Strength of the shake effect

  [Space(20f)]
  [SerializeField] Button itemButton;


  public void Start()
  {
    skinItemUI = this;
    skinShop = GetComponentInParent<SkinShop>(); // Find the SkinShop component in the parent hierarchy
    itemButton.onClick.AddListener(OnItemButtonClick); 
  }

  public void SetItemPosition (Vector2 pos)
  {
    GetComponent<RectTransform>().anchoredPosition += pos; // displaying in the content panel
  }

  public void SetSkinImages (Sprite ball1, Sprite ball2, Sprite obstacle)
  {
    this.ball1.sprite = ball1;
    this.ball2.sprite = ball2;
    this.obstacle.sprite = obstacle;
    this.obstacle2.sprite = obstacle;
  }

  public void SetSkinName(string name){
    skinName.text = name;
  }

  public void SetSkinPrice(int price){
    skinPrice.text = price.ToString();
  }

  public void SetIndex(int index){
    this.index = index;
  }

  public void SetSkinAsPurchased() // if the skin is already purchased, this UI will be applied
  { 
    skinPrice.text = "Owned";
    Transform coinImageTransform = skinPurchase.transform.Find("Image");

    if (coinImageTransform != null)
    {
        // Get the coint image component from the child object
        Image coinImage = coinImageTransform.GetComponent<Image>();

        if (coinImage != null)
        {
            // Disable the coin image component
            coinImage.enabled = false;

            // Center the price TextMeshPro text
            Vector2 newAnchoredPosition = skinPrice.rectTransform.anchoredPosition;
            newAnchoredPosition.x = 0; // Center along X-axis
            skinPrice.rectTransform.anchoredPosition = newAnchoredPosition;
        }
    }
    itemButton.interactable = false;
  }

  public void OnItemPurchase() // Triggered when the item is Purchased
  {
    skinShop.PurchaseSkin(index);
    skinShop.PopulateShop(); // refresh the shop display
  }

 public void OnClickPurchasedSkin(){
        if(skinPrice.text == "Owned"){
          SaveGameData.SetCurrentSkin(index);
          skinShop.PopulateShop();
        }
        else{
          Debug.Log("Buy item first");
        }
    }

    public void SetSelectedBackgroundSprite()
    {
        Sprite newBackgroundSprite = Resources.Load<Sprite>("SelectedBackground");
        if (itemBackgroundImage != null)
        {
            itemBackgroundImage.sprite = newBackgroundSprite;
        }
        else
        {
            Debug.LogWarning("Item background Image component is not assigned.");
        }
    }

    void OnItemButtonClick()
    {
      int price = int.Parse(skinPrice.text);
      if(LoadGameData.GetCoinValue() >= price){
        OnItemPurchase();
        SaveGameData.SetCoinValue(LoadGameData.GetCoinValue() - price);
        skinShop.UpdateCoins(LoadGameData.GetCoinValue());
      }
        
      else{
        Debug.Log("Not enough money");
        this.transform.DOShakePosition(2, 10); 
        skinShop.coinItem.transform.DOShakePosition(2,10);
      }
    }
}
