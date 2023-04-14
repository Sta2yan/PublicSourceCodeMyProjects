using System.Collections.Generic;
using UnityEngine;

public class HumanModel : MonoBehaviour
{
    private const string Walk = nameof(Walk);
    private const string Clapp = nameof(Clapp);
    private readonly List<string> Idles = new List<string>() { "Idle_1", "Idle_2", "Idle_3" };

    [SerializeField] private Animator _animator;

    private Transform _target;

    private void Update()
    {
        if (_target != null)
        {
            transform.position = _target.position;
            transform.rotation = _target.rotation;
        }
    }

    public HumanModel Init(Transform target)
    {
        _target = target;
        return this;
    }

    public void ChangeWalk()
    {
        _animator.SetTrigger(Walk);
    }

    public void ChangeClapp()
    {
        _animator.SetTrigger(Clapp);
    }

    public void ChangeIdle()
    {
        int index = Random.Range(0, Idles.Count);
        _animator.SetTrigger(Idles[index]);
    }
}
