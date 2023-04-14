using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelLoader))]
public class LevelSelector : MonoBehaviour
{
    [SerializeField] private List<string> _sceneNames;

    private LevelLoader _loader;

    private void Awake()
    {
        _loader = GetComponent<LevelLoader>();
    }

    public void LoadNextScene(float delay)
    {
        _loader.StartSceneByName(GetNextScene(), delay);
    }

    private string GetNextScene()
    {
        if (SaveSystem.CurrentLevel < _sceneNames.Count)
            if (SaveSystem.CurrentLevel < SaveSystem.CountLevel)
                SaveSystem.CurrentLevel++;

        SaveSystem.CountLevel++;

        if (SaveSystem.CurrentLevel < _sceneNames.Count)
            return _sceneNames[SaveSystem.CurrentLevel];
        else
            return _sceneNames[UnityEngine.Random.Range(1, _sceneNames.Count)];
    }
}
