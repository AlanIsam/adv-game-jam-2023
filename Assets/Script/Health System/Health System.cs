using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] int life;
    public bool isDead;
    
    void Update()
    {
        if (isDead)
        {
            Debug.Log("You are dead");
        }
    }

    public void TakeDamage (int damage)
    {
        //prevent damage taken when space button is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return;
        }
        if (life >= 1)
        {

            life -= damage;
            if (life < 1)
            {
                isDead = true;
            
            }
        }

    }
}
