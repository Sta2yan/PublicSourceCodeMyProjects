using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class EndLevelPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private const string DrawEndTitle = "поздравляем 100$";
    private const string DrawStartTitle = "нажми, чтобы рисовать";

    [SerializeField] private GameObject _panel;
    [SerializeField] private LevelSystem _levelSystem;
    [SerializeField] private InteractrivePictureSpawner _picture;
    [SerializeField] private TMP_Text _title;

    private bool _isPressed;

    public bool IsPressed => _isPressed;

    private void OnValidate()
    {
        _levelSystem = FindObjectOfType<LevelSystem>();
        _picture = FindObjectOfType<InteractrivePictureSpawner>();
    }

    private void Awake()
    {
        _panel.SetActive(false);
    }

    private void OnEnable()
    {
        _levelSystem.Finished += OnEnded;
        _picture.DrawEnded += OnDrawEnded;
        _picture.Interactived += OnInteractived;
    }

    private void OnDisable()
    {
        _levelSystem.Finished -= OnEnded;
        _picture.DrawEnded -= OnDrawEnded;
        _picture.Interactived -= OnInteractived;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPressed = false;
    }

    private void OnEnded()
    {
        _panel.SetActive(true);
    }

    private void OnDrawEnded()
    {
        _title.text = DrawEndTitle;
    }

    private void OnInteractived()
    {
        _title.text = DrawStartTitle;
    }
}
