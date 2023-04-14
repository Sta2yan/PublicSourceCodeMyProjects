using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemCostume : MonoBehaviour
{
    [Header("View")]

    [SerializeField] private Button _button;
    [SerializeField] private GameObject _buttonBlock;

    [Header("Setting"), Space(15)]

    [SerializeField] private int _levelToAvailable;
    [SerializeField] private bool _isFree;
    [SerializeField] private bool _isReward;
    [SerializeField] private int _countReward;
    [SerializeField] private int _cost;

    public bool IsUse { get; set; } = false;
    public bool IsUnlock { get; set; }
    public int CurrentCountReward { get; set; } = 0;
    public bool IsFree => _isFree;
    public bool IsReward => _isReward;
    public int CountReward => _countReward;
    public int Cost => _cost;

    public event Action<ItemCostume> Selected;

    private void Awake()
    {
        Check();
    }

    public void Select()
    {
        Selected?.Invoke(this);
    }

    private void Check()
    {
        if (_levelToAvailable <= YG.YandexGame.savesData.LevelComplete)
        {
            _button.interactable = true;
            _buttonBlock.SetActive(false);
        }
        else
        {
            _button.interactable = false;
            _buttonBlock.SetActive(true);
        }
    }
}
