using UnityEngine;
using UnityEngine.UI;

public class ButtonAds : MonoBehaviour
{
    [SerializeField] private LevelSystem _levelSystem;
    [SerializeField] private Button _button;

    /*private void OnValidate()
    {
        _levelSystem = FindObjectOfType<LevelSystem>();
    }*/

    private void OnEnable()
    {
        _button.onClick.AddListener(InvokeAds);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(InvokeAds);
    }

    public void GetLevelSystem(LevelSystem levelSystem)
    {
        _levelSystem = levelSystem;
    }

    private void InvokeAds()
    {
        _levelSystem.InvokeAds();
    }
}
