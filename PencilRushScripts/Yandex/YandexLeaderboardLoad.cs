using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using System;

public class YandexLeaderboardLoad : MonoBehaviour
{
    private const int MaxAmount = 6;
    private const string Player = nameof(Player);
    private const string LeaderboardName = "Leaderboard";

    [SerializeField] private YandexInit _yandex;

    private List<LeaderboardPlayer> _players;

    public IReadOnlyList<LeaderboardPlayer> Players => _players;

    private void OnValidate()
    {
        _yandex = FindObjectOfType<YandexInit>();
    }

    private void OnEnable()
    {
        #if !UNITY_WEBGL || UNITY_EDITOR
            return;
        #endif

        _yandex.PlayerAuthorizated += OnPlayerAuthorizated;
    }

    private void OnDisable()
    {
        #if !UNITY_WEBGL || UNITY_EDITOR
            return;
        #endif

        _yandex.PlayerAuthorizated -= OnPlayerAuthorizated;
    }

    private void OnPlayerAuthorizated()
    {
        _players = new List<LeaderboardPlayer>();

        Leaderboard.GetEntries(LeaderboardName, (result) =>
        {
            for (int i = 0; i < MaxAmount; i++)
            {
                LeaderboardPlayer leaderboardPlayer = new LeaderboardPlayer();

                string name = result.entries[i].player.publicName;

                if (string.IsNullOrEmpty(name) == false)
                {
                    leaderboardPlayer.SetValue(result.entries[i].rank, name, result.entries[i].score);
                    _players.Add(leaderboardPlayer);
                }
            }
        });
    }
}

public class LeaderboardPlayer
{
    public int Rank { get; private set; }
    public string Name { get; private set; }
    public int Score { get; private set; }

    public void SetValue(int rank, string name, int score)
    {
        Rank = rank;
        Name = name;
        Score = score;
    }
}
