using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class MoneyPanelLevel : MonoBehaviour
{
    private const float Delay = 0.007f;

    [SerializeField] private TMP_Text _count;
    [SerializeField] private LevelSystem _levelSystem;
    [SerializeField] private MoneyAnimation _moneyAnimation;
 
    private WaitForSeconds _sleep;

    private void OnValidate()
    {
        _levelSystem = FindObjectOfType<LevelSystem>();
    }

    private void Start()
    {
        _count.text = SaveSystem.CurrentMoney.ToString();
        _sleep = new WaitForSeconds(Delay);
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
        int a = _levelSystem.RewardLevel;

        if (a > 0)
        {
            for (int i = 0; i < a; i++)
            {
                _count.text = (Convert.ToInt32(_count.text) + 1).ToString();

                yield return _sleep;
            }
        }
    }
}
