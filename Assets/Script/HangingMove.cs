using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingMove : MonoBehaviour
{
    private Vector3 preMousePosition;
    [SerializeField] private GameObject criteria;
    [SerializeField] private bool isPossibleTodesstrafe; // ���� �Ϸ� �� serial ����
    [SerializeField] private float minY; // ���� �Ϸ� �� serial ����

    private void OnMouseDown()
    {
        Vector3 mousePosition = new Vector3(0, Input.mousePosition.y, 0);

        preMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void OnMouseDrag()
    {
        if (isPossibleTodesstrafe)
        {
            Vector3 mousePosition = new Vector3(0, Input.mousePosition.y, 0);
            Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            
            transform.position = new Vector3(transform.position.x, transform.position.y + currentMousePosition.y - preMousePosition.y, 0);
            preMousePosition = currentMousePosition;

            if (transform.position.y + transform.lossyScale.y / 2 > criteria.transform.position.y)
            {
                isPossibleTodesstrafe = false;
                HangingManager.isTodesstrafe = true;
                Debug.Log("����");
                Debug.Log(HangingManager.isTodesstrafe);
            }
            else if (transform.position.y - transform.lossyScale.y / 2 < minY)
            {
                isPossibleTodesstrafe = false;
                HangingManager.isTodesstrafe = false;
                Debug.Log("����");
            }
        }
    }

    public void SetisPossibleTodesstrafe(bool _isPossibleTodesstrafe)
    {
        isPossibleTodesstrafe = _isPossibleTodesstrafe;
    }
}
