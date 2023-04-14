using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrader : MonoBehaviour
{
    [SerializeField] private LevelSystem _levelSystem;
    [SerializeField] private TMP_Text _money;
    [SerializeField] private Button _count;
    [SerializeField] private Button _power;
    [SerializeField] private Button _paint;
    [SerializeField] private Button _countReward;
    [SerializeField] private Button _powerReward;
    [SerializeField] private Button _paintReward;

    public event Action CountChanged;
    public event Action PowerChanged;
    public event Action PaintChanged;
    public event Action Updated;

    private void OnValidate()
    {
        _levelSystem = FindObjectOfType<LevelSystem>();
    }

    private void OnEnable()
    {
        _money.text = SaveSystem.CurrentMoney.ToString();
        _count.onClick.AddListener(InvokeCountChanged);
        _power.onClick.AddListener(InvokePowerChanged);
        _paint.onClick.AddListener(InvokePaintChanged);
        _countReward.onClick.AddListener(InvokeReward);
        _countReward.onClick.AddListener(InvokeCountChanged);
        _powerReward.onClick.AddListener(InvokeReward);
        _powerReward.onClick.AddListener(InvokePowerChanged);
        _paintReward.onClick.AddListener(InvokeReward);
        _paintReward.onClick.AddListener(InvokePaintChanged);
    }

    private void OnDisable()
    {
        _count.onClick.RemoveListener(InvokeCountChanged);
        _power.onClick.RemoveListener(InvokePowerChanged);
        _paint.onClick.RemoveListener(InvokePaintChanged);
        _countReward.onClick.RemoveListener(InvokeReward);
        _countReward.onClick.RemoveListener(InvokeCountChanged);
        _powerReward.onClick.RemoveListener(InvokeReward);
        _powerReward.onClick.RemoveListener(InvokePowerChanged);
        _paintReward.onClick.RemoveListener(InvokeReward);
        _paintReward.onClick.RemoveListener(InvokePaintChanged);
    }

    private void InvokeCountChanged()
    {
        CountChanged?.Invoke();
        Updated?.Invoke();
        _money.text = SaveSystem.CurrentMoney.ToString();
    }

    private void InvokePowerChanged()
    {
        PowerChanged?.Invoke();
        Updated?.Invoke();
        _money.text = SaveSystem.CurrentMoney.ToString();
    }

    private void InvokePaintChanged()
    {
        PaintChanged?.Invoke();
        Updated?.Invoke();
        _money.text = SaveSystem.CurrentMoney.ToString();
    }

    private void InvokeReward()
    {
        _levelSystem.InvokeAds();
    }
}
