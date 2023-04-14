using UnityEngine;

public class TutorialCursorActivator : MonoBehaviour
{
    [SerializeField] private GameObject _cursor;
    [SerializeField] private float _delay;
    [SerializeField] private ShooterInteractivePicture _shooter;

    private float _currentTime;

    private void Awake()
    {
        _cursor.SetActive(false);
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_shooter.IsActive)
        {
            if (Input.GetMouseButton(0))
            {
                _currentTime = 0f;
                _cursor.SetActive(false);
            }

            if (_currentTime >= _delay)
                _cursor.SetActive(true);
        }
    }
}
