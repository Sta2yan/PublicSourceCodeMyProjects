using UnityEngine;
using YG;

[RequireComponent(typeof(DistanceCounter), typeof(AiBikeController))]
public class BotSpeedChanger : MonoBehaviour
{
    private const float RangeTime = 3f;
    private const float RangeDistance = 5f;
    private const float RangeNormalSpeed = .7f;

    [SerializeField] private float _speed;
    [SerializeField] private float _hardmodeSpeed;
    [SerializeField] private float _timeToChange;

    [Header("Other"), Space(10)]
    [SerializeField] private float _distanceToSpeed;
    [SerializeField] private float _distanceToFreez;
    [SerializeField] private float _distanceToNormalSpeed;
    [SerializeField] private float _distanceToNormalFreez;
    [SerializeField] private float _multiplySpeed;
    [SerializeField] private float _freezSpeed;

    private DistanceCounter _distancePlayer;
    private float _normalSpeed;
    private bool _isAcitve = true;
    private bool _isAcitveFreez = true;
    private DistanceCounter _distanceCounter;
    private AiBikeController _controller;
    private PlayerBike _playerBike;
    private float _currentTime;
    private float _maxSpeed;
    private float _minSpeed;

    private void Awake()
    {
        _playerBike = FindObjectOfType<PlayerBike>();
        _distancePlayer = _playerBike.GetComponent<DistanceCounter>();
        _distanceCounter = GetComponent<DistanceCounter>();
        _controller = GetComponent<AiBikeController>();

        _timeToChange = Random.Range(_timeToChange - RangeTime, _timeToChange + RangeTime);
        _distanceToNormalSpeed = Random.Range(_distanceToNormalSpeed - RangeDistance, _distanceToNormalSpeed + RangeDistance);
        _distanceToFreez = Random.Range(_distanceToFreez - RangeDistance, _distanceToFreez + RangeDistance);
        _freezSpeed = Random.Range(_freezSpeed - RangeDistance, _freezSpeed + RangeDistance);

        if (YandexGame.savesData.IsHardmode == false)
            _normalSpeed = _speed;
        else
            _normalSpeed = _hardmodeSpeed;

        _maxSpeed = _normalSpeed + RangeTime;
        _minSpeed = _normalSpeed - RangeTime;
        _controller.ChangeSpeed(_normalSpeed);
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > _timeToChange)
        {
            _currentTime = 0;
            _timeToChange = Random.Range(_timeToChange - RangeTime, _timeToChange + RangeTime);
            _normalSpeed = RandomChangeSpeed();

            if (_isAcitve && _isAcitveFreez)
                _controller.ChangeSpeed(RandomChangeSpeed());
        }

        CheckSpeed();
        CheckOnSpeed();
        CheckOnFreez();
    }

    private void CheckSpeed()
    {
        if (_distanceCounter.TotalDistance > _distancePlayer.TotalDistance)
            if (_isAcitveFreez)
                _controller.ChangeSpeed(_normalSpeed);
    }

    private void CheckOnSpeed()
    {
        if (_distancePlayer.TotalDistance - _distanceCounter.TotalDistance > _distanceToSpeed)
        {
            if (_isAcitve == true)
            {
                _controller.ChangeSpeed(_normalSpeed + _multiplySpeed, isFast: false);
                _isAcitve = false;
            }
        }

        if (_distancePlayer.TotalDistance - _distanceCounter.TotalDistance < _distanceToNormalSpeed)
        {
            if (_isAcitve == false)
            {
                _controller.ChangeSpeed(_normalSpeed);
                _isAcitve = true;
            }
        }
    }

    private void CheckOnFreez()
    {
        if (_distanceCounter.TotalDistance - _distancePlayer.TotalDistance > _distanceToFreez)
        {
            if (_isAcitveFreez == true)
            {
                _controller.ChangeSpeed(_freezSpeed);
                _isAcitveFreez = false;
            }
        }

        if (_distanceCounter.TotalDistance - _distancePlayer.TotalDistance < _distanceToFreez)
        {
            if (_isAcitveFreez == false)
            {
                _controller.ChangeSpeed(_normalSpeed);
                _isAcitveFreez = true;
            }
        }
    }

    private float RandomChangeSpeed()
    {
        float speed = Random.Range(_normalSpeed - RangeNormalSpeed, _normalSpeed + RangeNormalSpeed);

        if (speed > _maxSpeed)
            speed = _maxSpeed;
        else if (speed < _minSpeed)
            speed = _minSpeed;

        return speed;
    }
}
