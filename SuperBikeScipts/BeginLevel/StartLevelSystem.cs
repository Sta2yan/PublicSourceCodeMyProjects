using Cinemachine;
using System;
using UnityEngine;

public class StartLevelSystem : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _beginCamera;
    [SerializeField] private CinemachineVirtualCamera _startCamera;
    [SerializeField] private GameplayPanel _gameplayPanel;
    [SerializeField] private float _secondToStart;
    [SerializeField] private GameObject _blackPanel;
    [SerializeField] private BikesActivator _bikesActivator;
    [SerializeField] private GameObject _trafficPanel;
    [SerializeField] private GameObject _skipPanel;

    private float _currentTime;
    private bool _isBegin = false;

    public event Action RaceBegined;
    public event Action RaceStarted;

    private void Awake()
    {
        _gameplayPanel.Disable();
        _bikesActivator.DisableControll();
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > _secondToStart)
            if (_isBegin == false)
                BeginRace();
    }

    public void BeginRace()
    {
        RaceBegined?.Invoke();
        _isBegin = true;
        Invoke(nameof(DisableStartCam), 1f);
        Destroy(_beginCamera);
        _blackPanel.SetActive(true);
        Invoke(nameof(EnableUI), 2f);
        Invoke(nameof(EnableTrafficLight), 2f);
        Invoke(nameof(EnableRace), 7f);
        _skipPanel.SetActive(false);
    }

    //public void StartRace()
    //{
    //    RaceStarted.Invoke();
    //    _bikesActivator.EnableControll();
    //}

    private void DisableStartCam()
    {
        _startCamera.m_Priority = 0;
    }

    private void EnableUI()
    {
        _gameplayPanel.EnableSlow();
    }

    private void EnableTrafficLight()
    {
        _trafficPanel.SetActive(true);
    }

    private void EnableRace()
    {
        RaceStarted.Invoke();
        _bikesActivator.EnableControll();
    }
}
