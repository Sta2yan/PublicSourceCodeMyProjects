using System;
using UnityEngine;
using YG;

public class DeviceUiChanger : MonoBehaviour
{
    [SerializeField] private GameObject _speedometr;
    [SerializeField] private GameObject _scrollbar;
    [SerializeField] private GameObject _button;

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    private void Start()
    {
        if (YandexGame.SDKEnabled)
            GetLoad();
    }

    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void GetLoad()
    {
        if (YandexGame.EnvironmentData.isMobile == true)
        {
            _speedometr.SetActive(false);
            _scrollbar.SetActive(true);
            _button.SetActive(true);
        }
        else
        {
            _speedometr.SetActive(true);
            _scrollbar.SetActive(false);
            _button.SetActive(false);
        }
    }
}
