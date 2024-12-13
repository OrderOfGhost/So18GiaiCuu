using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HieuUngDash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf",.5f);
    }

   public void StartDash(bool faceright){
         if(!faceright)
         {
               Vector3 Scale;
                Scale = transform.localScale;
                Scale.x *= -1; 
                transform.localScale = Scale;
         }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
