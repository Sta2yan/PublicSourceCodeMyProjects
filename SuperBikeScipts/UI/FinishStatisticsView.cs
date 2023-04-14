using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;

public class FinishStatisticsView : MonoBehaviour
{
    private const float MaxRangeBestLapTime = 4f;
    private const float MinRangeBestLapTime = 2f;
    private const float MaxRangeTotalTime = 8f;
    private const float MinRangeTotalTime = 5f;
    private const float CreateDelay = .3f;

    [SerializeField] private List<UILiderView> _leaders;
    [SerializeField] private Finish _finish;
    [SerializeField] private LeaderStatsPanel _leaderPrefab;
    [SerializeField] private Transform _container;

    private List<StatisticsLeader> _stats = new List<StatisticsLeader>();
    private StatisticsLeader _player;

    public bool IsPlayerFirst { get { return _player == _stats[0]; } }
    public bool IsPlayerSecond { get { return _player == _stats[1]; } }
    public bool IsPlayerThird { get { return _player == _stats[2]; } }
    public float PlayerTimeTotal { get { return _player.Times; } }
    public float PlayerTimeBest { get { return _player.BestTime; } }

    private void OnEnable()
    {
        _finish.Finished += OnFinished;
    }

    private void OnDisable()
    {
        _finish.Finished -= OnFinished;
    }

    private void OnFinished()
    {
        Render();
    }

    private void Render()
    {
        UILiderView player = _leaders[0];

        for (int i = 0; i < _leaders.Count; i++)
        {
            if (_leaders[i].DistanceCounterRiders.Lap <= _finish.MaxLap)
            {
                if (_leaders[i].TimeCounterRacer.TimeBestLap == 0f)
                    _leaders[i].TimeCounterRacer.TimeBestLap = player.TimeCounterRacer.TimeBestLap + Random.Range(MinRangeBestLapTime, MaxRangeBestLapTime);

                _leaders[i].TimeCounterRacer.TimeTotal = (_leaders[i].TimeCounterRacer.TimeBestLap + Random.Range(MinRangeTotalTime, MaxRangeTotalTime)) * _finish.MaxLap;

                player = _leaders[i];
            }
            _stats.Add(new StatisticsLeader(_leaders[i].Name, _leaders[i].TimeCounterRacer.TimeTotal, _leaders[i].TimeCounterRacer.TimeBestLap));
        }

        _player = _stats[0];

        _stats = _stats.OrderBy(a => a.Times).ToList();
    }

    public void PressCreate()
    {
        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        var delay = new WaitForSeconds(CreateDelay);

        for (int i = 0; i < _stats.Count; i++)
        {
            Instantiate(_leaderPrefab, _container).View((i + 1).ToString(), _stats[i].Name, _stats[i].Times, _stats[i].BestTime);
            yield return delay;
        }
    }
}
