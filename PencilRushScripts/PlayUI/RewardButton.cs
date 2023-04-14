using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardButton : MonoBehaviour
{
    private const string Dollar = "$";
    private const string YearName = nameof(YearName);
    private const string MounthName = nameof(MounthName);
    private const string DayName = nameof(DayName);
    private const string HourName = nameof(HourName);
    private const string MinuteName = nameof(MinuteName);
    private const string SecondName = nameof(SecondName);
    private const int ScenondsPerMinute = 60;

    [SerializeField, Min(0)] private int _moneyReward;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _reward;
    [SerializeField, Range(0, 60)] private int _callbackSeconds;

    private bool _isActive = false;

    public DateTime CurrentDateTime {
        get
        {
            return new DateTime(PlayerPrefs.GetInt(YearName, DateTime.Now.Year), 
                                                PlayerPrefs.GetInt(MounthName, DateTime.Now.Month), 
                                                PlayerPrefs.GetInt(DayName, DateTime.Now.Day), 
                                                PlayerPrefs.GetInt(HourName, DateTime.Now.Hour), 
                                                PlayerPrefs.GetInt(MinuteName, DateTime.Now.Minute), 
                                                PlayerPrefs.GetInt(SecondName, DateTime.Now.Second));
        }
        set
        {
            PlayerPrefs.SetInt(YearName, value.Year); 
            PlayerPrefs.SetInt(MounthName, value.Month);
            PlayerPrefs.SetInt(DayName, value.Day); 
            PlayerPrefs.SetInt(HourName, value.Hour);
            PlayerPrefs.SetInt(MinuteName, value.Minute);
            PlayerPrefs.SetInt(SecondName, value.Second);
        }
    }

    private void Awake()
    {
        _reward.text = _moneyReward.ToString() + Dollar;
    }

    private void Update()
    {
        if (_isActive == false)
        {
            if (CurrentDateTime.Second > DateTime.Now.Second)
                _reward.text = $"{CurrentDateTime.Second - DateTime.Now.Second}"; 
            else
                _reward.text = $"{ScenondsPerMinute - DateTime.Now.Second + CurrentDateTime.Second}";

            if (DateTime.Now > CurrentDateTime)
                Enable();
        }
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _button.interactable = false;
        _isActive = false;
        SaveSystem.CurrentMoney += _moneyReward;
        SaveSystem.AllMoney += _moneyReward;
        int a = 0;
        int b = _callbackSeconds + DateTime.Now.Second;

        if (b >= ScenondsPerMinute)
        {
            b = _callbackSeconds + DateTime.Now.Second - ScenondsPerMinute;
            a++;
        }

        CurrentDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute + a, b);
    }

    private void Enable()
    {
        _isActive = true;
        _button.interactable = true;
        _reward.text = _moneyReward.ToString() + Dollar;
    }
}
