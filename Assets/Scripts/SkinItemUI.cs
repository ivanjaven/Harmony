
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

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
  

  [Space(20f)]
  [SerializeField] Button itemButton;

  public void SetItemPosition (Vector2 pos){
    GetComponent<RectTransform>().anchoredPosition += pos;
  }

  public void  SetSkinImages (Sprite ball1, Sprite ball2, Sprite obstacle){
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

  public void SetSkinAsPurchased(){
    // skinPurchase.gameObject.SetActive(false);
    skinPrice.text = "Owned";
    Transform coinImageTransform = skinPurchase.transform.Find("Image");

    if (coinImageTransform != null)
    {
        // Get the Image component from the child object
        Image coinImage = coinImageTransform.GetComponent<Image>();

        if (coinImage != null)
        {
            // Disable the Image component
            coinImage.enabled = false;

            // Center the price TextMeshPro text
            Vector2 newAnchoredPosition = skinPrice.rectTransform.anchoredPosition;
            newAnchoredPosition.x = 0; // Center along X-axis
            skinPrice.rectTransform.anchoredPosition = newAnchoredPosition;
        }
    }
    skinPurchase.interactable = false;
    itemButton.interactable = true;
  }

  public void OnItemPurchase(int itemIndex, UnityAction<int> action){
    itemButton.interactable = true;
    skinPurchase.onClick.RemoveAllListeners();
    skinPurchase.onClick.AddListener(() => action.Invoke (itemIndex));
  }

  
  
  
}
