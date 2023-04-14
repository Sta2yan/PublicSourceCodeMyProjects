using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class UpgradePanel
{
    [SerializeField] private Upgrader _upgrader;
    [SerializeField] private Button _upgrade;
    [SerializeField] private Button _reward;
    [SerializeField] private TMP_Text _inactive;
    [SerializeField] private int _maxLevel;
    [SerializeField] private TMP_Text _levelNum;
    [SerializeField] private int _stepCost;
    [SerializeField] private TMP_Text _cost;

    public Upgrader Upgrader => _upgrader;
    public int MaxLevel => _maxLevel;
    public TMP_Text LevelNum => _levelNum;
    public int StepCost => _stepCost;
    public TMP_Text Cost => _cost;

    public void SetInactive()
    {
        _upgrade.gameObject.SetActive(false);
        _reward.gameObject.SetActive(false);
        _inactive.gameObject.SetActive(true);
    }

    public void SetRewardPanel()
    {
        _upgrade.gameObject.SetActive(false);
        _reward.gameObject.SetActive(true);
    }
}
