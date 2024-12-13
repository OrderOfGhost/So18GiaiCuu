using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class So18 : MonoBehaviour
{
    public float speed = 80f, maxspeed = 10, jumpPow = 300f;
    public bool grounded = true, faceright = true, doublejump = false;
 
    public int ourHealth;
    public int maxhealth = 100;
    public int countHealth;

    public HealthBar healthBar;

    public Rigidbody2D r2;
    public Animator anim;

    public float dashDistance = 100f;
    bool isDashing;
    float doubleTapTime;
    float jumpTime;
    KeyCode lastKeyCode;

    public Object hieuUng;

    private dameenemy damageScript;
    private dameenemy damageScript1;
    private dameenemy damageScript2;
    private dameenemy damageScript3;
    public GameObject hitboxen;
    public GameObject hitboxen2;
    public GameObject triggerArea;
    public GameObject triggerArea2;
    public GameObject BulletEn;
    public GameObject BulletEn2;
    public Sound sound;

    public Skill mana;
    
    // Use this for initialization
    void Start () {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        ourHealth = maxhealth;
        countHealth = ourHealth;
        healthBar.SetMaxHealth(maxhealth);
        hieuUng = Resources.Load("HieuUngDash");
        damageScript = hitboxen.GetComponent<dameenemy>();
        damageScript1 = hitboxen2.GetComponent<dameenemy>();
        damageScript2 = triggerArea.GetComponent<dameenemy>();
        damageScript3 = triggerArea2.GetComponent<dameenemy>();
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<Sound>();
    }
   
    // Update is called once per frame
    void Update () 
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));
 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        //Dashing Left
        if (Input.GetKeyDown(KeyCode.A))
        {
            if(doubleTapTime > Time.time &&  lastKeyCode == KeyCode.A && grounded == true && mana.ourMana>=10){
                StartCoroutine(Dash(-1f));
            }else{
                doubleTapTime = Time.time + 0.5f;
            }

            lastKeyCode = KeyCode.A;
        }

        //Dashing Right
        if (Input.GetKeyDown(KeyCode.D))
        {
            if(doubleTapTime > Time.time &&  lastKeyCode == KeyCode.D && grounded == true && mana.ourMana>=10){
                StartCoroutine(Dash(1f));
            }else{
                doubleTapTime = Time.time + 0.5f;
            }

            lastKeyCode = KeyCode.D;
        }

        FixJump();
        if(ourHealth>maxhealth){
            ourHealth = maxhealth;
        }
    }
 
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        if(!isDashing){
        r2.AddForce((Vector2.right) * speed * h * 2);
        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);
        }
        if (h>0 && !faceright)
        {
            Flip();
        }
 
        if (h < 0 && faceright)
        {
            Flip();
        }
 
        if (grounded)
        {
            r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y);
        }

         if(countHealth>ourHealth)
        {
            StartCoroutine(BiDanh1());
        }
 
        if (ourHealth <= 0)
        {
            Death();
        }

    }

    public void UpHealth()
    {
        ourHealth += 10;
        healthBar.SetHealth(ourHealth);
    }
 
    public void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1; 
        transform.localScale = Scale;
    }

 
    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Jump()
    {
        if (grounded)
            {
                jumpTime = Time.time + 1.2f;
                grounded = false;
                doublejump = true;
                r2.AddForce(Vector2.up * jumpPow);
            }
 
            else
            {
                if (doublejump)
                {
                    StartCoroutine(doubleJump());
                }
            }
    }

    public void FixJump()
    {
        if(jumpTime < Time.time && grounded != true ){
                endJump();
            }
    }

    public void endJump()
    {
        r2.velocity = new Vector2(r2.velocity.x, 0);
        r2.AddForce(Vector2.down * (jumpPow - 3f));
    }

    IEnumerator doubleJump()
    {
        doublejump = false;
        yield return new WaitForSeconds(0.1f);
        r2.velocity = new Vector2(r2.velocity.x, 0);
        r2.AddForce(Vector2.up * jumpPow * 2f);
    }

    IEnumerator Dash (float direction)
    {
        sound.Playsound("Dash");
        isDashing = true;
        r2.velocity = new Vector2(r2.velocity.x, 0f);
        r2.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        float gravity = r2.gravityScale;
        r2.gravityScale = 0;
        anim.SetBool("Dash", isDashing); 
        yield return new WaitForSeconds(0.2f);
        isDashing = false;
        anim.SetBool("Dash", isDashing);
        r2.gravityScale = gravity;
        yield return new WaitForSeconds(0.2f);
    }

    public void HieuUngDash()
    {
        GameObject hU = (GameObject)Instantiate(hieuUng);
        hU.transform.position = new  Vector3(transform.position.x,transform.position.y, -1);
        hU.GetComponent<HieuUngDash>().StartDash(faceright);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
            if(target.tag == hitboxen.tag)
            {
                ourHealth -= damageScript.realDamage;
                healthBar.SetHealth(ourHealth);
                if(ourHealth<=0)
                {
                    Death();
                }
            }

            if(target.tag == hitboxen2.tag)
            {
                ourHealth -= damageScript1.realDamage;
                healthBar.SetHealth(ourHealth);
                if(ourHealth<=0)
                {
                    Death();
                }
            }

            if(target.tag == BulletEn.tag)
            {
                ourHealth-=damageScript2.realDamage;
                healthBar.SetHealth(ourHealth);
                if(ourHealth<=0)
                {
                    Death();
                }
            }

             if(target.tag == BulletEn2.tag)
            {
                ourHealth-=damageScript3.realDamage;
                healthBar.SetHealth(ourHealth);
                if(ourHealth<=0)
                {
                    Death();
                }
            }
    }

    IEnumerator BiDanh1()
    {
        sound.Playsound("Bidanh");
        anim.SetBool("BiDanh", true);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("BiDanh", false);
        countHealth = ourHealth;
    }
}

