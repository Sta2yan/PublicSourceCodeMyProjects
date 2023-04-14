using UnityEngine;

public class TimeFreez : MonoBehaviour
{
    private void OnEnable()
        => Invoke(nameof(SetPause), 1f);

    public void Continue()
        => Time.timeScale = 1f;

    private void SetPause()
        => Time.timeScale = 0f;
}
