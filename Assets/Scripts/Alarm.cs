using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private DoorTrigger _door;

    private Coroutine _volumeChange;
    private AudioSource _sound;
    private ParticleSystem _effect;

    private void Awake()
    {
        _sound = GetComponentInChildren<AudioSource>();
        _effect = GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        _door.OnChangeAlarm += ControlAlarm;
    }

    private void OnDestroy()
    {
        _door.OnChangeAlarm -= ControlAlarm;
    }

    private void StartVolumeChange(bool isInHouse)
    {
        if (_volumeChange == null)
        {
            _volumeChange = StartCoroutine(VolumeChange(isInHouse));
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
        int targetVolume = isInHouse ? 1 : 0;
        float step = 0.02f;
        var waitingTime = new WaitForSeconds(0.1f);

        while (_sound.volume != targetVolume)
        {
            _sound.volume = Mathf.MoveTowards(_sound.volume, targetVolume, step);
            yield return waitingTime;
        }
    }

    private void ControlAlarm(bool isInHouse)
    {
        StopVolumeChange();
        StartVolumeChange(isInHouse);

        if (isInHouse)
            _effect.Play();
        else
            _effect.Stop();
    }
}
