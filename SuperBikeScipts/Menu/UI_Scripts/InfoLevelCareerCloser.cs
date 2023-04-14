using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoLevelCareerCloser : MonoBehaviour
{
    [SerializeField] private List<GameObject> _panels;
    
    public void CloseOther(GameObject go)
    {
        for (int i = 0; i < _panels.Count; i++)
            if (_panels[i] != go)
                _panels[i].SetActive(false);
    }

    public void CloseAll()
    {
        for (int i = 0; i < _panels.Count; i++)
            _panels[i].SetActive(false);
    }
}
