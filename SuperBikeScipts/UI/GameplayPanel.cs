using UnityEngine;

public class GameplayPanel : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _animatorMiniMap;

    public void Enable()
    {
        _animator.Play("OpenUIFast");
        _animatorMiniMap.Play("OpenUIFast");
    }

    public void Disable()
    {
        _animator.Play("CloseUIFast");
        _animatorMiniMap.Play("CloseUIFast");
    }

    public void EnableSlow()
    {
        _animator.Play("OpenUI");
        _animatorMiniMap.Play("OpenUI");
    }

    public void DisableSlow()
    {
        _animator.Play("CloseUI");
        _animatorMiniMap.Play("CloseUI");
    }
}
