using UnityEngine;
using Cinemachine;

public class CompletionLevel : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _endingCam;
    [SerializeField] private Finish _finish;
    [SerializeField] private BikesActivator _bikesActivator;
    [SerializeField] private GameplayPanel _gameplayPanel;
    [SerializeField] private GameObject _finishUI;

    private void OnEnable()
    {
        _finish.Finished += OnFinished;
    }

    private void OnDisable()
    {
        _finish.Finished -= OnFinished;
    }

    private void OnFinished()
    {
        _endingCam.Priority = 13;
        _bikesActivator.EnableAutoPlayerControll();
        _gameplayPanel.Disable();
        Invoke(nameof(Finish), 3f);
    }

    private void Finish()
    {
        _endingCam.Priority = 0;
        _finishUI.SetActive(true);
    }
}
