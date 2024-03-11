using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows.Speech;

public class WinningScene : MonoBehaviour
{
    public PlayerObstacleSkinDatabase skinShopDatabase;
    public GameObject mainUI;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        mainUI.gameObject.SetActive(false);
        rb = GetComponent<Rigidbody2D> ();
        Rotate(1);
        StartCoroutine(DisplayWin());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DisplayWin(){
        yield return new WaitForSeconds(2.3f);
        Rotate(0);
        mainUI.gameObject.SetActive(true);
    }

    private void Rotate(float speed){
        rb.velocity = Vector2.up * speed;
    }
}
