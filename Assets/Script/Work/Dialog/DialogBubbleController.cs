using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogBubbleController : MonoBehaviour
{
    [SerializeField] GameObject []dialogBubblePrefab;
    List<GameObject> dialogBubbleList = new List<GameObject>();
    List<RectTransform> dialogBubbleRecttransformList = new List<RectTransform>();
    DialogWindowController dialogWindowController;
    RectTransform rectTransform;
    const int perBubbleHeight = 50;

    private void Awake()
    {
        dialogWindowController = FindObjectOfType<DialogWindowController>();
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.V)) CreateDialogBubble( 1 , "qweqweeqwweqeqwqweqwe");
    }

    GameObject GetDialogBubble( int id ) // �÷��̾�(0), ������(1), ����(2)
    {
        return Instantiate( dialogBubblePrefab[id], dialogBubblePrefab[id].transform.position, Quaternion.identity, transform);
    }

    public void CreateDialogBubble( int id , string str )
    {
        if (dialogWindowController == null)
            Debug.Log("dialogWindowController�� null");
        dialogWindowController.VisibleDialogWindow();

        if (dialogBubbleList == null)
            Debug.Log("dialogBubbleList�� null");
        if (id < 0 || id > 2)
            Debug.Log("id�� ��ȿ���� ����");
        dialogBubbleList.Add( GetDialogBubble( id ).transform.GetChild(0).gameObject );
        int bubbleIndex = dialogBubbleList.Count - 1;
        if (bubbleIndex < 0)
            Debug.Log("bubbleIndex�� ��ȿ���� ����");
        dialogBubbleRecttransformList.Add(dialogBubbleList[bubbleIndex].GetComponent<RectTransform>());

        //��� �ٹٲ� �Լ� ���� �ڸ�//
        DialogTextShow( str, bubbleIndex);
        BubbleSetSizeSet(id, bubbleIndex);
    }

    void SetPositionDialogBubble (int id, int index)
    {
        RectTransform dialogRectTransform = dialogBubbleRecttransformList[index];
        float x;

        if (id == 0)
            x = 155 - dialogRectTransform.sizeDelta.x / 2;
        else
            x = -155 + dialogRectTransform.sizeDelta.x / 2;

        dialogRectTransform.localPosition = new Vector2(x, 0);
    }

    void DialogTextShow(string str, int index)
    {
        dialogBubbleList[index].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = str;
    }

    void BubbleSetSizeSet(int id, int index)
    {
        StartCoroutine(BubbleSetSizeSet1(id, index));
    }

    IEnumerator BubbleSetSizeSet1(int id, int index)
    {
        yield return new WaitForSecondsRealtime(0.1f * Time.deltaTime);
        dialogBubbleRecttransformList[index].sizeDelta = dialogBubbleList[index].transform.GetChild(0).GetComponent<RectTransform>().sizeDelta;
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y + perBubbleHeight);

        SetPositionDialogBubble(id, index);
    }
}
