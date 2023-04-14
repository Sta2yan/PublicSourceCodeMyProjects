using System;
using UnityEngine;

public class PaintUpgrade : MonoBehaviour
{
    [SerializeField] private UpgradePanel _panel;

    public Action ChangedPaint;

    private void Awake()
    {
        UpdateValues();
    }

    private void OnEnable()
    {
        _panel.Upgrader.PaintChanged += OnChanged;
        _panel.Upgrader.Updated += UpdateValues;
    }

    private void OnDisable()
    {
        _panel.Upgrader.PaintChanged -= OnChanged;
        _panel.Upgrader.Updated -= UpdateValues;
    }

    private void OnChanged()
    {
        if (SaveSystem.CurrentMoney >= SaveSystem.Upgrader.PaintUpgradeCost)
            SaveSystem.CurrentMoney -= SaveSystem.Upgrader.PaintUpgradeCost;

        SaveSystem.Upgrader.PaintUpgradeLevel++;
        SaveSystem.Upgrader.PaintUpgradeCost += _panel.StepCost;
        ChangedPaint?.Invoke();
        UpdateValues();
    }

    private void UpdateValues()
    {
        _panel.LevelNum.text = SaveSystem.Upgrader.PaintUpgradeLevel.ToString();
        _panel.Cost.text = SaveSystem.Upgrader.PaintUpgradeCost.ToString();

        if (SaveSystem.Upgrader.PaintUpgradeLevel == _panel.MaxLevel)
        {
            _panel.SetInactive();
            return;
        }

        if (SaveSystem.CurrentMoney < SaveSystem.Upgrader.PaintUpgradeCost)
            _panel.SetRewardPanel();
    }
}
