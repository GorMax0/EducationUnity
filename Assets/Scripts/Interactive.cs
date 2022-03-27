using UnityEngine;
using TMPro;

public class Interactive : MonoBehaviour
{
    [SerializeField] private GameObject _uiAction;

    private TMP_Text _text;
    private float _distanceRay = 0.75f;

    private void Start()
    {
        _text = _uiAction.GetComponentInChildren<TMP_Text>();
    }

    private void Update()
    {
        DealWithDoor();
    }

    private void DealWithDoor()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, _distanceRay))
        {
            if (hit.collider.TryGetComponent(out Door door))
            {
                _uiAction.SetActive(true);
                _text.text = door.IsOpen ? "Закрыть дверь" : "Открыть дверь";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    door.ChangeState();
                }
            }
        }
        else
        {
            _uiAction.SetActive(false);
        }
    }

}
