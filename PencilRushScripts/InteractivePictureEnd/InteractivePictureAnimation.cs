using UnityEngine;

[RequireComponent(typeof(InteractivePictureEnd), typeof(Animator))]
public class InteractivePictureAnimation : MonoBehaviour
{
    private const string End = nameof(End);

    private InteractivePictureEnd _picture;
    private Animator _animator;

    private void Awake()
    {
        _picture = GetComponent<InteractivePictureEnd>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _picture.DrawEnded += OnDrawEnded;
    }

    private void OnDisable()
    {
        _picture.DrawEnded -= OnDrawEnded;
    }

    private void OnDrawEnded()
    {
        Invoke(nameof(PlayEndAnim), SaveSystem.DelayWin);
    }

    private void PlayEndAnim()
    {
        _animator.SetTrigger(End);
    }
}
