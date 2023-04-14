using UnityEngine;
using YG;

public class RewardPanel : MonoBehaviour
{
    private const int MinusLevelNumber = 1;

    [SerializeField] private GameObject _preHardmodeItem;
    [SerializeField] private GameObject _hardmodeItem;
    [SerializeField] private FinishStatisticsView _finishStatisticsView;
    [SerializeField] private LevelReward _levelReward;

    private void OnValidate()
    {
        _levelReward = FindObjectOfType<LevelReward>();
    }

    private void OnEnable()
    {
        if (YandexGame.SDKEnabled)
        {
            if (_finishStatisticsView.IsPlayerFirst == false || YandexGame.savesData.LevelComplete - MinusLevelNumber != _levelReward.NumLevel)
                gameObject.SetActive(false);

            if (YandexGame.savesData.IsHardmode == false)
            {
                _preHardmodeItem.SetActive(true);
                _hardmodeItem.SetActive(false);
            }
            else
            {
                _preHardmodeItem.SetActive(false);
                _hardmodeItem.SetActive(true);
            }
        }
    }
}
