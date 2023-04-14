using UnityEngine;
using YG;

public class HardmodeChecker : MonoBehaviour
{
    [SerializeField] private int _levelsComplete = 12;
    [SerializeField] private GameObject _blockPanel;

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    private void Start()
    {
        if (YandexGame.SDKEnabled)
            GetLoad();
    }

    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void GetLoad()
    {
        if (YandexGame.savesData.LevelComplete < _levelsComplete)
            _blockPanel.SetActive(true);
    }
}
