using TMPro;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 0.0f;
    [SerializeField] private float _minSpeedArrowAngle;
    [SerializeField] private float _maxSpeedArrowAngle;

    [Header("UI")]
    [SerializeField] private TMP_Text _speedLabel; 
    [SerializeField] private RectTransform _arrow;

    private float _speed = 0.0f;

    private Rigidbody _target;

    private void Awake()
    {
        _target = FindObjectOfType<PlayerBike>().GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _speed = _target.velocity.magnitude * 3f;

        if (_speedLabel != null)
            _speedLabel.text = ((int)_speed) + " km/h";
        if (_arrow != null)
            _arrow.localEulerAngles =
                new Vector3(0, 0, Mathf.Lerp(_minSpeedArrowAngle, _maxSpeedArrowAngle, _speed / _maxSpeed));
    }
}
