using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NotClickOther : MonoBehaviour
{
    [SerializeField]
    private AttackerMouseMove attackerMouseMove;
    [SerializeField]
    private Rope rope;

    private void Awake()
    {
        attackerMouseMove = GameObject.Find("Prisoner").GetComponent<AttackerMouseMove>();
        rope = GameObject.Find("rope").GetComponent<Rope>();
    }
    void Update()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            attackerMouseMove.SetPossibleTodesstrafe(false);
            Debug.Log("������ Ŭ�� ����");
            rope.SetCutPossible(false);
            Debug.Log("���� �� ����");
        }
        else
        {
            attackerMouseMove.SetPossibleTodesstrafe(true);
            Debug.Log("������ Ŭ�� Ǯ��");
            rope.SetCutPossible(true);
            Debug.Log("���� �� Ǯ��");
        }
    }
}
