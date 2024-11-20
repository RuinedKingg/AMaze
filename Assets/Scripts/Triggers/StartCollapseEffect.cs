using UnityEngine;

public class StartCollapseEffect : MonoBehaviour
{
    private ParticleSystem particles;
    private AudioSource audioSource;

    private void OnEnable()
    {
        CollapseEvent.OnRocksCollapse += StartEffect;

        particles = GetComponentInChildren<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        CollapseEvent.OnRocksCollapse -= StartEffect;
    }

    private void StartEffect()
    {
        particles.Play();
        audioSource.Play();
    }
}
