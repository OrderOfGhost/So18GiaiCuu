 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comboHits : MonoBehaviour
{
    public bool combo = false;
    public bool combo1 = false;
    public bool combo2 = false;
    public bool attacking = false;
    public Animator anim;
    public int noOfClicks =0;
    float lastClickedTime =0;
    public float maxComboDelay = 0.9f;

    public So18 player;
    
    public Collider2D trigger;

    private myDamage damageScript;
    public GameObject hitbox;
  
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponentInParent<So18>();
        anim = gameObject.GetComponent<Animator>();
        damageScript = hitbox.GetComponent<myDamage>();
        trigger.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
            trigger.enabled = false;
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
            lastClickedTime = Time.time;
            noOfClicks++;
            if(noOfClicks ==1)
            {
                if( player.grounded != true)
                {
                    attacking = true;
                    trigger.enabled = true;
                    anim.SetBool("Attacking", attacking);
                }
                else
                {
                combo = true;
                anim.SetBool("Combo", combo);
                trigger.enabled = true;
                }
            }
            noOfClicks = Mathf.Clamp(noOfClicks,0,3);
        }
    }
    public void return1()
    { 
        if(noOfClicks>=2)
        {
            combo1 = true;
            anim.SetBool("Combo1", combo1);
            trigger.enabled = true;
        }
        else
        {
            anim.SetBool("Combo",false);
            trigger.enabled = false;
            noOfClicks = 0;
        }
    }
    public void return2()
    {
        if(noOfClicks>=3)
        {
            combo2 = true;
            trigger.enabled = true;
            anim.SetBool("Combo2",combo2);
        }
        else
        {
            combo1 = false;
            trigger.enabled = false;
            anim.SetBool("Combo1",combo1);
            noOfClicks = 0;
        }
    }
    public void return3()
    {
        trigger.enabled = false;
        anim.SetBool("Attacking", false);
        anim.SetBool("Combo",false);
        anim.SetBool("Combo1",false);
        anim.SetBool("Combo2",false);
        noOfClicks = 0;
    }

    public void ChangeDmg(int newDmg)
    {
        damageScript.realDamage = newDmg;
    }

}
