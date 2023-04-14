using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TargetHuman : MonoBehaviour
{
    public bool IsFree { get; private set; } = true;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out HumanState human))
            IsFree = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out HumanState human))
            IsFree = true;
    }

    public TargetHuman Enter()
    {
        IsFree = false;
        return this;
    }
}
