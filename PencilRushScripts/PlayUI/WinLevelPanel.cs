using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinLevelPanel : MonoBehaviour
{
    private const int Multiply = 3;

    [SerializeField] private LevelSystem _levelSystem;
    [SerializeField] private GameObject _panel;
    [SerializeField] private TMP_Text _levelNumber;
    [SerializeField] private Button _reward;
    [SerializeField] private TMP_Text _moneyWon;
    [SerializeField] private TMP_Text _rewardMoney;
    [SerializeField] private TMP_Text _currentMoney;

    private void OnValidate()
    {
        _levelSystem = FindObjectOfType<LevelSystem>();
    }

    private void Awake()
    {
        _panel.SetActive(false);
        _levelNumber.text = SaveSystem.CountLevel.ToString();
    }

    private void Start()
    {
        UpdateValues();
    }

    private void OnEnable()
    {
        _reward.onClick.AddListener(InvokeAds);
        UpdateValues();
    }

    private void OnDisable()
    {
        _reward.onClick.RemoveListener(InvokeAds);
    }

    public void Enable(float delay = 0f)
    {
        Invoke(nameof(DelayEnable), delay);
    }

    private void DelayEnable()
    {
        UpdateValues();
        _panel.SetActive(true);
    }

    private void InvokeAds()
    {
        _levelSystem.MultiplyReward(Multiply);
        _levelSystem.InvokeAds();
    }

    private void UpdateValues()
    {
        _moneyWon.text = _levelSystem.RewardLevel.ToString();
        _rewardMoney.text = (_levelSystem.RewardLevel * Multiply).ToString();
    }
}
