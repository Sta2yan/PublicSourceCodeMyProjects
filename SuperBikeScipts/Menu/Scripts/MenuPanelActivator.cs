using UnityEngine;

public class MenuPanelActivator : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out MainCam cam))
            _panel.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out MainCam cam))
            _panel.SetActive(false);
    }
}
