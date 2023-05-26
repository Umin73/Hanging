using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragUiWindow : MonoBehaviour, IDragHandler
{
    [SerializeField] private GameObject clickArea; //� �κ��� ���� �������� UI �����̰� �� ������
    [SerializeField] private GameObject uiObject;

    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;


    private void Awake()
    {
        clickArea = this.gameObject;
        uiObject = transform.parent.gameObject;

        rectTransform = uiObject.GetComponent<RectTransform>();
        canvas = uiObject.GetComponentInParent<Canvas>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

        //ClampPosition();
    }


    private void ClampPosition()
    {
    }
}