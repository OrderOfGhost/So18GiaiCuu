using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HieuUngDie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf",2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
