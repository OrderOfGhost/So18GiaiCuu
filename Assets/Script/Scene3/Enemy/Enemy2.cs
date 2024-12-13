using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{   
    #region Public Variables
    public float attackDistance; //Minimum distance for attack
    public float moveSpeed;
    public float timer; //Timer for cooldown between attacks
    public Transform leftLimit;
    public Transform rightLimit;
    [HideInInspector] public Transform target;
    [HideInInspector] public bool inRange;
    public GameObject hotZone;
    public GameObject triggerArea;
    public bool faceright = true;

    public int ourHealth;
    public int maxhealth = 100;
    public int countHealth;

    public Animator anime;

    private myDamage damageScript;
    public GameObject hitbox;
    public GameObject Bullet;
    public Object bulletRef;

    public Sound sound;
    public GameObject  Enemy4;
    #endregion

    #region Private Variables
    private Animator anim;
    private float distance; //Store the distance b/w enemy and player
    private bool attackMode;
    private bool cooling; //Check if Enemy is cooling after attack
    private float intTimer;
    #endregion

    void Start()
    {
        Enemy4.SetActive(false);
        bulletRef = Resources.Load("BulletEn");
        ourHealth = maxhealth;
        countHealth = ourHealth;
        damageScript = hitbox.GetComponent<myDamage>();
        anime = gameObject.GetComponent<Animator>();
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<Sound>();
    }

    void Awake()
    {
        SelectTarget();
        intTimer = timer; //Store the inital value of timer
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!attackMode)
        {
            Move();
        }

        if (!InsideOfLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            SelectTarget();
        }

        if (inRange)
        {
            EnemyLogic();
        }

        if(countHealth>ourHealth)
        {
            StartCoroutine(BiDanh1());
        }
        if(ourHealth<=0)
                {
                    KillSelf();
                }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if (distance > attackDistance)
        {
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
        }
    }

    void Move()
    {
        anim.SetBool("canWalk", true);

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        sound.Playsound("Shot");
        timer = intTimer; //Reset Timer when Player enter Attack Range
        attackMode = true; //To check if Enemy can still attack or not

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }

    public void TriggerCooling()
    {
        cooling = true;
    }

    private bool InsideOfLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    public void SelectTarget()
    {
        float distanceToLeft = Vector3.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector3.Distance(transform.position, rightLimit.position);

        if (distanceToLeft > distanceToRight)
        {
            target = leftLimit;
        }
        else
        {
            target = rightLimit;
        }

        //Ternary Operator
        //target = distanceToLeft > distanceToRight ? leftLimit : rightLimit;

        Flip();
    }

    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x) 
        {
            rotation.y = 180;
            faceright =false;
        }
        else
        {
            Debug.Log("Twist");
            rotation.y = 0;
            faceright = true;
        }

        //Ternary Operator
        //rotation.y = (currentTarget.position.x < transform.position.x) ? rotation.y = 180f : rotation.y = 0f;

        transform.eulerAngles = rotation;
    }

    public void BulletEn()
    {
        GameObject bullet = (GameObject)Instantiate(bulletRef);
        bullet.GetComponent<BulletEn>().StartShot(faceright);
        bullet.transform.position = new  Vector3(transform.position.x,transform.position.y + .8f, -1);
    }

    // void OnTriggerEnter2D(Collider2D target)
    // {
    //         if(target.tag == hitbox.tag)
    //         {
    //             ourHealth -= damageScript.realDamage;
    //             if(ourHealth<=0)
    //             {
    //                 KillSelf();
    //             }
    //         }
    //         if(target.tag == Bullet.tag)
    //         {
    //             ourHealth-=damageScript.realDamage;
    //             if(ourHealth<=0)
    //             {
    //                 KillSelf();
    //             }
    //         }
    // }

    void Damage(int damage)
    {
        ourHealth -= damage;
    }
    
    IEnumerator BiDanh1()
    {
        sound.Playsound("Bidanh");
        anime.SetBool("BiDanh", true);
        yield return new WaitForSeconds(0.2f);
        anime.SetBool("BiDanh", false);
        countHealth = ourHealth;
    }

    private void KillSelf()
    {
        anime.SetBool("Die", true);
        Destroy(gameObject,1);
        Enemy4.SetActive(true);
    }

    public void BulleEn()
    {
        GameObject bullet = (GameObject)Instantiate(bulletRef);
        bullet.GetComponent<Bullet>().StartShot(faceright);
        bullet.transform.position = new  Vector3(transform.position.x,transform.position.y + .8f, -1);
    }
}
