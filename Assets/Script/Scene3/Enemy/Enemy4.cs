using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy4 : MonoBehaviour
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
    public bool skillmode = true;
    
    public GameObject  healthUI;
    public HealthFreezaBar healthBar;

    public int ourHealth;
    public int maxhealth = 100;
    public int countHealth;

    public Animator anime;

    public GameObject hitbox;
    public GameObject Bullet;
    public Object hieuUng;
    public Object bulletRef;

    public Sound sound;
    #endregion

    #region Private Variables
    private Animator anim;
    private float distance; //Store the distance b/w enemy and player
    private bool attackMode;
    private bool cooling; //Check if Enemy is cooling after attack
    private float intTimer;
    private myDamage damageScript;
    #endregion

    void Start()
    {
        healthUI.SetActive(false);
        ourHealth = maxhealth;
        countHealth = ourHealth;
        healthBar.SetMaxHealth(maxhealth);
        damageScript = hitbox.GetComponent<myDamage>();
        anime = gameObject.GetComponent<Animator>();
        hieuUng = Resources.Load("Dao");
        bulletRef = Resources.Load("BulletEn2");
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

        if (ourHealth>0)
        {
            healthUI.SetActive(true);
        }

        if(countHealth>ourHealth)
        {
            StartCoroutine(BiDanh1());
        }

        if(ourHealth<=0)
                {
                    healthUI.SetActive(false);
                    StartCoroutine(KillSelf());
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
        if(ourHealth<=250 && skillmode == true)
        {
            SkillMode();
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
        timer = intTimer; //Reset Timer when Player enter Attack Range
        attackMode = true; //To check if Enemy can still attack or not

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
    }

    IEnumerator Attack2()
    {
        timer = intTimer; //Reset Timer when Player enter Attack Range
        attackMode = true; //To check if Enemy can still attack or not

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack2", true);
        yield return new WaitForSeconds(1.3f);
        anim.SetBool("Attack2", false);
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
        anim.SetBool("Attack2", false);
    }

    void SkillMode()
    {
        StartCoroutine(Attack2());
        skillmode = false;
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
            faceright=false;
        }
        else
        {
            Debug.Log("Twist");
            rotation.y = 0;
            faceright=true;
        }

        //Ternary Operator
        //rotation.y = (currentTarget.position.x < transform.position.x) ? rotation.y = 180f : rotation.y = 0f;

        transform.eulerAngles = rotation;
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

    public void BulletEn()
    {
        GameObject bullet = (GameObject)Instantiate(bulletRef);
        bullet.GetComponent<BulletEn>().StartShot(faceright);
        bullet.transform.position = new  Vector3(transform.position.x,transform.position.y + .8f, -1);
    }

    void Damage(int damage)
    {
        ourHealth -= damage;
        healthBar.SetHealth(ourHealth);
    }

    IEnumerator BiDanh1()
    {
        sound.Playsound("Bidanh");
        anime.SetBool("BiDanh", true);
        yield return new WaitForSeconds(0.2f);
        anime.SetBool("BiDanh", false);
        countHealth = ourHealth;
    }

    IEnumerator KillSelf()
    {
        anime.SetBool("Die", true);
        Destroy(gameObject,2);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HieuUngDie()
    {
        GameObject hU = (GameObject)Instantiate(hieuUng);
        hU.transform.position = new  Vector3(transform.position.x-2.4f,transform.position.y +1.4f, -1);
    }
}
