using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragUiWindow : MonoBehaviour, IDragHandler
{
    [SerializeField]
    private GameObject dragArea; //� �κ��� ���� �������� UI �����̰� �� ������
    [SerializeField]
    private GameObject uiObject;
    private RectTransform rectTransform;
    private Canvas canvas;


    private void Awake()
    {
        dragArea = this.gameObject;
        uiObject = transform.parent.gameObject;
        rectTransform = uiObject.GetComponent<RectTransform>();
        canvas = uiObject.GetComponentInParent<Canvas>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

}
