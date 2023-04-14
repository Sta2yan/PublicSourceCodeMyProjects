using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    private const string Enable = "LevelSelectorButton";

    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _blockPanel;
    [SerializeField] private Button _button;
    [SerializeField] private Animator _animator;

    public void UnlockPanel()
    {
        _panel.SetActive(true);
    }

    public void Unlock()
    {
        UnlockPanel();
        _button.interactable = true;
        _blockPanel.SetActive(false);
    }

    public void PlayAnim()
    {
        _animator.Play(Enable);
    }
}
