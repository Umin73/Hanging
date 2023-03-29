using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogBubbleController : MonoBehaviour
{
    [SerializeField] GameObject []dialogBubblePrefab;
    List<GameObject> dialogBubbleList = new List<GameObject>();

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.V)) CreateDialogBubble(1);
    }

    GameObject GetDialogBubble( int id ) // �÷��̾�(0), ������(1), ����(2)
    {
        return Instantiate( dialogBubblePrefab[id], dialogBubblePrefab[id].transform.position, Quaternion.identity, transform );
    }

    void CreateDialogBubble( int id )
    {
        dialogBubbleList.Add( GetDialogBubble( id ) );
        //�� �ڸ��� ���� ũ�� ���� �Լ� �־�� ��//
        SetPositionDialogBubble( 260, dialogBubbleList.Count - 1, id );
    }

    void SetPositionDialogBubble ( float startY, int index , int id)
    {
        RectTransform dialogRectTransform = dialogBubbleList[index].gameObject.GetComponent<RectTransform>();
        float y = startY - index * 40;
        float x;

        if (id == 0) x = 160 - dialogRectTransform.sizeDelta.x / 2;
        else x = -160 + dialogRectTransform.sizeDelta.x / 2;

        dialogRectTransform.localPosition = new Vector2(x, y);
    }
}
