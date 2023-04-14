using System;
using UnityEngine;
using YG;

public class Finish : MonoBehaviour
{
    [SerializeField] private DistanceCounter _distanceCounter;
    [SerializeField] private SoundSetter _soundSetter;
    [SerializeField] private int _maxLap;
    [SerializeField] private int _maxLapHardmode;

    public event Action Finished;
    public event Action FinalLapReached;

    public int MaxLap => YandexGame.savesData.IsHardmode == false ? _maxLap : _maxLapHardmode;

    private void OnValidate()
    {
        _soundSetter = FindObjectOfType<SoundSetter>();

        if (_distanceCounter == null)
        {
            _distanceCounter = FindObjectOfType<DistanceCounter>();
        }
    }

    private void OnEnable()
    {
        _distanceCounter.ChangedLap += OnChangedLap;
    }

    private void OnDisable()
    {
        _distanceCounter.ChangedLap -= OnChangedLap;
    }

    private void OnChangedLap(int lap)
    {
        if (YandexGame.savesData.IsHardmode == false)
        {
            if (lap == _maxLap + 1)
            {
                Finished?.Invoke();
                _soundSetter.SetVolumeSound(0);
            }

            if (lap == _maxLap)
                FinalLapReached?.Invoke();
        }
        else
        {
            if (lap == _maxLapHardmode + 1)
            {
                Finished?.Invoke();
                _soundSetter.SetVolumeSound(0);
            }

            if (lap == _maxLapHardmode)
                FinalLapReached?.Invoke();
        }
    }
}
