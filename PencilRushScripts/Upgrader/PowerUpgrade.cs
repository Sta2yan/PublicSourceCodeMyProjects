using System;
using UnityEngine;

public class PowerUpgrade : MonoBehaviour
{
    [SerializeField] private UpgradePanel _panel;

    public Action ChangedPower;

    private void Awake()
    {
        UpdateValues();
    }

    private void OnEnable()
    {
        _panel.Upgrader.PowerChanged += OnChanged;
        _panel.Upgrader.Updated += UpdateValues;
    }

    private void OnDisable()
    {
        _panel.Upgrader.PowerChanged -= OnChanged;
        _panel.Upgrader.Updated -= UpdateValues;
    }

    private void OnChanged()
    {
        if (SaveSystem.CurrentMoney >= SaveSystem.Upgrader.PowerUpgradeCost)
            SaveSystem.CurrentMoney -= SaveSystem.Upgrader.PowerUpgradeCost;

        SaveSystem.Upgrader.PowerUpgradeLevel++;
        SaveSystem.Upgrader.PowerUpgradeCost += _panel.StepCost;
        ChangedPower?.Invoke();
        UpdateValues();
    }

    private void UpdateValues()
    {
        _panel.LevelNum.text = SaveSystem.Upgrader.PowerUpgradeLevel.ToString();
        _panel.Cost.text = SaveSystem.Upgrader.PowerUpgradeCost.ToString();

        if (SaveSystem.Upgrader.PowerUpgradeLevel == _panel.MaxLevel)
        {
            _panel.SetInactive();
            return;
        }

        if (SaveSystem.CurrentMoney < SaveSystem.Upgrader.PowerUpgradeCost)
            _panel.SetRewardPanel();
    }
}
