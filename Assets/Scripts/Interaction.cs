using UnityEngine;
using TMPro;

public class Interaction : MonoBehaviour
{
    [SerializeField] private UiAction _uiAction;

    private TMP_Text _text;
    private float _distanceRay = 1f;

    private void Start()
    {
        _text = _uiAction.GetComponentInChildren<TMP_Text>();
    }

    private void Update()
    {
        RaycastWithDoor();
    }

    private void RaycastWithDoor()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, _distanceRay))
        {
            if (hit.collider.TryGetComponent(out DoorInteraction door))
            {
                _uiAction.Enable();
                _text.text = door.IsOpen ? "Закрыть дверь" : "Открыть дверь";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    door.ChangeState();
                }
            }
        }
        else
        {
            _uiAction.Disable();
        }
    }
}
