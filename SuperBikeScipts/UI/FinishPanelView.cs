using TMPro;
using UnityEngine;

public class FinishPanelView : MonoBehaviour
{
    private const int PlusPostionNumber = 1;

    [SerializeField] private TMP_Text _position;
    [SerializeField] private PositionChecker _positionChecker;
    [SerializeField] private Finish _finish;

    private void OnValidate()
    {
        _finish = FindObjectOfType<Finish>();
        _positionChecker = FindObjectOfType<PositionChecker>();
    }

    private void Awake()
    {
        _finish.Finished += OnFinished;
    }

    private void OnDisable()
    {
        _finish.Finished -= OnFinished;
    }

    private void OnFinished()
    {
        _position.text = (_positionChecker.PlayerPosition + PlusPostionNumber).ToString();
    }
}
