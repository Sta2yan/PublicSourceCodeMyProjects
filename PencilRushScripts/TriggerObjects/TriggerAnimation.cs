using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _triggerName;
    [SerializeField] private TriggerZoneFollower _zone;

    private void OnEnable()
    {
        _zone.Triggered += OnTriggered;
    }

    private void OnDisable()
    {
        _zone.Triggered -= OnTriggered;
    }

    private void OnTriggered()
    {
        _animator.SetTrigger(_triggerName);
    }
}
