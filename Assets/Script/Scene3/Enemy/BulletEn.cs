using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEn : MonoBehaviour
{
    public Rigidbody2D _myBody;
    [SerializeField]
        float speed;
    public int dame;
    // Start is called before the first frame update
    void Start()
    {
       _myBody = GetComponent<Rigidbody2D> ();
        Invoke("DestroySelf",4f);
    }


    public void StartShot(bool faceright){
         if(faceright)
         {
            _myBody.velocity = new Vector2(speed,0);
         }
         else
         {
               _myBody.velocity = new Vector2(-speed,0);
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
}
