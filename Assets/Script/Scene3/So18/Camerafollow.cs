using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Camerafollow : MonoBehaviour {
    public float smoothtimeX, smoothtimeY;
    public Vector2 velocity;
 
    public GameObject player;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
   
   
    void FixedUpdate () {
        float posX = Mathf.SmoothDamp(this.transform.position.x, player.transform.position.x, ref velocity.x, smoothtimeX);
        float posY = Mathf.SmoothDamp(this.transform.position.y, player.transform.position.y, ref velocity.y, smoothtimeY);
        transform.position = new Vector3(posX, posY, transform.position.z);
 
    }
}