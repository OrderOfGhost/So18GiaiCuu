using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
   public bool power = false;
    public float powerdelay = 0.1f;
    public Animator anim;
    public Object hieuUng;
    public Object hieuUng2;
    public Object hieuUng3;
    public So18 player;
    public Rigidbody2D r2;
    public Sound sound;
    // Start is called before the first frame update
    void Start()
    {
        hieuUng = Resources.Load("HieuUngPhanNo");
        hieuUng2 = Resources.Load("HieuUngPhanNo2");
        hieuUng3 = Resources.Load("HieuUngPhanNo3");
        anim = gameObject.GetComponent<Animator>();
        player = gameObject.GetComponentInParent<So18>();
        r2 = gameObject.GetComponent<Rigidbody2D>();
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<Sound>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L) && !power)
        {    sound.Playsound("Powwer");
            power = true;
            powerdelay = 0.1f;
        }
        if (power)
        {
            if (powerdelay > 0)
            {
                powerdelay -= Time.deltaTime;
            }
            else
            {
                power = false;
            }
        }
        anim.SetBool("Power", power);
    }
    public void HieuUngPower()
    {
        GameObject hU = (GameObject)Instantiate(hieuUng);
        GameObject hU2 = (GameObject)Instantiate(hieuUng2);
        GameObject hU3 = (GameObject)Instantiate(hieuUng3);
        hU.transform.position = new  Vector3(transform.position.x,transform.position.y +.4f, -17);
        hU2.transform.position = new  Vector3(transform.position.x -.7f,transform.position.y +.2f, -18);
        hU3.transform.position = new  Vector3(transform.position.x +.7f,transform.position.y +.2f, -18);
    }
}
