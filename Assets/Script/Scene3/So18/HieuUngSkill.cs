using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HieuUngSkill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf",0.2f);
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
