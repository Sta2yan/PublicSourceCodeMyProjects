using UnityEngine;

public class DisableObjectByTime : MonoBehaviour
{
    public void StartDisable(float time)
        => Invoke(nameof(Disable), time);

    private void Disable()
        => gameObject.SetActive(false);
}
