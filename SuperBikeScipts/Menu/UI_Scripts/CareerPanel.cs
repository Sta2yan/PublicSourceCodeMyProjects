using System.Collections.Generic;
using UnityEngine;
using YG;

public class CareerPanel : MonoBehaviour
{
    [SerializeField] private List<LevelSelector> _levels;

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    private void Start()
    {
        if (YandexGame.SDKEnabled)
            GetLoad();
    }

    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void GetLoad()
    {
        for (int i = 0; i < YandexGame.savesData.LevelComplete + 1; i++)
            if (i < _levels.Count)
                _levels[i].Unlock();

        if (YandexGame.savesData.LevelComplete < _levels.Count)
            _levels[YandexGame.savesData.LevelComplete].PlayAnim();

        if (YandexGame.savesData.LevelComplete + 1 < _levels.Count)
            _levels[YandexGame.savesData.LevelComplete + 1].UnlockPanel();
    }

    public void EnableHardmode()
    {
        YandexGame.savesData.IsHardmode = true;
    }

    public void DisableHardmode()
    {
        YandexGame.savesData.IsHardmode = false;
    }
}
