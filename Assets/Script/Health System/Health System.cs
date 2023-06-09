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
    public AudioSource playerSFX;
    public HealthBar healthBar;
    public int currentHealth;
    public AudioSource gameSFX;
    public AudioSource walkingSFX;
    public bool canPickUpMedkit = true;

    public Vector3 respawnPoint;

    public bool isFullHeal;


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
            gameSFX.Stop();
            walkingSFX.Stop();

        }



    }

    public bool IsFullHealth()
    {
        return currentHealth >= life;
    }

    public void TakeDamage(int damage)
    {
        //prevent damage taken when space button is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return;
        }

        if (currentHealth == life)
        {
            isFullHeal = true;
        }

        if (currentHealth >= 1)
        {

            currentHealth -= damage;
            isFullHeal = false;
            healthBar.SetHealth(currentHealth);
            if (currentHealth < 1)
            {
                isDead = true;
                playerSFX.Play();

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
            return;
        }
    }

    public void Respawn()
    {
        player.transform.position = respawnPoint;
        isDead = false;
        player.SetActive(true);
        deathscreen.SetActive(false);
        Time.timeScale = 1;
        currentHealth = life;
        healthBar.SetHealth(currentHealth);
        gameSFX.Play();

    }

    public void Heal(int healAmount)
    {
        if (currentHealth < life)
        {
            currentHealth += healAmount;
            healthBar.SetHealth(currentHealth);
            if (currentHealth > life)
            {
                currentHealth = life;
                healthBar.SetHealth(currentHealth);
            }
        }
    }
}
