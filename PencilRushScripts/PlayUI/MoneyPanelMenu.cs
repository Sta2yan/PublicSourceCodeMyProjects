using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class MoneyPanelMenu : MonoBehaviour
{
    private const float Delay = 0.017f;
    private const int Reward = 50;

    [SerializeField] private TMP_Text _count;
    [SerializeField] private LevelSystem _levelSystem;
    [SerializeField] private MoneyAnimation _moneyAnimation;

    private WaitForSeconds _sleep;

    private void OnValidate()
    {
        _levelSystem = FindObjectOfType<LevelSystem>();
    }

    private void OnEnable()
    {
        SaveSystem.MoneyChanged += OnMoneyChanged;
    }

    private void Start()
    {
        _count.text = SaveSystem.CurrentMoney.ToString();
        _sleep = new WaitForSeconds(Delay);
    }

    private void OnDisable()
    {
        SaveSystem.MoneyChanged -= OnMoneyChanged;
    }

    public void Activate()
    {
        Invoke(nameof(StartAnimCoroutine), _moneyAnimation.Sleep + _moneyAnimation.Duration);
    }

    private void StartAnimCoroutine()
    {
        StartCoroutine(StartAnim());
    }

    private IEnumerator StartAnim()
    {
        int a = SaveSystem.CurrentMoney - Convert.ToInt32(_count.text);

        if (a > 0)
        {
            for (int i = 0; i < a; i++)
            {
                _count.text = (Convert.ToInt32(_count.text) + 1).ToString();

                yield return _sleep;
            }
        }
    }

    private void OnMoneyChanged()
    {
        if (Convert.ToInt32(_count.text) > SaveSystem.CurrentMoney)
            _count.text = SaveSystem.CurrentMoney.ToString();
    }
}
