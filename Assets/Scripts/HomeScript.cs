
using DG.Tweening;
using UnityEngine;

public class HomeScript : MonoBehaviour
{
    #region Singleton class: HomeScript

    // [SerializeField] float rotationSpeed

    public GameObject LevelSelector, Settings, Shop;

	#endregion
    void Start()
    {
        LevelSelector.SetActive(false);
        Settings.SetActive(false);
        Shop.SetActive(false);


    }
 
}