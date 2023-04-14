using UnityEngine;

public class LevelCanvas : MonoBehaviour
{
    [SerializeField] private LevelLoader _levelLoader;

    private void OnValidate()
    {
        _levelLoader = FindObjectOfType<LevelLoader>();
    }

    public void PressLoseGame()
    {
        _levelLoader.LoseGame();
    }

    public void PressBackToMenu()
    {
        _levelLoader.BackToMenu();
    }
}
