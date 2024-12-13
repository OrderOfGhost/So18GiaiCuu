using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerareaaCheck : MonoBehaviour
{
    private Enemy1 enemyParent;

   private void Awake() 
   {
       enemyParent = GetComponentInParent<Enemy1>();
   }

   private void OnTriggerEnter2D(Collider2D other) 
   {
        if(other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            enemyParent.target = other.transform;
            enemyParent.inRange = true;
            enemyParent.hotZone.SetActive(true);
        }    
   }
}
