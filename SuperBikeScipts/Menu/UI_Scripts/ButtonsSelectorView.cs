using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsSelectorView : MonoBehaviour
{
    private const float MaxAlpha = 1f; 

    [SerializeField] private List<Button> _buttons;
    [SerializeField] private float _transparentAlpha = .61f;

    private void Awake()
    {
        List<Button> buttons = new List<Button>();

        for (int i = 1; i < _buttons.Count; i++)
            buttons.Add(_buttons[i]);

        View(_buttons[0], buttons);
    }

    public void Press(Button button)
    {
        List<Button> buttons = new List<Button>();

        for (int i = 0; i < _buttons.Count; i++)
            if (_buttons[i] != button)
                buttons.Add(_buttons[i]);

        View(button, buttons);
    }

    private void View(Button currentButton, List<Button> otherButtons)
    {
        Color color = currentButton.image.color;
        color.a = MaxAlpha;
        currentButton.image.color = color;

        for (int i = 0; i < otherButtons.Count; i++)
        {
            color = otherButtons[i].image.color;
            color.a = _transparentAlpha;
            otherButtons[i].image.color = color;
        }
    }
}
