using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaCheck : MonoBehaviour
{
   private FreezaAI enemyParent;

   private void Awake() 
   {
       enemyParent = GetComponentInParent<FreezaAI>();
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
