using TMPro;
using UnityEngine;
using YG;

public class ProfilePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;
    [SerializeField] private TMP_Text _stars;
    [SerializeField] private TMP_Text _champion;
    [SerializeField] private TMP_Text _race;

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    private void Start()
    {
        if (YandexGame.SDKEnabled)
            GetLoad();
    }

    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void GetLoad()
    {
        _money.text = "$" + YandexGame.savesData.Money.ToString();
        _stars.text = YandexGame.savesData.Stars.ToString();
        _champion.text = YandexGame.savesData.Champion.ToString();
        _race.text = YandexGame.savesData.Race.ToString();
    }
}
