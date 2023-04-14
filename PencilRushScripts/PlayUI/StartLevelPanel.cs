using RunnerMovementSystem;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartLevelPanel : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private RoadSegment _firstRoad;
    [SerializeField] private PencilFollower _follower;
    [SerializeField] private GameObject _tutorialPanel;
    [SerializeField] private LevelSystem _levelSystem;

    private bool _isIntercative = false;

    private void OnValidate()
    {
        _levelSystem = FindObjectOfType<LevelSystem>();
        _follower = FindObjectOfType<PencilFollower>();
    }

    private void Awake()
    {
        _tutorialPanel.SetActive(true);
        _firstRoad.AutoMoveForward = false;
    }

    private void OnEnable()
    {
        _levelSystem.Started += _follower.StartMove;
        Invoke(nameof(EnableInteractive), 0.3f);
    }

    private void OnDisable()
    {
        _levelSystem.Started -= _follower.StartMove;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_isIntercative)
        {
            _firstRoad.AutoMoveForward = true;
            _tutorialPanel.SetActive(false);
            _levelSystem.InvokeStart();
        }
    }

    private void EnableInteractive()
    {
        _isIntercative = true;
    }
}
