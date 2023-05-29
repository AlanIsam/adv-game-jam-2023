using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius = 5f;
    [Range(1,360)]public float angle = 45f;

    public LayerMask targetLayer;
    public LayerMask obstacleLayer;
    
    public GameObject Player;
    public HealthSystem playerHealth;
    
    public bool canSeePlayer { get; private set; }
    

     void Start()
     {
      Player = GameObject.FindGameObjectWithTag("Player");
     StartCoroutine(FOVCheck());
     StartCoroutine(PlayerDeath());
     }

     private IEnumerator FOVCheck()
     {
      WaitForSeconds wait = new WaitForSeconds(0.2f);
      while (true)
      {
       yield return wait;
       FOV();
      }
     }

     private IEnumerator PlayerDeath()
     {
      WaitForSeconds wait = new WaitForSeconds(1f);
      while (true)
      {
       yield return wait;
       if (canSeePlayer)
       {
        playerHealth.TakeDamage(1);
       }
      }
     }
     
     

     private void FOV()
     {
      Collider2D[] rangeChecks = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);
      if (rangeChecks.Length > 0)
      {
       Transform target = rangeChecks[0].transform;
       Vector2 directionToTarget = (target.position - transform.position).normalized;

       if (Vector2.Angle(transform.up, directionToTarget) < angle / 2)
       {
        float distanceToTarget = Vector2.Distance(transform.position, target.position);

        if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleLayer))
         canSeePlayer = true;
        else
         canSeePlayer = false;

       }
       else
          canSeePlayer = false;
       
      }
      else if (canSeePlayer)
         canSeePlayer = false;
      

     }

     

     private void OnDrawGizmos()
     {
      Gizmos.color = Color.white;
      UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, radius);
      
      Vector3 angleA = DirectionFromAngle(-transform.eulerAngles.z, angle / 2);
      Vector3 angleB = DirectionFromAngle(-transform.eulerAngles.z, -angle / 2);

      Gizmos.color = Color.yellow;
      Gizmos.DrawLine(transform.position, transform.position + angleA * radius);
      Gizmos.DrawLine(transform.position, transform.position + angleB * radius);

      if (canSeePlayer)
      {
       Gizmos.color = Color.green;
       Gizmos.DrawLine(transform.position, Player.transform.position);
       PlayerDeath();
      }
     }
  
     
     
     private Vector2 DirectionFromAngle(float eulerY, float angleInDegree)
     {
      angleInDegree += eulerY;
      return new Vector2(Mathf.Sin(angleInDegree * Mathf.Deg2Rad), Mathf.Cos(angleInDegree * Mathf.Deg2Rad));
     }
     

}
