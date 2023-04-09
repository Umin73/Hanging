using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using UnityEditor.Tilemaps;

public class AttackerMouseMove : MonoBehaviour
{
    HangingManager hangingManager;
    LineManager lineManager;
    AttackerDialogEvent attackerDialogEvent;

    Vector3 preMousePosition;
    [SerializeField] bool isPossibleTodesstrafe, isPossibleClick, isCreateLine, isDescend, isTodesstrafe;
    float descendSpeed = 2f;
    float initialMouseX;
    [SerializeField] float minY; // ���� �Ϸ� �� serial ����
    RectTransform windowRectTransform;
    Line line;
    GameObject window;
    [SerializeField] GameObject criteria;
    Coroutine preChangeTransparency = null;

    void Awake()
    {
        hangingManager = FindObjectOfType<HangingManager>();
        lineManager = FindObjectOfType<LineManager>();
    }

    private void Start()
    {
        attackerDialogEvent = HangingManager.attackerDialogEvent;
    }

    void Update()
    {
        if (isPossibleTodesstrafe || (isTodesstrafe == false)) 
        {
            if (Line.lineList.Count > 0 && line == null)
            {
                line = Line.lineList[0];
                window = Line.lineList[0].windowObject;
                windowRectTransform = window.GetComponent<RectTransform>();
            }

            if (isDescend)
            {
                transform.Translate(new Vector3(0, -1 * descendSpeed * Time.deltaTime));
                if (transform.position.y <= minY)
                    isDescend = false;

                line.MoveTo(windowRectTransform.position.x, windowRectTransform.position.y, transform.position.x, transform.position.y);
            }
        }
    }

    void OnMouseDown()
    {
        if (isPossibleClick || isPossibleTodesstrafe)
        {
            attackerDialogEvent.SetCompulsoryDialogEvent("isClickAttacker");

            if (isCreateLine == false)
            {
                lineManager.CreateLine();
                isCreateLine = true;
            }

            isDescend = false;

            Vector3 mousePosition = new Vector3(0, Input.mousePosition.y, 0);
            initialMouseX = Input.mousePosition.x;
            preMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);   //�̻��� ��ġ�� �̵� �����ϱ� ���� preMousePosition �ʱ�ȭ

            if (isPossibleTodesstrafe) // �ʼ� ��翡�� Ŭ������ �� ���� ���� ����
            {
                LineChangeTransparency(-1);
            }
        }
    }

    void OnMouseDrag()
    {
        if (isPossibleTodesstrafe && isCreateLine)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            float nextY = currentMousePosition.y - preMousePosition.y;

            if (transform.position.y > minY || nextY > 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + nextY, 0);
                preMousePosition = currentMousePosition;
            }

            line.MoveTo(windowRectTransform.position.x, windowRectTransform.position.y, transform.position.x, transform.position.y);
        }
    }

    void OnMouseUp()
    {
        if (isPossibleTodesstrafe)
        {
            if (isCreateLine)
            {
                LineChangeTransparency(1);
            }

            if (transform.position.y > minY)
            {
                isDescend = true;
            }
            isCreateLine = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPossibleTodesstrafe)
        {
            if (collision.CompareTag("criteria"))
            {
                hangingManager.Todesstrafe();
                isPossibleTodesstrafe = false;
                isTodesstrafe = true;
            }

            if((collision.CompareTag("middleCriteria")) && (isDescend == false))
            {
                attackerDialogEvent.SetSituationDialogEvent(attackerDialogEvent.GetRandomId(11, 20), 0);
            }
        }
    }

    public void SetPossibleTodesstrafe(bool _isPossibleTodesstrafe)
    {
        isPossibleTodesstrafe = _isPossibleTodesstrafe;
    }

    public void SetPossibleClick(bool _isPossibleClick)
    {
        isPossibleClick = _isPossibleClick;
    }

    public void LineChangeTransparency(int mode)
    {
        if (preChangeTransparency != null) StopCoroutine(preChangeTransparency);
        if (line != null) preChangeTransparency = StartCoroutine(line.ChangeTransparency(mode));
    }
}