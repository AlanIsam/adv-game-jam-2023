using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonSFX : MonoBehaviour
{
    public AudioSource soundFX;
    public AudioClip hoverSFX;
    public AudioClip clickSFX;

    public void HoverSound()
    {
        soundFX.PlayOneShot(hoverSFX);
    }

    public void ClickSound()
    {
        soundFX.PlayOneShot(clickSFX);
    }

}
