using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GamePause _gamePause;
    [SerializeField] private GameObject _pausePanel;

    private void OnValidate()
    {
        _gamePause = FindObjectOfType<GamePause>();
    }

    public void ActivePause()
    {
        _pausePanel.SetActive(true);
        _gamePause.PauseGame();
    }

    public void DisablePause()
    {
        _gamePause.ContinueGame();
        _pausePanel.SetActive(false);
    }
}
