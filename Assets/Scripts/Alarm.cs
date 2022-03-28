using System.Collections;
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

    private IEnumerator VolumeChange()
    {
        int minVolume = 0;
        int maxVolume = 1;
        float step = 0.02f;
        var waitingTime = new WaitForSeconds(0.1f);

        while (_isInHouse ? _sound.volume < maxVolume : _sound.volume > minVolume)
        {
            _sound.volume += _isInHouse? Mathf.MoveTowards(minVolume, maxVolume, step) : Mathf.MoveTowards(minVolume, maxVolume, -step);
            yield return waitingTime;
        }
    }


    private void OnTriggerEnter()
    {       
        _isInHouse = true;
        _effect.Play();
        StartCoroutine(VolumeChange());
    }

    private void OnTriggerExit(Collider other)
    {
        _isInHouse = false;
        _effect.Stop();
        StartCoroutine(VolumeChange());
    }
}
