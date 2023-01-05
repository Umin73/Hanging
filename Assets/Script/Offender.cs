using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using UnityEditor.Tilemaps;

public class Offender : MonoBehaviour
{
    private Vector3 preMousePosition;
    [SerializeField] private bool isPossibleTodesstrafe; // ���� �Ϸ� �� serial ����
    private bool isCreateLine;
    private bool isDescend;
    private float descendSpeed = 2f;
    private float initialMouseX;
    //private float cutDistance = 100f;
    [SerializeField] private float minY; // ���� �Ϸ� �� serial ����
    private HangingManager hangingManager;
    private LineManager lineManager;
    private LineToBox line;
    private GameObject window;
    [SerializeField] private GameObject criteria;
    private Coroutine preChangeTransparency = null;
    public static OffenderData offenderData;
    
    private void Awake()
    {
        hangingManager = FindObjectOfType<HangingManager>();
        lineManager = FindObjectOfType<LineManager>();
        isPossibleTodesstrafe = true;
    }

    private void Start()
    {
        offenderData = new OffenderData();
    }

    private void Update()
    {
        if (isPossibleTodesstrafe)
        {
            if (Line.lineList.Count > 0 && line == null)
            {
                line = Line.lineList[0].lineObject.GetComponent<LineToBox>();
                window = Line.lineList[0].windowObject;
            }

            if (isDescend)
            {
                transform.Translate(new Vector3(0, -1 * descendSpeed * Time.deltaTime));
                if (transform.position.y <= minY)
                    isDescend = false;

                line.MoveToBox(window.transform.position.x, window.transform.position.y);
            }
        }
    }

    private void OnMouseDown()
    {
        if (!isCreateLine)
        {
            lineManager.CreateLine(transform);
            isCreateLine = true;
        }

        if (isPossibleTodesstrafe)
        {
            isDescend = false;
            criteria.SetActive(true);

            Vector3 mousePosition = new Vector3(0, Input.mousePosition.y, 0);
            initialMouseX = Input.mousePosition.x;
            preMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);   //�̻��� ��ġ�� �̵� �����ϱ� ���� preMousePosition �ʱ�ȭ

            if (preChangeTransparency != null)
                StopCoroutine(preChangeTransparency);
            preChangeTransparency = StartCoroutine(lineManager.ChangeTransparency(-1));
        }
    }

    private void OnMouseDrag()
    {
        if (isPossibleTodesstrafe)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            float nextY = currentMousePosition.y - preMousePosition.y;

            /*if (Mathf.Abs(mousePosition.x - initialMouseX) >= cutDistance)    //���� ��� �����ϴ� ���
                hangingManager.Todesstrafe();*/

            if (transform.position.y > minY || nextY > 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + nextY, 0);

                preMousePosition = currentMousePosition;
            }

            line.MoveToBox(window.transform.position.x, window.transform.position.y);
        }
    }

    private void OnMouseUp()
    {
        if (isPossibleTodesstrafe)
        {
            criteria.SetActive(false);
            StopCoroutine(preChangeTransparency);
            preChangeTransparency = StartCoroutine(lineManager.ChangeTransparency(1));

            isDescend = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPossibleTodesstrafe)
        {
            if (collision.CompareTag("criteria"))
            {
                hangingManager.Todesstrafe();
                isPossibleTodesstrafe = false;
            }
        }
    }

public void SetisPossibleTodesstrafe(bool _isPossibleTodesstrafe)
    {
        isPossibleTodesstrafe = _isPossibleTodesstrafe;
    }
}