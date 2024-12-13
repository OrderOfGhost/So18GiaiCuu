using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    public player player;
    
    public GameObject endmap1;
    public GameObject endmap2;
 
    // Use this for initialization
    void Start () {
        player = gameObject.GetComponentInParent<player>();
    }
 
    // Update is called once per frame
    void FixedUpdate()
    {
           
    }
 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == false && collision.tag != endmap1.tag && collision.tag != endmap2.tag)
        player.grounded = true;
    }
 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger == false && collision.tag != endmap1.tag && collision.tag != endmap2.tag)
        player.grounded = true;
    }
 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger == false && collision.tag != endmap1.tag && collision.tag != endmap2.tag)
        player.grounded = false;
    }
}
