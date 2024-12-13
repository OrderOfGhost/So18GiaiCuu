using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerareaCheck : MonoBehaviour
{
    private Enemy2 enemyParent;

   private void Awake() 
   {
       enemyParent = GetComponentInParent<Enemy2>();
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
