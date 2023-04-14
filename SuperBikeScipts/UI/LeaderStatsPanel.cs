using System;
using TMPro;
using UnityEngine;

public class LeaderStatsPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _position;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _times;
    [SerializeField] private TMP_Text _bestTime;

    public void View(string position, string name, float times, float bestTime)
    {
        _position.text = position;
        _name.text = name;
        SetTime(_times, times);
        SetTime(_bestTime, bestTime);
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
