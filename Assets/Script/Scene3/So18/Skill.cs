using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public bool skill = false;
    public float skilldelay = 0.6f;
    public Animator anim;
    public Object bulletRef;
    public Object hieuUng;
    public So18 player;
    public bool faceright = true;


    public int ourMana;
    public int maxmana = 100;

    public ManaBar manaBar;

    public Rigidbody2D r2;

    
    // Start is called before the first frame update
    void Start()
    {
        bulletRef = Resources.Load("Bullet");
        hieuUng = Resources.Load("HieuUngSkill");
        anim = gameObject.GetComponent<Animator>();
        ourMana = maxmana;
        manaBar.SetMaxMana(maxmana);
        r2 = gameObject.GetComponent<Rigidbody2D>();
        player = gameObject.GetComponentInParent<So18>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && !skill && ourMana>=20)
        {   
            skill = true;
            skilldelay = 0.6f;
            
        }
        if (skill)
        {
            if (skilldelay > 0)
            {
                skilldelay -= Time.deltaTime;
            }
            else
            {
                skill = false;
            }
        }
        anim.SetBool("Skill3", skill);
    }
    
    void FixedUpdate()
    { 
        float h = Input.GetAxis("Horizontal");
         if (ourMana <= 0)
        {
            ourMana = 0;
        }
        if (ourMana >= maxmana)
        {
            ourMana = maxmana;
        }
        if (h>0 && !faceright)
        {
            Flip();
        }
 
        if (h < 0 && faceright)
        {
            Flip();
        }
    }
    void TakeMana(int mana)
    {
        ourMana -= mana;
        manaBar.SetMana(ourMana);
    }
    void UpMana(int mana)
    {
        ourMana += mana;
        manaBar.SetMana(ourMana);
    }

    public void Flip()
    {
        faceright = !faceright;
    }
    public void Bullet()
    {
        GameObject bullet = (GameObject)Instantiate(bulletRef);
        bullet.GetComponent<Bullet>().StartShot(faceright);
        bullet.transform.position = new  Vector3(transform.position.x,transform.position.y + .8f, -1);
    }
    public void HieuUngSkil()
    {
        GameObject hU = (GameObject)Instantiate(hieuUng);
        hU.transform.position = new  Vector3(transform.position.x,transform.position.y +.4f, -1);
    }
}
