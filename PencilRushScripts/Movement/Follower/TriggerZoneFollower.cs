using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TriggerZoneFollower : MonoBehaviour
{
    public event Action Triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PencilFollower follower))
            Triggered?.Invoke();
    }
}
