using UnityEngine;
using DG.Tweening;

public class MoneyAnimation : MonoBehaviour
{
    [SerializeField] private float _sleep;
    [SerializeField] private float _duration = 3f;
    [SerializeField, Min(0)] private float _radiusX;
    [SerializeField, Min(0)] private float _radiusY;

    private Transform _target;

    public float Sleep => _sleep;
    public float Duration => _duration;

    private void OnEnable()
    {
        Invoke(nameof(Move), _sleep);
    }

    public MoneyAnimation Init(Transform target)
    {
        _target = target;
        transform.position = new Vector2(transform.position.x + UnityEngine.Random.Range(-_radiusX / 2, _radiusX / 2),
                                                                 transform.position.y + UnityEngine.Random.Range(-_radiusY / 2, _radiusY / 2));

        return this;
    }

    private void Move()
    {
        if (_target != null)
        {
            transform.DOMove(_target.position, _duration).OnComplete(() =>
            {
                Destroy(gameObject);
            });
        }
    }
}
