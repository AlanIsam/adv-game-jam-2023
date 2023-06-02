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
    public HealthBar healthBar;
    public int currentHealth;

    public Vector3 respawnPoint;


    private void Start()
    {
        currentHealth = life;
        respawnPoint = player.transform.position;
        healthBar.SetMaxHealth(life);
        
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

        if (currentHealth >= 1)
        {

            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if (currentHealth < 1)
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
        isDead = false;
        player.SetActive(true);
        deathscreen.SetActive(false);
        Time.timeScale = 1;
        playerSFX.SetActive(false);
        currentHealth = life;
        healthBar.SetHealth(currentHealth);

    }
}
