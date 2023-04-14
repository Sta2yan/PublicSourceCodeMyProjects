using UnityEngine;
using Cinemachine;

public class FowCameraChanger : MonoBehaviour
{
    private const float MinFirstRange = 30f;
    private const float MaxFirstRange = 35f;
    private const float SecondRange = 45f;
    private const float ThirdRange = 55f;
    private const float FourthRange = 65f;

    private const int FovFirstStep = 80;
    private const int FovSecondStep = 85;
    private const int FovThirdtStep = 90;
    private const int FovFourthStep = 95;
    private const int FovFifthStep = 100;
    private const int FovSixthStep = 105;

    private const int MaxTimeChange = 30;
    private const int MinTimeChange = 10;

    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private Rigidbody _rigidbody;

    private void Update()
        => DynamicFovChange();

    private void DynamicFovChange()
    {
        if (_rigidbody.velocity.magnitude > MinFirstRange && _rigidbody.velocity.magnitude < MaxFirstRange)
            _camera.m_Lens.FieldOfView = _camera.m_Lens.FieldOfView = Mathf.MoveTowards(_camera.m_Lens.FieldOfView, FovSecondStep, Time.deltaTime * MinTimeChange);
        else if (_rigidbody.velocity.magnitude > MaxFirstRange && _rigidbody.velocity.magnitude < SecondRange)
            _camera.m_Lens.FieldOfView = _camera.m_Lens.FieldOfView = Mathf.MoveTowards(_camera.m_Lens.FieldOfView, FovThirdtStep, Time.deltaTime * MinTimeChange);
        else if (_rigidbody.velocity.magnitude > SecondRange && _rigidbody.velocity.magnitude < ThirdRange)
            _camera.m_Lens.FieldOfView = _camera.m_Lens.FieldOfView = Mathf.MoveTowards(_camera.m_Lens.FieldOfView, FovFourthStep, Time.deltaTime * MinTimeChange);
        else if (_rigidbody.velocity.magnitude > ThirdRange && _rigidbody.velocity.magnitude < FourthRange)
            _camera.m_Lens.FieldOfView = _camera.m_Lens.FieldOfView = Mathf.MoveTowards(_camera.m_Lens.FieldOfView, FovFifthStep, Time.deltaTime * MinTimeChange);
        else if (_rigidbody.velocity.magnitude > FourthRange)
            _camera.m_Lens.FieldOfView = _camera.m_Lens.FieldOfView = Mathf.MoveTowards(_camera.m_Lens.FieldOfView, FovSixthStep, Time.deltaTime * MinTimeChange);
        else
            _camera.m_Lens.FieldOfView = _camera.m_Lens.FieldOfView = Mathf.MoveTowards(_camera.m_Lens.FieldOfView, FovFirstStep, Time.deltaTime * MaxTimeChange);
    }
}
