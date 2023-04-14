using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListLeaderboardView : MonoBehaviour
{
    [SerializeField] private YandexLeaderboardLoad _leaderboard;
    [SerializeField] private List<LeaderboardView> _leaderboardViews;
    [SerializeField] private TMP_Text _nonAuthorizate;

    private void OnValidate()
    {
        _leaderboard = FindObjectOfType<YandexLeaderboardLoad>();
    }

    private void OnEnable()
    {
        #if !UNITY_WEBGL || UNITY_EDITOR
            return;
        #endif

        RenderAll();
    }

    private void Update()
    {
        #if !UNITY_WEBGL || UNITY_EDITOR
            return;
        #endif

        RenderAll();
    }

    private void RenderAll()
    {
        if (_leaderboard.Players.Count > 0)
        {
            _nonAuthorizate.gameObject.SetActive(false);
            
            for (int i = 0; i < _leaderboardViews.Count; i++)
                if (i < _leaderboard.Players.Count)
                {
                    _leaderboardViews[i].gameObject.SetActive(true);
                    _leaderboardViews[i].Render(_leaderboard.Players[i]);
                }
        }
    }
}
