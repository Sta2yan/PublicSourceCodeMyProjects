using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class YandexInit : MonoBehaviour
{
    private const string LeaderboardName = "Leaderboard";

    public event UnityAction PlayerAuthorizated;
    public event UnityAction Completed;

    public void StartInit()
    {
        StartCoroutine(Init());
    }

    private IEnumerator Init()
    {
        #if !UNITY_WEBGL || UNITY_EDITOR
            yield break;
        #endif

        yield return YandexGamesSdk.Initialize(() => PlayerAccount.RequestPersonalProfileDataPermission());

        Completed?.Invoke();

        Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
        {
            if (result != null)
                PlayerAuthorizated?.Invoke();
        });
    }
}
