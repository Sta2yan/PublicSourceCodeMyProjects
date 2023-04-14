using UnityEngine;

public class IdleState : State
{
    [SerializeField] private Transform _targetLook;
    [SerializeField, Min(0)] private float _maxTime;
    [SerializeField, Min(0)] private float _minTime;
    [SerializeField] private ParticleSystem _emoji;
    [SerializeField] private HumanChanger _humanChanger;

    private float _currentTime;
    private bool _isActive;
    private float _time;

    private void OnValidate()
    {
        if (_minTime > _maxTime)
            _minTime = _maxTime;
    }

    private void Update()
    {
        if (_isActive)
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= _time)
                Exit();

            transform.LookAt(new Vector3(_targetLook.position.x, transform.position.y, _targetLook.position.z));
        }
    }

    protected override void EnterLogic()
    {
        Restrart();
        _humanChanger.ChangeAnim(this);
    }

    protected override void ExitLogic()
    {
        _isActive = false;
    }

    private void SetTime()
    {
        _time = UnityEngine.Random.Range(_minTime, _maxTime);
    }

    private void TryPlayEmoji()
    {
        int emojiSetter = UnityEngine.Random.Range(0, 2);

        if (emojiSetter == 0)
            _emoji.Play();
    }

    private void Restrart()
    {
        SetTime();
        TryPlayEmoji();
        _currentTime = 0;
        _isActive = true;
    }
}
