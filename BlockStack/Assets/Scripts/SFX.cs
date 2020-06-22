using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioClip[] audios;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCoinGetSound()
    {
        audioSource.PlayOneShot(audios[0]);
    }

    public void PlayBlockStackSound()
    {
        audioSource.PlayOneShot(audios[1]);
    }
}
