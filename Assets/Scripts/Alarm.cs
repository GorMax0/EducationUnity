using UnityEngine;

public class Alarm : MonoBehaviour
{
    private AudioSource _sound;
    private ParticleSystem _effect;
    private bool _isInHouse;

    private void Awake()
    {
        _sound = GetComponentInChildren<AudioSource>();
        _effect = GetComponentInChildren<ParticleSystem>();
    }

    private void FixedUpdate()
    {
        VolumeChange();
    }

    private void VolumeChange()
    {
        int minVolume = 0;
        int maxVolume = 1;
        float step = 0.2f;
        float deltaVolume = Mathf.MoveTowards(minVolume, maxVolume, step * Time.fixedDeltaTime);

        _sound.volume += _isInHouse ? deltaVolume : -deltaVolume;
    }

    private void OnTriggerEnter()
    {
        _isInHouse = true;
        _effect.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        _isInHouse = false;
        _effect.Stop();
    }
}
