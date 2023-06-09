using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] GameObject winScreen;
    public GameObject Player;
    public AudioSource WinSound;
    public AudioSource PlayerAudio;
    public AudioSource gameSfx;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            winScreen.SetActive(true);
            Time.timeScale = 0f;
            Player.SetActive(false);
            PlayerAudio.Stop();
            gameSfx.Stop();
            WinSound.Play();

        }
    }
}
