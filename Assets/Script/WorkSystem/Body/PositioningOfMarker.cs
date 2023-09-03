using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositioningOfMarker : MonoBehaviour
{
    [SerializeField] GameObject parentOfPos;    //��ġ����Ʈ�� �θ�
    public List<Transform> positionList;       //��ġ����Ʈ

    public int gradePos;  //��� ��ġ
    public int scarPos;   //���� ��ġ
    public int tattooPos; //���� ��ġ

    private void Awake()
    {
        positionList
            = new List<Transform>(parentOfPos.GetComponentsInChildren<Transform>());

        positionList.Remove(parentOfPos.transform);    //���� ������Ʈ�� Transform�� ����

        SetRandomPos();
    }

    void SetRandomPos()
    {
        const int numOfMarkerTypes = 3;
        List<int> availableNumbers = new List<int>();
        List<int> selectedNumbes = new List<int>();

        for (int i = 0; i < positionList.Count; i++)
        {
            availableNumbers.Add(i);
        }

        for (int i = 0; i < numOfMarkerTypes; i++)
        {
            int randomIdx = Random.Range(0, availableNumbers.Count);
            int selectedNum = availableNumbers[randomIdx];

            selectedNumbes.Add(selectedNum);
            availableNumbers.RemoveAt(randomIdx);
        }

        gradePos = selectedNumbes[0];
        scarPos = selectedNumbes[1];
        tattooPos = selectedNumbes[2];
    }
}
