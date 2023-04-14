using TMPro;
using UnityEngine;
using YG;

public class StatisticsPanelView : MonoBehaviour
{
    private const int Double = 2;
    private const int Triple = 3;

    [SerializeField] private LevelReward _levelReward;
    [SerializeField] private TMP_Text _money;
    [SerializeField] private TMP_Text _stars;

    private void OnValidate()
    {
        _levelReward = FindObjectOfType<LevelReward>();
    }

    private void OnEnable()
    {
        _money.text = "$" +_levelReward.GetMoneyOnRace().ToString();
        _stars.text = _levelReward.GetStarsOnRace().ToString();
    }

    public void ClaimReward()
    {
        YandexGame.RewVideoShow(0);
        YandexGame.savesData.Money += _levelReward.GetMoneyOnRace() * Double;
        _money.text = "$" + (_levelReward.GetMoneyOnRace() * Triple).ToString();
        YandexGame.SaveProgress();
    }
}
