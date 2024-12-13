using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    // public Object Enemy1;
    // public Object Enemy2;
    // public Object Left;
    // public Object Right;
    // public float timer=0;
    // // public bool dotlinhmoi = false;
    // // public int demdotlinh =0;  
    // // Start is called before the first frame update
    // void Start()
    // {
    //     Enemy1 = Resources.Load("Enemy1");
    //     Enemy2 = Resources.Load("Enemy2");
    //     Left = Resources.Load("left");
    //     Right = Resources.Load("right");
    //     LinhDot1();
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if(timer==1){
    //         StartCoroutine(LinhDot2());
    //     }
    //     if(timer==2){
    //         StartCoroutine(LinhDot2());
    //     }
    //     if(timer==3){
    //         StartCoroutine(LinhDot2());
    //     }
    // }

    // IEnumerator Enemy1Ref()
    // {
    //     GameObject LeftR1 = (GameObject)Instantiate(Left);
    //     LeftR1.transform.position = new  Vector3(transform.position.x-20f,transform.position.y-3f, -1);
    //     GameObject RightR1 = (GameObject)Instantiate(Right);
    //     RightR1.transform.position = new  Vector3(transform.position.x-5f,transform.position.y-3f, -1);
    //     yield return new WaitForSeconds(0.2f);
    //     GameObject EnemyR1 = (GameObject)Instantiate(Enemy1);
    //     EnemyR1.transform.position = new  Vector3(transform.position.x-25f,transform.position.y, -1);
    // }

    // public void Enemy2Ref()
    // {
    //     GameObject EnemyR2 = (GameObject)Instantiate(Enemy2);
    //     EnemyR2.transform.position = new  Vector3(transform.position.x-45,transform.position.y, -1);
    // }

    // public void LinhDot1()
    // {
    //     timer+=1;
    //     // Enemy1Ref();
    //     StartCoroutine(Enemy1Ref());
    // }
    // IEnumerator LinhDot2()
    // {
    //     timer+=1;
    //     yield return new WaitForSeconds(10f);
    //     StartCoroutine(Enemy1Ref());
    // }
}
