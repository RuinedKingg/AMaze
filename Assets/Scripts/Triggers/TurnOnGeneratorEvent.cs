using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnGeneratorEvent : MonoBehaviour
{
    [Header("Audio parameters")]
    [SerializeField] private AudioClip audioClip;

    private AudioSource audioSource;

    public delegate void GeneratorOnHandler();
    public static event GeneratorOnHandler OnGeneratorOn;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<InventoryComponent>().CheckItem("Can"))
        {
            GetComponent<BoxCollider>().enabled = false;
            OnGeneratorOn?.Invoke();
            TurnOnSound();
        }
    }

    private void TurnOnSound()
    {
        audioSource.Play();

        Invoke(nameof(OnAudioEnd), audioSource.clip.length);
    }

    private void OnAudioEnd()
    {
        Debug.Log("Clip end");
        audioSource.clip = audioClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
