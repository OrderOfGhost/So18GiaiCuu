using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene0 : MonoBehaviour
{
    public int Levelload = 1;
    public float aa;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(quaman());
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(Levelload);
        }    
    }

    IEnumerator quaman()
    {
        yield return new WaitForSeconds(aa);
        SceneManager.LoadScene(Levelload);
    }
}
