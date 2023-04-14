using UnityEngine;
using Cinemachine;

public class MenuCamSwitcher : MonoBehaviour
{
    private const int MainPriorityCam = 10;

    [SerializeField] private CinemachineVirtualCamera _mainCam;

    private CinemachineVirtualCamera _activeCam;

    private void Awake()
    {
        _activeCam = _mainCam;
    }

    public void PressSwitch(CinemachineVirtualCamera cam)
    {
        _activeCam.Priority = 0;
        cam.Priority = MainPriorityCam;
        _activeCam = cam;
    }
}
