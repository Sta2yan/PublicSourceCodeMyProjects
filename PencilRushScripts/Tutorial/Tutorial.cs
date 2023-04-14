using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Tutorial : MonoBehaviour
{
    private const float SlowDown = .1f;

    [SerializeField] private GameObject _panel;
    [SerializeField] private float _delay = .5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PencilFollower follower))
            Enable();
    }

    private void Enable()
    {
        _panel.SetActive(true);
        Time.timeScale = SlowDown;
        Invoke(nameof(Disabe), _delay);
    }

    private void Disabe()
    {
        _panel.SetActive(false);
        Time.timeScale = 1f;
    }
}
