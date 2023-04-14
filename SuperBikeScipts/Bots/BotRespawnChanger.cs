using UnityEngine;

[RequireComponent(typeof(AIRagDoll))]
public class BotRespawnChanger : MonoBehaviour
{
    private const float MaxRange = 2.5f;
    private const float MinRange = -1.5f;

    private AIRagDoll _aIRagDoll;

    private void Awake()
    {
        _aIRagDoll = GetComponent<AIRagDoll>();
        ChangeRespawnTime();
    }

    private void ChangeRespawnTime()
    {
        _aIRagDoll.ChangeTimeReset(Random.Range(_aIRagDoll.TimeReset + MinRange, _aIRagDoll.TimeReset + MaxRange));
    }
}
