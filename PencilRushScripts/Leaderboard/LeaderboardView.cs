using TMPro;
using UnityEngine;

public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private TMP_Text _rank;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _score;

    public void Render(LeaderboardPlayer player)
    {
        _rank.text = player.Rank.ToString();

        if (player.Rank == 0)
            _rank.text = "-";

        _name.text = player.Name;
        _score.text = player.Score.ToString();
    }
}
