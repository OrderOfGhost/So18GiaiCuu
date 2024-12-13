using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float speed = 80f;
    public bool faceright = true, soda = false, food = false, key = false, quanman = false;
    public Rigidbody2D r2;
    public Animator anim;
    public int Levelload = 1;
    public int Levelload2 = 1;
    private Vector2 moveDir;

    public int ourHealth=100;
    public int ourHealth2;
    
    public GameObject Enemy;

    public Sound2 sound;

    void Start() {
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<Sound2>();    
    }

    // Start is called before the first frame update
     void Awake() {
         r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }
    

    // Update is called once per frame
    void Update()
    {
       anim.SetFloat("speed", Mathf.Abs(r2.velocity.x));
       
       ProcessInputs();

       if(soda==true&&food==true&&key==true)
       {
           quanman = true;
       }
       ourHealth2 = ourHealth;
    }

    void FixedUpdate()
    {
        Move();
    }
    
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX,moveY).normalized;

        if (moveX>0 && !faceright)
        {
            Flip();
        }
 
        if (moveX < 0 && faceright)
        {
            Flip();
        }
    }

    void Move()
    {
        r2.velocity = new Vector2(moveDir.x*speed,moveDir.y*speed);
    }

    public void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1; 
        transform.localScale = Scale;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Soda"))
        {
            sound.Playsound("soda");
            soda = true;
        }
        if(other.tag.Equals("Food"))
        {
            sound.Playsound("food");
            food = true;
        }
        if(other.tag.Equals("Key"))
        {
            sound.Playsound("soda");
            key = true;
        }
        if(other.tag == Enemy.tag)
            {
                ourHealth -= 10;
            }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(quanman==true)
        {
            if (col.CompareTag("Exit"))
            {
                SceneManager.LoadScene(Levelload);
            }
        }

        if (col.CompareTag("Boom"))
            {
                sound.Playsound("destroy");
                Invoke("Die",0.2f);
            }
        
    }

    

    private void Die()
    {
        SceneManager.LoadScene(Levelload2);
    }
}
