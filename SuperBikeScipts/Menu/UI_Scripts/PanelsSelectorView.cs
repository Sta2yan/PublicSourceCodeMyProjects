using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsSelectorView : MonoBehaviour
{
    [SerializeField] private List<GameObject> _panels;

    private void Awake()
    {
        List<GameObject> panels = new List<GameObject>();

        for (int i = 1; i < _panels.Count; i++)
            panels.Add(_panels[i]);

        EnablePanel(_panels[0], panels);
    }

    public void Press(GameObject currentPanel)
    {
        List<GameObject> panels = new List<GameObject>();

        for (int i = 0; i < _panels.Count; i++)
            if (_panels[i] != currentPanel)
                panels.Add(_panels[i]);

        EnablePanel(currentPanel, panels);
    }

    private void EnablePanel(GameObject currentPanel, List<GameObject> otherPanels)
    {
        currentPanel.SetActive(true);

        for (int i = 0; i < otherPanels.Count; i++)
            otherPanels[i].SetActive(false);
    }
}
