using System.Collections.Generic;
using UnityEngine;

public class BikesActivator : MonoBehaviour
{
    [SerializeField] private ArcadeBikeController _player;
    [SerializeField] private AiBikeController _aiPlayer;
    [SerializeField] private AiBikeWaypointProgressTracker _aiProgressPlayer;
    [SerializeField] private TimeCounter _playerTimeCounter;
    [SerializeField] private List<AiBikeController> _bots;

    public void EnableControll()
    {
        _player.enabled = true;

        for (int i = 0; i < _bots.Count; i++)
            _bots[i].enabled = true;
    }

    public void DisableControll()
    {
        _player.enabled = false;

        for (int i = 0; i < _bots.Count; i++)
            _bots[i].enabled = false;
    }

    public void EnableAutoPlayerControll()
    {
        _player.enabled = false;
        _playerTimeCounter.enabled = false;
        _aiPlayer.enabled = true;
        _aiProgressPlayer.enabled = true;
    }
}
