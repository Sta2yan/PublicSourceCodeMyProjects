using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Finish : MonoBehaviour
{
    [SerializeField] private LevelSystem _levelSystem;
    [SerializeField] private Transform _targetForFollower;
    [SerializeField] private Transform _targetForCamera;

    public Transform TargetForCamera => _targetForCamera;

    private bool _isMove;
    private Transform _follower;
    private float _speed;

    private void OnValidate()
    {
        _levelSystem = FindObjectOfType<LevelSystem>();
    }

    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnEnable()
    {
        _levelSystem.Finished_Follower += OnEnded;
    }

    private void OnDisable()
    {
        _levelSystem.Finished_Follower -= OnEnded;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PencilFollower pencilFollower))
        {
            _levelSystem.InvokeFinish();
            _levelSystem.InvokeFinish(pencilFollower);
        }
    }

    private void Update()
    {
        if (_isMove && _follower)
            _follower.transform.position = Vector3.MoveTowards(_follower.transform.position, _targetForFollower.position, _speed * Time.deltaTime);
    }

    private void OnEnded(PencilFollower pencilFollower)
    {
        _follower = pencilFollower.transform;
        _speed = pencilFollower.MovementSystem.CurrentSpeed;
        _isMove = true;
        pencilFollower.EndMove();
    }
}
