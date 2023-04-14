using System;
using UnityEngine;

public class PencilBonusPanel : MonoBehaviour
{
    private const float Delay = 2f;
    private const string Trigger = nameof(Trigger);

    [SerializeField] private LevelSystem _levelSystem;
    [SerializeField] private GameObject _panel;
    [SerializeField] private PencilBonusSetter _pencilBonusSetter;
    [SerializeField] private Animator _animator;

    private PencilUpgrader _pencil;
    
    public bool IsActive { get; private set; }

    private void OnValidate()
    {
        _levelSystem = FindObjectOfType<LevelSystem>();
        _pencilBonusSetter = FindObjectOfType<PencilBonusSetter>();
    }

    private void Awake()
    {
        _panel.SetActive(false);
    }

    public void Activate(int numberColor)
    {
        IsActive = true;
        _pencilBonusSetter.TakeNumberColor(numberColor);
    }

    public void GetPencil(PencilUpgrader pencilUpgrader)
    {
        _pencil = pencilUpgrader;
    }

    public void Enable()
    {
        _panel.SetActive(true);
        Invoke(nameof(EnablePencil), Delay);
    }

    public void Disable()
    {
        IsActive = false;
        _animator.SetTrigger(Trigger);
        _pencilBonusSetter.Activate(false);
        Invoke(nameof(DisablePanel), Delay);
    }
 
    public void GetReward()
    {
        if (_pencil == null)
            throw new NullReferenceException(nameof(_pencil));

        switch (_pencil.ColorPencil)
        {
            case PencilUpgrader.ColorsObject.Blue:
                SaveSystem.PencilUpgrades.BlueCollect = 1;
                break;
            case PencilUpgrader.ColorsObject.Red:
                SaveSystem.PencilUpgrades.RedCollect = 1;
                break;
            case PencilUpgrader.ColorsObject.Green:
                SaveSystem.PencilUpgrades.GreenCollect = 1;
                break;
            case PencilUpgrader.ColorsObject.Purple:
                SaveSystem.PencilUpgrades.PurpleCollect = 1;
                break;
            case PencilUpgrader.ColorsObject.Yellow:
                SaveSystem.PencilUpgrades.YellowCollect = 1;
                break;
            case PencilUpgrader.ColorsObject.Pink:
                SaveSystem.PencilUpgrades.PinkCollect = 1;
                break;
            case PencilUpgrader.ColorsObject.Orange:
                SaveSystem.PencilUpgrades.OrangeCollect = 1;
                break;
        }

        _levelSystem.InvokeAds();
        Disable();
    }

    private void EnablePencil()
    {
        if (IsActive)
            _pencilBonusSetter.Activate(true);
    }

    private void DisablePanel()
    {
        _panel.SetActive(false);
    }
}
