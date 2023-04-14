using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyButtonCustomize : MonoBehaviour
{
    [SerializeField] private List<ItemCostume> _items;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _use;
    [SerializeField] private TMP_Text _used;
    [SerializeField] private TMP_Text _reward;
    [SerializeField] private TMP_Text _rewardCount;
    [SerializeField] private TMP_Text _buy;
    [SerializeField] private TMP_Text _cost;

    private ItemCostume _selectItemCostume;

    public event Action<ItemCostume> Used;
    public event Action<ItemCostume> Rewarded;
    public event Action<ItemCostume> Buy;

    private void Awake()
    {
        _button.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);

        for (int i = 0; i < _items.Count; i++)
            _items[i].Selected += OnSelected;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);

        for (int i = 0; i < _items.Count; i++)
            _items[i].Selected -= OnSelected;
    }

    public void ResetView()
    {
        OnSelected(_selectItemCostume);
    }

    public void ResetView(ItemCostume selectItemCostume)
    {
        _selectItemCostume = selectItemCostume;
        OnSelected(_selectItemCostume);
    }

    private void OnClick()
    {
        if (_selectItemCostume == null)
            return;

        if (_selectItemCostume.IsUnlock || _selectItemCostume.IsFree)
        {
            Used?.Invoke(_selectItemCostume);
            return;
        }

        if (_selectItemCostume.IsReward)
        {
            Rewarded?.Invoke(_selectItemCostume);
            return;
        }

        Buy?.Invoke(_selectItemCostume);

        ResetView();
    }

    private void OnSelected(ItemCostume obj)
    {
        _selectItemCostume = obj;
        _button.gameObject.SetActive(true);
        _button.interactable = true;
        _use.gameObject.SetActive(false);
        _used.gameObject.SetActive(false);
        _reward.gameObject.SetActive(false);
        _rewardCount.gameObject.SetActive(false);
        _buy.gameObject.SetActive(false);
        _cost.gameObject.SetActive(false);

        if (obj.IsUse)
        {
            _used.gameObject.SetActive(true);
            _button.interactable = false;
            return;
        }

        if (obj.IsUnlock || obj.IsFree)
        {
            _use.gameObject.SetActive(true);
            return;
        }

        if (obj.IsReward)
        {
            _reward.gameObject.SetActive(true);
            _rewardCount.gameObject.SetActive(true);
            _rewardCount.text = $"{obj.CurrentCountReward}/{obj.CountReward}";
            return;
        }

        _buy.gameObject.SetActive(true);
        _cost.gameObject.SetActive(true);
        _cost.text = $"$ {obj.Cost}";
    }
}
