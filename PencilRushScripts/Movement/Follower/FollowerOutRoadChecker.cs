using RunnerMovementSystem;
using System.Collections.Generic;
using UnityEngine;

public class FollowerOutRoadChecker : MonoBehaviour
{
    [SerializeField] private PencilFollower _pencilFollower;
    [SerializeField] private LevelSystem _levelSystem;

    private PathSegment _currentPath;

    private void OnValidate()
    {
        _levelSystem = FindObjectOfType<LevelSystem>();
    }

    private void OnEnable()
    {
        _pencilFollower.FollowEnded += OnFollowEnded;
    }

    private void OnDisable()
    {
        _pencilFollower.FollowEnded -= OnFollowEnded;
    }

    private void Update()
    {
        Check();
    }

    private void Check()
    {
        _currentPath = _pencilFollower.MovementSystem.CurrentRoad;

        if (_currentPath != null)
        {

            if (_pencilFollower.LineSystemPencilsCount.IsEmpty)
            {
                _pencilFollower.EndMove();
                _levelSystem?.InvokeLose();
                enabled = false;
                return;
            }

            List<Pencil> pencils = _pencilFollower.LineSystemPencilsCount.Pencils;

            for (int i = 0; i < pencils.Count; i++)
                if (pencils[i] != null)
                    if (Mathf.Abs(pencils[i].transform.position.x - _currentPath.GetPointAtDistance(_pencilFollower.MovementSystem.DistanceTravaled).x) > _currentPath.Width)
                        if (pencils[i].transform.position.x - _currentPath.GetPointAtDistance(_pencilFollower.MovementSystem.DistanceTravaled).x > 0)
                            _pencilFollower.LineSystemPencilsCount.RemoveDroppedPencil(pencils[i], false);
                        else
                            _pencilFollower.LineSystemPencilsCount.RemoveDroppedPencil(pencils[i], true);
        }
    }

    private void OnFollowEnded()
    {
        enabled = false;
    }
}
