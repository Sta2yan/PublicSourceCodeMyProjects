public class StatisticsLeader
{
    private string _name;
    private float _times;
    private float _bestTime;

    public string Name => _name;
    public float Times => _times;
    public float BestTime => _bestTime;

    public StatisticsLeader(string name, float times, float bestTime)
    {
        _name = name;
        _times = times;
        _bestTime = bestTime;
    }
}
