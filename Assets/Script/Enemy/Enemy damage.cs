using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemydamage : MonoBehaviour
{
    public int damage;
    public HealthSystem _heartsystem; // this is the variable that will be used to access the heartsystem script

// when the monster collides with the player, the player takes damage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _heartsystem.TakeDamage(damage);
        }
    }
}
