using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    [SerializeField] private List<TargetHuman> _targets;
    [SerializeField] private float _speed;
    [SerializeField] private HumanChanger _humanChanger;

    private TargetHuman _currentTarget;

    private void OnEnable()
    {
        var freeTargets = _targets.FindAll(target => target.IsFree);

        if (freeTargets.Count > 0)
            freeTargets = _targets.FindAll(target => target.IsFree);

        if (freeTargets.Count > 0)
            _currentTarget = freeTargets[UnityEngine.Random.Range(0, freeTargets.Count)].Enter();
        else
            Exit();
    }

    private void Update()
    {
        if (_currentTarget != null)
        {
            if (transform.position != _currentTarget.transform.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, _currentTarget.transform.position, _speed * Time.deltaTime);
                transform.LookAt(new Vector3(_currentTarget.transform.position.x, transform.position.y, _currentTarget.transform.position.z));
            }
            else
            {
                Exit();
            }
        }
    }

    protected override void EnterLogic()
    {
        _humanChanger.ChangeAnim(this);
    }
}
