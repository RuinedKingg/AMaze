using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnExplosion : MonoBehaviour
{
    private AudioSource audioSource;
    private ParticleSystem particle;

    void OnEnable()
    {
        ExplodeEvent.OnDetonate += PlaySound;
        Debug.Log("Subscribed event - OnDetonate");

        audioSource = gameObject.GetComponent<AudioSource>();
        particle = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    void OnDisable()
    {
        ExplodeEvent.OnDetonate -= PlaySound;
        Debug.Log("Unsubscribed event - OnDetonate");
    }


    void PlaySound()
    {
        audioSource.Play();
        particle.Play();
    }
}
