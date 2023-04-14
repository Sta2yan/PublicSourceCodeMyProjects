using UnityEngine;
using UnityEngine.Audio;

public class GamePause : MonoBehaviour
{
    private const string MasterVolume = "MasterVolume";

    [SerializeField] private AudioMixerGroup _audioMixer;

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
            ContinueGame();
        else
            PauseGame();
    }

    public void PauseGame()
    {
        SetPause(0);
    }

    public void ContinueGame()
    {
        SetPause(1);
    }

    public void ContinueGame(bool isClose)
    {
        SetPause(1);
    }

    private void SetPause(float timeScale)
    {
        Time.timeScale = timeScale;
        float minVolume = 80;

        if (timeScale == 0)
        {
            _audioMixer.audioMixer.SetFloat(MasterVolume, -minVolume);
        }
        else
        {
            float volume = (SaveSystem.GlobalMusicValue - 1) * minVolume;
            _audioMixer.audioMixer.SetFloat(MasterVolume, volume);
        }
    }
}
