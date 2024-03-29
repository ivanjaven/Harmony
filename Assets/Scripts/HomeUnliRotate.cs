
using DG.Tweening;
using UnityEngine;

public class HomeUnliRotate : MonoBehaviour
{
    #region Singleton class: HomeUnliRotate

    [SerializeField] public float rotationSpeed;
    Rigidbody2D rb;

	#endregion
    void Start()
    {
		rb = GetComponent<Rigidbody2D> ();

        RotateRight();
    }
    	void RotateRight ()
	{
		rb.angularVelocity = -rotationSpeed;
	}

    public void SetRotationSpeed(int speed){
        this.rotationSpeed = speed;
    }
}