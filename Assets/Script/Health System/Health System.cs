using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] int life;
    public bool isDead;
    public GameObject deathscreen;
    public GameObject player;
    public GameObject playerSFX;
    
    public Vector3 respawnPoint;


    private void Start()
    {
        respawnPoint = transform.position;
    }

    void Update()
    {
        if (isDead)
        {
            deathscreen.SetActive(true);
            Time.timeScale = 0;
            player.SetActive(false);
            playerSFX.SetActive(false);

        }
    }

    public void TakeDamage(int damage)
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
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Respawn"))
        {
            respawnPoint = player.transform.position;
        }
        else
        {
            player.transform.position = respawnPoint;
        }
    }

    public void Respawn()
    {
        player.transform.position = respawnPoint;
    }
}
