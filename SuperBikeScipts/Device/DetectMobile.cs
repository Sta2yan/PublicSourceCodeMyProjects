using System;
using UnityEngine;
using YG;

public class DetectMobile : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    private void Start()
    {
        if (YandexGame.SDKEnabled)
            GetLoad();
    }

    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void GetLoad()
    {
        if (YandexGame.EnvironmentData.isMobile)
        {
            gameObject.SetActive(false);
        }
    }
}
