using UnityEngine;
using YG;

public class HardmodeChangerPanel : MonoBehaviour
{
    [SerializeField] private GameObject _firstPanel;
    [SerializeField] private GameObject _firstButton;
    [SerializeField] private GameObject _secondPanel;
    [SerializeField] private GameObject _secondButton;

    private void OnEnable()
    {
        if (YandexGame.savesData.IsHardmode == false)
        {
            _firstPanel.SetActive(true);
            _firstButton.SetActive(true);
            _secondPanel.SetActive(false);
            _secondButton.SetActive(false);
        }
        else
        {
            _firstPanel.SetActive(false);
            _firstButton.SetActive(false);
            _secondPanel.SetActive(true);
            _secondButton.SetActive(true);
        }
    }
}
