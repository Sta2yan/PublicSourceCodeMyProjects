using System.Collections;
using UnityEngine;

public class FinalLap : MonoBehaviour
{
    [SerializeField] private GameObject _finalPanel;
    [SerializeField] private Finish _finish;

    private void OnValidate()
    {
        _finish = FindObjectOfType<Finish>();
    }

    private void OnEnable()
    {
        _finish.FinalLapReached += OnFinalLapReached;
    }

    private void OnDisable()
    {
        _finish.FinalLapReached -= OnFinalLapReached;
    }

    private void OnFinalLapReached()
    {
        _finalPanel.SetActive(true);
    }
}
