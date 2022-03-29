using UnityEngine;
using UnityEngine.Events;

public class DoorTrigger : MonoBehaviour
{
    private bool _isInHouse;

    public UnityAction<bool> OnChangeAlarm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _isInHouse = true;
            OnChangeAlarm?.Invoke(_isInHouse);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _isInHouse = false;
            OnChangeAlarm?.Invoke(_isInHouse);
        }
    }
}
