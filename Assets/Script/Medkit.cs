using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Medkit : MonoBehaviour
{
   public HealthSystem _heartsystem; 
   public AudioSource medkitSound;



   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player") && !other.isTrigger)
      {
         _heartsystem.Heal(1);
         medkitSound.Play();
         Destroy(gameObject);
      }
      else
      {
         return;
      }

   }
   
   
}
