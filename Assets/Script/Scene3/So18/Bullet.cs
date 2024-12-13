using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D _myBody;
    public Object HieuUngNo;
    [SerializeField]
        float speed;
    public int dame;
    // Start is called before the first frame update
    void Start()
    {
        HieuUngNo = Resources.Load("HieuUngNo");
       _myBody = GetComponent<Rigidbody2D> ();
        Invoke("DestroySelf",4.5f);
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
         if (other.isTrigger != true && other.CompareTag("Enemy"))
        {
            other.SendMessageUpwards("Damage", dame);
        }
        if(other.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy() {
        GameObject hUno = (GameObject)Instantiate(HieuUngNo);
        hUno.transform.position = new  Vector3(transform.position.x +2.4f,transform.position.y -0.5f, -1);
        Destroy(hUno, 0.10f);
    }
}
