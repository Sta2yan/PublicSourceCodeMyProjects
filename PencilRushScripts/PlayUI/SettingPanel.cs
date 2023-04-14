using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    private const string MasterVolume = "MasterVolume";
    
    [SerializeField] private GameObject _setting;
    [SerializeField] private PencilFollower _follower;
    [SerializeField] private Button _open;
    [SerializeField] private Button _close;
    [SerializeField] private Slider _sliderVolumeMaster;
    [SerializeField] private AudioMixerGroup _audioMixer;
    [SerializeField] private Image _sound;
    [SerializeField] private Sprite _activeSound;
    [SerializeField] private Sprite _inactiveSound;

    private void OnValidate()
    {
        _follower = FindObjectOfType<PencilFollower>();
    }

    private void Start()
    {
        _setting.SetActive(false);
        _sliderVolumeMaster.value = SaveSystem.GlobalMusicValue;
        ChangeVolumeMaster(SaveSystem.GlobalMusicValue);
    }

    private void OnEnable()
    {
        _open.onClick.AddListener(Open);
        _close.onClick.AddListener(Close);
        _sliderVolumeMaster.onValueChanged.AddListener(ChangeVolumeMaster);
    }

    private void OnDisable()
    {
        _open.onClick.RemoveListener(Open);
        _close.onClick.RemoveListener(Close);
        _sliderVolumeMaster.onValueChanged.RemoveListener(ChangeVolumeMaster);
    }

    public void ChangeVolumeMaster(float volume)
    {
        float minVolume = -80;
        float maxVolume = 0;
        _audioMixer.audioMixer.SetFloat(MasterVolume, Mathf.Lerp(minVolume, maxVolume, volume));
        SaveSystem.GlobalMusicValue = volume;

        if (volume > 0)
            _sound.sprite = _activeSound;
        else
            _sound.sprite = _inactiveSound;
    }

    private void Open()
    {
        _setting.SetActive(true);
        _follower.StopMove();
        Time.timeScale = 0;
    }

    private void Close()
    {
        _setting.SetActive(false);
        _follower.StartMove();
        Time.timeScale = 1;
    }
}
