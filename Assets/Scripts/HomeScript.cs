
using DG.Tweening;
using UnityEngine;

public class HomeScript : MonoBehaviour
{
    #region Singleton class: HomeScript

    [SerializeField] float rotationSpeed;
    Rigidbody2D rb;

    public GameObject LevelSelector, Settings, Shop;

	#endregion
    void Start()
    {
        LevelSelector.SetActive(false);
        Settings.SetActive(false);
        Shop.SetActive(false);
		rb = GetComponent<Rigidbody2D> ();

        RotateRight();
    }
    	void RotateRight ()
	{
		rb.angularVelocity = -rotationSpeed;
	}
}