using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private const string StartTransition = nameof(StartTransition);
    private const string MenuScene = "Menu";

    [SerializeField] private Animator _animator;
    [SerializeField, Min(0)] private float _delayToRestartLevel;
    [SerializeField, Min(0)] private float _delayToNextLevel;

    private Coroutine _loadScene;
    private string _nextScene;

    public event Action SceneNexted;

    private void Awake()
    {
        _animator.gameObject.SetActive(false);
        
        if (SceneManager.GetActiveScene().name != SaveSystem.SaveIndex)
            _loadScene = StartCoroutine(LoadScene(SaveSystem.SaveIndex));
    }

    public void BackToMenu()
    {
        _nextScene = MenuScene;
        Invoke(nameof(NextScene), _delayToNextLevel);
    }

    public void LoseGame()
    {
        Invoke(nameof(RestartlLevel), _delayToRestartLevel);
    }

    public void StartSceneByName(string sceneName, float delay = 0f)
    {
        _nextScene = sceneName;
        Invoke(nameof(NextScene), delay);
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
        _animator.SetTrigger(StartTransition);

        yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0).Length);

        SaveSystem.SaveIndex = sceneName;
        SceneManager.LoadScene(sceneName);
    }

    private void RestartlLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
