using UnityEngine;

public class SwitchWinPanel : MonoBehaviour
{
    [SerializeField] private LevelSystem _levelSystem;
    [SerializeField] private BonusLevelPanel _bonusLevelPanel;
    [SerializeField] private PencilBonusPanel _pencilBonusPanel;
    [SerializeField] private WinLevelPanel _winLevelPanel;
    [SerializeField] private GameObject _endLevelPanel;

    private void OnValidate()
    {
        _levelSystem = FindObjectOfType<LevelSystem>();
    }

    private void OnEnable()
    {
        _levelSystem.Win += OnWin;
    }

    private void OnDisable()
    {
        _levelSystem.Win -= OnWin;
    }

    public void PressSkipBonusLevelPanel(float delay)
    {
        Invoke(nameof(SkipBonusLevelPanel), delay);
    }

    private void SkipBonusLevelPanel()
    {
        _bonusLevelPanel.Disable();

        if (_pencilBonusPanel.IsActive == true)
        {
            _pencilBonusPanel.Enable();
        }
        else
        {
            _winLevelPanel.Enable();
            _endLevelPanel.SetActive(false);
        }
    }

    private void OnWin()
    {
        if (_bonusLevelPanel.IsUsed == false)
        {
            _bonusLevelPanel.Enable();
        }
        else if (_pencilBonusPanel.IsActive == true)
        {
            _pencilBonusPanel.Enable();
        }
        else
        {
            _winLevelPanel.Enable();
            _endLevelPanel.SetActive(false);
        }
    }
}
