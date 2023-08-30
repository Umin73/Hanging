using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositioningOfMarker : MonoBehaviour
{
    [SerializeField] GameObject marker;
    [SerializeField] List<Sprite> markerList;

    [SerializeField] GameObject parentOfList;
    private List<Transform> positionList;
    private Transform position;

    SpriteRenderer spriteRenderer;
    RecordData recordData;

    new private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        positionList 
            = new List<Transform>(parentOfList.GetComponentsInChildren<Transform>());
        
        positionList.Remove(parentOfList.transform);    //���� ������Ʈ�� Transform�� ����
    }

    private void Start()
    {
        //���� �ʿ�
        int grade = int.Parse(recordData.attackerData["positionGrade"]);
        int random = Random.Range(0, positionList.Count);

        spriteRenderer.sprite = markerList[grade];
        position = positionList[random];
        marker.transform.position = position.position;
    }
}
