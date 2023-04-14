using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractivePictureEnd : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private List<PartPicture> _pictureParts;

    private bool _isEnable;

    public event Action<Pencil> Hitted;
    public event Action DrawEnded;
    public event Action Interactived;

    public SpriteRenderer Sprite => _sprite;

    private void OnEnable()
    {
        DrawEnded += OnDrawEnd;
    }

    private void OnDisable()
    {
        DrawEnded -= OnDrawEnd;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PencilChangerSize pencil))
        {
            pencil.gameObject.SetActive(false);
            Hitted?.Invoke(pencil.GetComponent<Pencil>());

            if (_isEnable)
                FindPartPictureToDraw(pencil.PencilPercent);
        }
    }

    private void FindPartPictureToDraw(float paintPercent)
    {
        var pictureParts = _pictureParts.Where(part => part.IsPaint == false).ToList();

        if (pictureParts.Count > 0)
            pictureParts[UnityEngine.Random.Range(0, pictureParts.Count - 1)].Draw(paintPercent);
        else
            DrawEnded?.Invoke();
    }

    private void OnDrawEnd()
    {
        _isEnable = false;
        SaveSystem.CountUnlockInteractivePicture++;

        for (int i = 0; i < _pictureParts.Count; i++)
        {
            _pictureParts[i].gameObject.SetActive(false);
            _pictureParts[i].Refill();
        }
    }

    public void EnableInteractive()
    {
        Interactived?.Invoke();
        _isEnable = true;
    }
}
