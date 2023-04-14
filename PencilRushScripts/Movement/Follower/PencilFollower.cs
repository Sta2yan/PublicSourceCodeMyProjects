using RunnerMovementSystem;
using System;
using UnityEngine;

public class PencilFollower : MonoBehaviour
{
    [SerializeField] private MovementSystem _movementSystem;
    [SerializeField] private LineSystemPencilsCount _lineSystemPencilsCount;
    [SerializeField] private FollowerOutRoadChecker _followerOutRoadChecker;

    private bool _isEndMove;

    public event Action FollowEnded;

    public MovementSystem MovementSystem => _movementSystem;
    public LineSystemPencilsCount LineSystemPencilsCount => _lineSystemPencilsCount;
    public FollowerOutRoadChecker FollowerOutRoadChecker => _followerOutRoadChecker;

    private void Start()
    {
        _movementSystem.IsMove = false;
    }

    public void StartMove()
    {
        if (_isEndMove == false)
        {
            _movementSystem.IsMove = true;
            _movementSystem.enabled = true;
            _followerOutRoadChecker.enabled = true;
        }
    }

    public void StopMove()
    {
        if (_isEndMove == false)
        {
            _movementSystem.IsMove = false;
            _movementSystem.enabled = false;
        }
    }

    public void EndMove()
    {
        _movementSystem.enabled = false;
        _isEndMove = true;
        FollowEnded?.Invoke();
    }
}
