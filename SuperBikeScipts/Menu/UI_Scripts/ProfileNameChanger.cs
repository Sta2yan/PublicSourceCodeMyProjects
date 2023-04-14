using TMPro;
using UnityEngine;
using YG;

public class ProfileNameChanger : MonoBehaviour
{
    private const string Player = nameof(Player);
    private const int MaxSymbols = 26;

    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TMP_Text _name;

    private void OnEnable()
    {
        _inputField.text = _name.text;
        _inputField.onValueChanged.AddListener(OnValueChange);
    }

    private void OnDisable()
    {
        _inputField.onValueChanged.RemoveListener(OnValueChange);

        if (_inputField.text == "")
        {
            YandexGame.savesData.Name = Player;
            _name.text = Player;
        }

        YandexGame.SaveProgress();
    }

    private void OnValueChange(string message)
    {
        if (message.Length < MaxSymbols)
        {
            YandexGame.savesData.Name = message;
            _name.text = message;
        }
        else
        {
            _inputField.text = _name.text;
        }

        YandexGame.SaveProgress();
    }
}
