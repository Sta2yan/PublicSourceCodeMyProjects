using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsCustomizeSelectorView : MonoBehaviour
{
    [SerializeField] private List<Button> _buttons;
    [SerializeField] private List<GameObject> _seletors;

    public IReadOnlyList<Button> Buttons => _buttons;

    public void Press(Button button)
    {
        List<Button> buttons = new List<Button>();
        int index = 0;

        for (int i = 0; i < _buttons.Count; i++)
        {
            if (_buttons[i] != button)
                buttons.Add(_buttons[i]);
            else
                index = i;
        }

        View(index);
    }

    private void View(int index)
    {
        _seletors[index].SetActive(true);

        for (int i = 0; i < _buttons.Count; i++)
            if (i != index)
                _seletors[i].SetActive(false);
    }
}
