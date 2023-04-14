using System;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [SerializeField, Min(0)] private int _rewardLevel;
    [SerializeField] private YandexAds _yandexGameSdk;

    public event Action Started;
    public event Action Finished;
    public event Action<PencilFollower> Finished_Follower;
    public event Action Lose;
    public event Action Win;
    public event Action Ads;

    private int _reward;

    public bool IsFinished { get; private set; }
    public int RewardLevel => _reward;

    private void OnValidate()
    {
        _yandexGameSdk = FindObjectOfType<YandexAds>();
    }

    private void Awake()
    {
        _reward = _rewardLevel;
    }

    public void InvokeStart()
    {
        Started?.Invoke();
    }

    public void InvokeFinish()
    {
        Finished?.Invoke();
        IsFinished = true;
    }

    public void InvokeFinish(PencilFollower follower)
    {
        Finished_Follower?.Invoke(follower);
    }

    public void InvokeLose()
    {
        Lose?.Invoke();
    }

    public void InvokeWin()
    {
        Win?.Invoke();
    }

    public void InvokeAds()
    {
        _yandexGameSdk.ShowRewardAds();
        Ads?.Invoke();
    }

    public void MultiplyReward(int multiply)
    {
        _reward *= multiply;
    }

    public void AddReward(int count)
    {
        if (count >= 0)
            _reward += count;
    }
}
