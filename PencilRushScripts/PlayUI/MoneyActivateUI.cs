using System.Collections;
using UnityEngine;

public class MoneyActivateUI : MonoBehaviour
{
    [SerializeField] private MoneyAnimation _moneyPrefab;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private Transform _target;
    [SerializeField, Min(0)] private float _delay;
    [SerializeField, Min(0)] private int _maxMoney;
    [SerializeField, Min(0)] private int _minMoney;

    private WaitForSeconds _sleep;
    private int _count;

    public float Delay => _delay;
    public float Count => _count;

    private void OnValidate()
    {
        if (_maxMoney < _minMoney)
            _maxMoney = _minMoney;
    }

    private void Awake()
    {
        _sleep = new WaitForSeconds(_delay);
    }

    public void Enable()
    {
        StartCoroutine(nameof(Spawn));
    }

    public void MultiplyEnable(int multiply)
    {
        _maxMoney *= multiply;
        _minMoney *= multiply;
        StartCoroutine(nameof(Spawn));
    }

    private IEnumerator Spawn()
    {
        int count = UnityEngine.Random.Range(_minMoney, _maxMoney + 1);
        _count = count;

        for (int i = 0; i < count; i++)
        {
            var template = Instantiate(_moneyPrefab, _spawnPosition.transform).Init(_target);
            template.transform.position = new Vector3(template.transform.position.x, template.transform.position.y, transform.position.z);
            yield return _sleep;
        }
    }
}
