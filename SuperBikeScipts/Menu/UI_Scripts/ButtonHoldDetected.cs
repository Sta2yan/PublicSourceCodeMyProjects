using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoldDetected : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public event Action PointDowned;
    public event Action PointUped;

    public void OnPointerDown(PointerEventData eventData)
    {
        PointDowned?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PointUped?.Invoke();
    }
}
