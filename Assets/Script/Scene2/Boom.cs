using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boom : MonoBehaviour
{
    public Object HieuUngBoom;


     void Start()
    {
        HieuUngBoom = Resources.Load("HieuUngBoom");
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Player"))
        {
            GameObject hUno = (GameObject)Instantiate(HieuUngBoom);
        hUno.transform.position = new  Vector3(transform.position.x,transform.position.y, -1); 
            Invoke("DestroySelf",0.2f);
        }
    }
   
}
