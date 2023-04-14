using UnityEngine;

public class PictureCanvasActivator : MonoBehaviour
{
    [SerializeField] private LevelSystem _levelSystem;
    [SerializeField] private GameObject _picture;
    [SerializeField] private GameObject _whiteScreen;

    private void OnValidate()
    {
        _levelSystem = FindObjectOfType<LevelSystem>(true);
    }

    private void Awake()
    {
        if (_levelSystem.IsFinished == false)
        {
            _picture.SetActive(false);
            _whiteScreen.SetActive(false);
        }
        else
        {
            OnEnded();
        }
    }

    private void OnEnable()
    {
        _levelSystem.Finished += OnEnded;
    }

    private void OnDisable()
    {
        _levelSystem.Finished -= OnEnded;
    }

    private void OnEnded()
    {
        _picture.SetActive(true);
        _whiteScreen.SetActive(true);
    }
}
