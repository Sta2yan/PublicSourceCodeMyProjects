using System;
using UnityEngine;

public class CountUpgrade : MonoBehaviour
{
    [SerializeField] private UpgradePanel _panel;

    public Action IncreasedLevel;

    private void Awake()
    {
        UpdateValues();
    }

    private void OnEnable()
    {
        _panel.Upgrader.CountChanged += OnChanged;
        _panel.Upgrader.Updated += UpdateValues;
    }

    private void OnDisable()
    {
        _panel.Upgrader.CountChanged -= OnChanged;
        _panel.Upgrader.Updated -= UpdateValues;
    }

    private void OnChanged()
    {
        if (SaveSystem.CurrentMoney >= SaveSystem.Upgrader.CountUpgradeCost)
            SaveSystem.CurrentMoney -= SaveSystem.Upgrader.CountUpgradeCost;

        SaveSystem.Upgrader.CountUpgradeLevel++;
        SaveSystem.Upgrader.CountUpgradeCost += _panel.StepCost;
        IncreasedLevel?.Invoke();
        UpdateValues();
    }

    private void UpdateValues()
    {
        _panel.LevelNum.text = SaveSystem.Upgrader.CountUpgradeLevel.ToString();
        _panel.Cost.text = SaveSystem.Upgrader.CountUpgradeCost.ToString();

        if (SaveSystem.Upgrader.CountUpgradeLevel == _panel.MaxLevel)
        {
            _panel.SetInactive();
            return;
        }

        if (SaveSystem.CurrentMoney < SaveSystem.Upgrader.CountUpgradeCost)
            _panel.SetRewardPanel();
    }
}
