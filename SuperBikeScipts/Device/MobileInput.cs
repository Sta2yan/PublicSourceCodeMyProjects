using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MobileInput : MonoBehaviour, IEndDragHandler
{
    private const float Double = 2f;
    private const float InputValue = .5f;
    private const float VerticalValue = 1;

    [SerializeField] private Scrollbar _inputUI;
    [SerializeField] private ButtonHoldDetected _inputBreak;
    [SerializeField] private ArcadeBikeController _controller;

    private void OnValidate()
    {
        _controller = FindObjectOfType<ArcadeBikeController>();
    }

    private void Awake()
    {
        _inputUI.value = InputValue;
        _controller.ChangeMobileVertical(VerticalValue);
    }

    private void OnEnable()
    {
        _controller.ChangeForMobileControll();
        _inputBreak.PointDowned += OnPointDowned;
        _inputBreak.PointUped += OnPointUped;
        _inputUI.onValueChanged.AddListener(InputUIChanged);
    }

    private void OnDisable()
    {
        _inputUI.onValueChanged.RemoveListener(InputUIChanged);
        _inputBreak.PointDowned -= OnPointDowned;
        _inputBreak.PointUped -= OnPointUped;
    }

    private void InputUIChanged(float arg0)
    {
        _controller.ChangeMobileHorizontal((arg0 - InputValue) * Double);
    }

    private void OnPointDowned()
    {
        _controller.ChangeMobileVertical(-VerticalValue);
    }

    private void OnPointUped()
    {
        _controller.ChangeMobileVertical(VerticalValue);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _controller.ChangeMobileHorizontal(0f);
        _inputUI.value = InputValue;
    }
}
