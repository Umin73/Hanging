 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WindowMouseMove : MonoBehaviour
{
    private Vector3 preMousePosition;
    private Line line;
    private int lineIdx;

    private void Start()
    {
        for(int i = 0; i < Line.lineList.Count; i++)
        {
            if(Line.lineList[i].windowObject == this.gameObject)
            {
                line = Line.lineList[i];
                lineIdx = i;
                break;
            }
        }
    }

    private void OnMouseDown()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        preMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);   //�̻��� ��ġ�� �̵� �����ϱ� ���� preMousePosition �ʱ�ȭ
    }

    private void OnMouseDrag()
    {
        //window �̵�//
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);   
        Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 toPosition = currentMousePosition - preMousePosition;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + toPosition, Time.deltaTime * 10000f);
        preMousePosition = currentMousePosition;

        //1�� Ȥ�� 2�� �� ������Ʈ//
        if (lineIdx == 0)
        {
            line.MoveTo(transform.position.x, transform.position.y);

            if (Line.lineList.Count > 1)
            {
                Line nextLine = Line.lineList[lineIdx + 1];
                Transform nextWindowTransform = nextLine.windowObject.transform;

                nextLine.MoveTo(nextWindowTransform.position.x, nextWindowTransform.position.y, transform.position.x, transform.position.y);
            }
        }
        else
        {
            Transform preWindowTransform = Line.lineList[lineIdx - 1].windowObject.transform;

            line.MoveTo(transform.position.x, transform.position.y, preWindowTransform.position.x, preWindowTransform.position.y);
        }

    }
}