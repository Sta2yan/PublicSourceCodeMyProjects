using UnityEngine;
using UnityEngine.UI;

public class BonusLevelPanel : MonoBehaviour
{
    [SerializeField] private LevelSystem _levelSystem;
    [SerializeField] private GameObject _panel;
    [SerializeField] private PencilCase _bonus;
    [SerializeField] private Button _reward;
    [SerializeField] private Button _skip;

    public bool IsUsed { get; private set; }

    private void OnValidate()
    {
        _bonus = FindObjectOfType<PencilCase>();
        _levelSystem = FindObjectOfType<LevelSystem>();
    }

    private void Awake()
    {
        _panel.SetActive(false);
    }

    private void OnEnable()
    {
        _reward.onClick.AddListener(ActiveCase);
        _skip.onClick.AddListener(DisableCase);
    }

    private void OnDisable()
    {
        _reward.onClick.RemoveListener(ActiveCase);
        _skip.onClick.RemoveListener(DisableCase);
    }

    public void Enable()
    {
        _panel.SetActive(true);
    }
    
    public void Disable()
    {
        _panel.SetActive(false);
    }

    private void ActiveCase()
    {
        IsUsed = true;
        _bonus.OpenCase();
        _levelSystem.InvokeAds();
    }

    private void DisableCase()
    {
        _bonus.gameObject.SetActive(false);
    }
}
