using System;
using UnityEngine;
using YG;

public class Tutorial : MonoBehaviour
{
    private const int LevelThird = 3;

    [SerializeField] private GameObject _tutorialPanel;
    [SerializeField] private GameObject _firstPanel;
    [SerializeField] private GameObject _secondPanel;

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    private void Start()
    {
        if (YandexGame.SDKEnabled)
            GetLoad();
    }

    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void GetLoad()
    {
        if (YandexGame.savesData.FirstTutorial == false)
        {
            _tutorialPanel.SetActive(true);
            _firstPanel.SetActive(true);
        }
        else if (YandexGame.savesData.SecondTutorial == false && YandexGame.savesData.LevelComplete == LevelThird)
        {
            _tutorialPanel.SetActive(true);
            _secondPanel.SetActive(true);
        }
    }

    public void EndFirstTutorial()
    {
        _firstPanel.SetActive(false);
        YandexGame.savesData.FirstTutorial = true;
        _tutorialPanel.SetActive(false);
    }

    public void EndSecondTutorial()
    {
        _secondPanel.SetActive(false);
        YandexGame.savesData.SecondTutorial = true;
        _tutorialPanel.SetActive(false);
    }
}
