using UnityEngine;

public class HumanState : MonoBehaviour
{
    [SerializeField] private State _firstState;
    [SerializeField] private State _changerState;
    [SerializeField] private State _endState;
    [SerializeField] private State _idleState;
    [SerializeField] private State _walkState;
    
    [SerializeField, Min(0)] private float _maxTimeToEndState;
    [SerializeField, Min(0)] private float _minTimeToEndState;

    private State _currentState;
    private float _timeToEndState;
    private float _allTime;
    private bool _isActive;

    private void OnValidate()
    {
        if (_minTimeToEndState > _maxTimeToEndState)
            _minTimeToEndState = _maxTimeToEndState;
    }

    private void Awake()
    {
        _firstState.enabled = false;
        _changerState.enabled = false;
        _endState.enabled = false;
        _idleState.enabled = false;
        _walkState.enabled = false;
    }

    private void OnEnable()
    {
        _firstState.Ended += OnEndWalkState;
        _changerState.Ended += OnChangerStateEnded;
        _endState.Ended += OnEndStateEnded;
        _idleState.Ended += OnEndIdleState;
        _walkState.Ended += OnEndWalkState;
    }

    private void Start()
    {
        Restart();
    }

    private void OnDisable()
    {
        _firstState.Ended -= OnEndWalkState;
        _changerState.Ended -= OnChangerStateEnded;
        _endState.Ended -= OnEndStateEnded;
        _idleState.Ended -= OnEndIdleState;
        _walkState.Ended -= OnEndWalkState;
    }

    private void Update()
    {
        if (_isActive)
        {
            _allTime += Time.deltaTime;

            if (_allTime >= _timeToEndState)
            {
                _isActive = false;

                if (_currentState != null)
                    if (_currentState.enabled == true)
                        _currentState.Exit();
                
                SetNewState(_endState);
                return;
            }
        }
    }

    private void SetTimeToEndState()
    {
        _timeToEndState = UnityEngine.Random.Range(_minTimeToEndState, _maxTimeToEndState);
    }

    private void SetNewState(State newState)
    {   
        if (newState != null)
        {
            if (_currentState != null)
                if (_currentState.enabled == true)
                    _currentState.Exit();

            newState.enabled = true;
            _currentState = newState.Enter();
        }
    }

    private void OnChangerStateEnded()
    {
        SetNewState(_firstState);
    }

    private void OnEndStateEnded()
    {
        SetNewState(_changerState);
        Restart();
    }

    private void OnEndIdleState()
    {
        if(_isActive)
            SetNewState(_walkState);
    }

    private void OnEndWalkState()
    {
        SetNewState(_idleState);
    }

    private void Restart()
    {
        _isActive = true;
        _currentState = _changerState.Enter();
        SetTimeToEndState();
        _allTime = 0;
    }
}
