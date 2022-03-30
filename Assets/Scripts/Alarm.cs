using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private DoorTrigger _door;

    private IEnumerator _volumeChange;
    private AudioSource _sound;
    private ParticleSystem _effect;

    private void Awake()
    {
        _sound = GetComponentInChildren<AudioSource>();
        _effect = GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        _door.OnChangeAlarm += StateChange;
    }

    private void StartVolumeChange(bool isInHouse)
    {
        if (_volumeChange == null)
        {
            _volumeChange = VolumeChange(isInHouse);
            StartCoroutine(_volumeChange);
        }
    }

    private void StopVolumeChange()
    {
        if (_volumeChange != null)
        {
            StopCoroutine(_volumeChange);
            _volumeChange = null;
        }
    }

    private IEnumerator VolumeChange(bool isInHouse)
    {
        int minVolume = 0;
        int maxVolume = 1;
        float step = 0.02f;
        var waitingTime = new WaitForSeconds(0.1f);

        while (isInHouse ? _sound.volume < maxVolume : _sound.volume > minVolume)
        {
            _sound.volume += isInHouse ? Mathf.MoveTowards(minVolume, maxVolume, step) : Mathf.MoveTowards(minVolume, maxVolume, -step);
            yield return waitingTime;
        }
    }

    private void StateChange(bool isInHouse)
    {
        StopVolumeChange();
        StartVolumeChange(isInHouse);

        if (isInHouse)
            _effect.Play();
        else
            _effect.Stop();
    }
}
