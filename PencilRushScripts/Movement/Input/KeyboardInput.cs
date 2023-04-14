using RunnerMovementSystem;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private MovementSystem _roadMovement;
    [SerializeField] private float _speed = 0.137f;

    private float _saveOffset;

    public bool IsMoved { get; private set; }

    private void OnEnable()
    {
        _roadMovement.PathChanged += OnPathChanged;
    }

    private void OnDisable()
    {
        _roadMovement.PathChanged -= OnPathChanged;
    }

    private void OnPathChanged(PathSegment _)
    {
        _saveOffset = _roadMovement.Offset;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            _saveOffset = _roadMovement.Offset;
            var offset = _speed * Mathf.Clamp(Input.GetAxis(Horizontal) * 100, -1, 1) * Time.deltaTime;
            _roadMovement.SetOffset(_saveOffset + offset);
        }
    }
}
