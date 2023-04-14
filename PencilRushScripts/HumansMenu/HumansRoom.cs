using System.Collections.Generic;
using UnityEngine;

public class HumansRoom : MonoBehaviour
{
    [SerializeField] private List<PictureOpener> _pictures;
    [SerializeField] private List<HumanState> _humans;

    private void OnEnable()
    {
        for (int i = 0; i < _pictures.Count; i++)
            _pictures[i].Opened += OnOpened;
    }

    private void Start()
    {
        Activate();
    }

    private void OnDisable()
    {
        for (int i = 0; i < _pictures.Count; i++)
            _pictures[i].Opened -= OnOpened;
    }

    private void Activate()
    {
        for (int i = 0; i < _pictures.Count; i++)
            if (_pictures[i].IsOpen)
                _humans[i].gameObject.SetActive(true);
    }

    private void OnOpened()
    {
        var indexPicture = _pictures.FindIndex(picture => picture.IsOpen == false);
        _humans[indexPicture].gameObject.SetActive(true);
    }
}
