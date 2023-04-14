using TMPro;
using UnityEngine;
using YG;

public class InfoPanel : MonoBehaviour
{
    private const string Player = nameof(Player);

    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _money;
    [SerializeField] private TMP_Text _stars;

    private bool IsNeedSetDefaultName => YandexGame.savesData.Name == "" || YandexGame.savesData.Name == "unauthorized" || string.IsNullOrEmpty(YandexGame.savesData.Name);

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    private void Start()
    {
        if (YandexGame.SDKEnabled)
            GetLoad();
    }

    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void GetLoad()
    {
        if (IsNeedSetDefaultName)
            _name.text = Player;
        else
            _name.text = YandexGame.savesData.Name;

        _money.text = "$" + YandexGame.savesData.Money.ToString();
        _stars.text = YandexGame.savesData.Stars.ToString();
    }
}
