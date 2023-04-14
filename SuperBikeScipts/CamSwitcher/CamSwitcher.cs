using UnityEngine;
using Cinemachine;

public class CamSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _mainCam;
    [SerializeField] private CinemachineVirtualCamera _secondCam;

    private CinemachineVirtualCamera _activeCam;

    private void Awake()
        => Switch();

    public void Switch()
    {
        if (_activeCam == null)
            _activeCam = _secondCam;

        if (_activeCam == _mainCam)
        {
            _activeCam = _secondCam;
            _mainCam.Priority = 0;
            _secondCam.Priority = 10;
        }
        else
        {
            _activeCam = _mainCam;
            _mainCam.Priority = 10;
            _secondCam.Priority = 0;
        }
    }
}
