using Cinemachine;
using UnityEngine;

public class CameraFinishMover : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private LevelSystem _levelSystem;
    [SerializeField] private Finish _finish;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedRotate;

    private bool _isMove;

    private void OnValidate()
    {
        _levelSystem = FindObjectOfType<LevelSystem>();
    }

    private void OnEnable()
    {
        _levelSystem.Finished += OnEnded;
    }

    private void Update()
    {
        if (_isMove)
        {
            if (transform.position != _finish.TargetForCamera.position)
                transform.position = Vector3.MoveTowards(transform.position, _finish.TargetForCamera.position, _speedMove * Time.deltaTime);

            if (transform.rotation != Quaternion.identity)
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, _speedRotate * Time.deltaTime);
        }
    }

    private void OnDisable()
    {
        _levelSystem.Finished -= OnEnded;
    }

    private void OnEnded()
    {
        _camera.Follow = null;
        _isMove = true;
    }
}
