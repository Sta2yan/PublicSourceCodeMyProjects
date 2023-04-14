using System;
using TMPro;
using UnityEngine;
using YG;

public class LevelInfoView : MonoBehaviour
{
    [SerializeField] private int _numLevel;
    [SerializeField] private TMP_Text _timeTotal;
    [SerializeField] private TMP_Text _timeBest;

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    private void Start()
    {
        if (YandexGame.SDKEnabled)
            GetLoad();
    }

    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void GetLoad()
    {
        SetTime(_timeTotal, YandexGame.savesData.PlayerTotalTimes[_numLevel]);
        SetTime(_timeBest, YandexGame.savesData.PlayerBestTimes[_numLevel]);
    }

    private void SetTime(TMP_Text textField, float time)
    {
        int rightPadding = 3;
        int leftPadding = 2;
        float miliseconds;
        int seconds;
        int minuts;
        TimeConversion(time, out miliseconds, out seconds, out minuts);
        textField.text =
            $"{minuts.ToString().PadLeft(leftPadding, '0')}" +
            $":{seconds.ToString().PadLeft(leftPadding, '0')}" +
            $":{miliseconds.ToString().PadRight(rightPadding, '0')}";
    }

    private void TimeConversion(float time, out float miliseconds, out int seconds, out int minuts)
    {
        int midPoint = 3;
        miliseconds = (float)Math.Round((time % 1), midPoint) * 1000;
        seconds = (int)time;
        minuts = seconds / 60;
        seconds -= minuts * 60;
    }
}
