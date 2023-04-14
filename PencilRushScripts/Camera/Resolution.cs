using Cinemachine;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private float _fovDesktop;
    [SerializeField] private float _fovMobile;

    private void Awake()
        => SetFov();

    private void SetFov()
    {
        if (Camera.main.pixelWidth > Camera.main.pixelHeight)
            _camera.m_Lens.FieldOfView = _fovDesktop;
        else
            _camera.m_Lens.FieldOfView = _fovMobile;
    }
}
