using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using YG;

public class SettingPanel : MonoBehaviour
{
    private const string Music = nameof(Music);
    private const string Sound = nameof(Sound);

    [SerializeField] private Button _effectsOn;
    [SerializeField] private Button _effectsOff;
    [SerializeField] private Button _musicOn;
    [SerializeField] private Button _musicOff;
    [SerializeField] private AudioMixerGroup _effectsAudioMixer;
    [SerializeField] private AudioMixerGroup _musicAudioMixer;

    private bool isLoad = true;

    private void OnEnable()
    {
        YandexGame.GetDataEvent += GetLoad;
    }

    private void Start()
    {
        if (YandexGame.SDKEnabled)
            GetLoad();
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= GetLoad;
    }

    public void ChangeVolumeEffects(float volume)
    {
        float minVolume = -80;
        float maxVolume = 0;
        _effectsAudioMixer.audioMixer.SetFloat(Sound, Mathf.Lerp(minVolume, maxVolume, volume));
        YandexGame.savesData.GlobalEffectsValue = volume;
        SaveState();
    }

    public void ChangeVolumeMusic(float volume)
    {
        float minVolume = -80;
        float maxVolume = 0;
        _musicAudioMixer.audioMixer.SetFloat(Music, Mathf.Lerp(minVolume, maxVolume, volume));
        YandexGame.savesData.GlobalMusicValue = volume;
        SaveState();
    }

    private void SaveState()
    {
        if (isLoad == false)
        {
            YandexGame.SaveProgress();
        }
    }

    private void GetLoad()
    {
        if (YandexGame.savesData.GlobalEffectsValue == 1)
        {
            _effectsOn.gameObject.SetActive(true);
            _effectsOff.gameObject.SetActive(false);
        }
        else
        {
            _effectsOn.gameObject.SetActive(false);
            _effectsOff.gameObject.SetActive(true);
        }

        if (YandexGame.savesData.GlobalMusicValue == 1)
        {
            _musicOn.gameObject.SetActive(true);
            _musicOff.gameObject.SetActive(false);
        }
        else
        {
            _musicOn.gameObject.SetActive(false);
            _musicOff.gameObject.SetActive(true);
        }

        ChangeVolumeEffects(YandexGame.savesData.GlobalEffectsValue);
        ChangeVolumeMusic(YandexGame.savesData.GlobalMusicValue);
        isLoad = false;
    }
}
