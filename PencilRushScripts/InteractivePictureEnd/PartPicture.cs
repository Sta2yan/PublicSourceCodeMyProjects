using DG.Tweening;
using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PartPicture : MonoBehaviour
{
    [SerializeField, Min(1)] private float _countPencilOnPartPaint;
    [SerializeField, Min(0)] private float _duration;

    private SpriteRenderer _sprite;
    private string _pictureName;

    public bool IsPaint => Alpha <= 0;
    public float Alpha { get { return PlayerPrefs.GetFloat(_pictureName, 1f); } private set { PlayerPrefs.SetFloat(_pictureName, value); } }

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _pictureName = gameObject.name;
        Color color = _sprite.color;
        color.a = Alpha;
        _sprite.color = color;
    }

    public void Draw(float paintPercent)
    {
        if (paintPercent < 0)
            throw new ArgumentOutOfRangeException(nameof(paintPercent));
        else if (paintPercent == 0)
            paintPercent = 1;

        Color color = _sprite.color;
        Alpha -= paintPercent / _countPencilOnPartPaint;
        color.a = Alpha;

        _sprite.DOColor(color, _duration);
    }

    public void Refill()
    {
        Alpha = 1f;
        Color color = _sprite.color;
        color.a = Alpha;
        _sprite.color = color;
    }
}
