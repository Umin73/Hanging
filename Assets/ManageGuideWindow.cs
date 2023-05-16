using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ManageGuideWindow : MonoBehaviour
{
    public UiManager uiManager;

    [SerializeField]
    private AttackerMouseMove attackerMouseMove;
    [SerializeField]
    private Rope rope;

    public RectTransform targetRectTransform;

    void Start()
    {
        attackerMouseMove = GameObject.FindGameObjectWithTag("prisoner").GetComponent<AttackerMouseMove>();
        rope = GameObject.Find("rope").GetComponent<Rope>();
    }

    void FixedUpdate()
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(targetRectTransform, Input.mousePosition))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                {
                    attackerMouseMove.SetPossibleTodesstrafe(false);
                    //Debug.Log("������ Ŭ�� ����");
                    rope.SetCutPossible(false);
                    //Debug.Log("���� �� ����");
                }
        }
        else
        {
            attackerMouseMove.SetPossibleTodesstrafe(true);
            //Debug.Log("������ Ŭ�� Ǯ��");
            rope.SetCutPossible(true);
            //Debug.Log("���� �� Ǯ��");
        }
    }
}
