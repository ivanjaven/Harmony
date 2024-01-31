
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.SceneManagement;

public class DefaultPlayLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OpenScene(){
        SceneManager.LoadScene("level01");
    }
}
