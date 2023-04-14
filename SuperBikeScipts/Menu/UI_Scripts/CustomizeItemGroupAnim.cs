using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeItemGroupAnim : MonoBehaviour
{
    [SerializeField] private List<GameObject> _items;

    private Coroutine _coroutine;
    private WaitForSeconds _sleep = new WaitForSeconds(.07f);

    private void OnEnable()
    {
        _coroutine = StartCoroutine(StartEnableAnim());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator StartEnableAnim()
    {
        for (int i = 0; i < _items.Count; i++)
            _items[i].SetActive(false);

        for (int i = 0; i < _items.Count; i++)
        {
            _items[i].SetActive(true);
            yield return _sleep;
        }
    }
}
