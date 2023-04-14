using UnityEngine;

public class ChangerState : State
{
    [SerializeField] private HumanChanger _humanChanger;
    [SerializeField] private ParticleSystem _emoji;

    protected override void EnterLogic()
    {
        _humanChanger.Change();
        TryPlayEmoji();
        Exit();
    }

    private void TryPlayEmoji()
    {
        int a = UnityEngine.Random.Range(0, 2);

        if (a == 1)
            _emoji.Play();
    }
}
