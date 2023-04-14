using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class LevelLoader : MonoBehaviour
{
    private const string MenuScene = "Garage";

    [SerializeField] private GamePause _gamePause;
    [SerializeField] private Animator _animator;
    [SerializeField, Min(0)] private float _timeLoad;
    [SerializeField, Min(0)] private float _delayToRestartLevel;
    [SerializeField, Min(0)] private float _delayToNextLevel;

    private Coroutine _loadScene;
    private string _nextScene;

    public event Action SceneNexted;

    private void OnValidate()
    {
        _gamePause = FindObjectOfType<GamePause>();
    }

    private void Awake()
    {
        _animator.gameObject.SetActive(false);
    }

    public void StartSceneByName(string sceneName)
    {
        YandexGame.FullscreenShow();
        _nextScene = sceneName;
        NextScene();
    }

    public void BackToMenu()
    {
        _nextScene = MenuScene;
        Invoke(nameof(NextScene), _delayToNextLevel);
    }

    public void LoseGame()
    {
        YandexGame.FullscreenShow();
        Invoke(nameof(RestartlLevel), _delayToRestartLevel);
    }

    private void TurnOnPause()
    {
        _gamePause.PauseGame();
    }

    private void TurnOffPause()
    {
        _gamePause.ContinueGame();
    }

    private void NextScene()
    {
        if (_loadScene != null)
            return;

        SceneNexted?.Invoke();
        StopAllCoroutines();
        _loadScene = StartCoroutine(LoadScene(_nextScene));
    }

    private IEnumerator LoadScene(string sceneName)
    {
        _animator.gameObject.SetActive(true);

        yield return new WaitForSeconds(_timeLoad);

        SceneManager.LoadScene(sceneName);
    }

    private void RestartlLevel()
    {
        _loadScene = StartCoroutine(LoadScene(SceneManager.GetActiveScene().name));
    }
}
