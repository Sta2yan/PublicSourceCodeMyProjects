using UnityEngine;
using TMPro;

public class LoseLevelPanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private LevelSystem _levelSystem;
    [SerializeField] private TMP_Text _levelNumber;

    private void OnValidate()
    {
        _levelSystem = FindObjectOfType<LevelSystem>();
    }

    private void Awake()
    {
        _panel.SetActive(false);
        _levelNumber.text = SaveSystem.CountLevel.ToString();
    }

    private void OnEnable()
    {
        _levelSystem.Lose += OnLose;
    }

    private void OnDisable()
    {
        _levelSystem.Lose -= OnLose;
    }

    private void OnLose()
    {
        _panel.SetActive(true);
    }
}
