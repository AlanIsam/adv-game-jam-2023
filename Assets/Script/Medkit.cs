using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
   public HealthSystem _heartsystem; 
   
   
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player") && !other.isTrigger)
      {
         _heartsystem.Heal(1);
         Destroy(gameObject);
      }
   }
}
