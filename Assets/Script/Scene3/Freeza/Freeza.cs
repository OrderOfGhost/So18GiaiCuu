using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeza : MonoBehaviour
{
    public int ourHealth;
    public int maxhealth = 500;
    public int countHealth;

    public bool health = false;
    public GameObject  healthUI;
    public GameObject  freeza;

    public Animator anime;

    private myDamage damageScript;
    public GameObject hitbox;
    public GameObject Bullet;  

    public HealthFreezaBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthUI.SetActive(false);
        ourHealth = maxhealth;
        countHealth = ourHealth;
        healthBar.SetMaxHealth(maxhealth);
        damageScript = hitbox.GetComponent<myDamage>();
        anime = gameObject.GetComponent<Animator>();
    }

    void Update()
    {

        if(countHealth>ourHealth)
        {
            StartCoroutine(BiDanh1());
        }
        if (freeza.activeSelf&&health==false)
        {
            health = !health;
 
        }
        if (ourHealth <=0 && health==true)
        {
            health = !health;
 
        }
 
        if (health)
        {
            healthUI.SetActive(true);
        }
 
        if (health == false)
        {
            healthUI.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == hitbox.tag)
        {
            ourHealth -= damageScript.realDamage;
            healthBar.SetHealth(ourHealth);
            if(ourHealth<=0)
            {
                KillSelf();
            }
        }
        if(target.tag == Bullet.tag)
        {
            ourHealth-=damageScript.realDamage;
            healthBar.SetHealth(ourHealth);
            if(ourHealth<=0)
            {
                KillSelf();
            }
        }
    }

    IEnumerator BiDanh1()
    {
        anime.SetBool("Bidanh", true);
        yield return new WaitForSeconds(0.2f);
        anime.SetBool("Bidanh", false);
        countHealth = ourHealth;
    }

    private void KillSelf()
    {
        anime.SetBool("die", true);
        Destroy(gameObject,1);
    }
}
