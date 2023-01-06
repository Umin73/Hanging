using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Line
{
    public static List<Line> lineList = new List<Line>();
    public GameObject lineObject { get; private set; }
    public GameObject windowObject { get; private set; }
    private LineRenderer lineLR;
    public SpriteRenderer windowSR { get; private set; }
    private TextMeshProUGUI windowtmpu;
    public float devide = 1000f; //�и𿩼� �ӵ��� �ݺ�ʰ���
    public float parentYSum;   //������, ������(�θ��) y �߰�

    public Line(GameObject _lineObject, GameObject _windowObject)
    {
        lineObject = _lineObject;
        windowObject = _windowObject;
        lineLR = lineObject.GetComponent<LineRenderer>();
        windowSR = windowObject.GetComponent<SpriteRenderer>();
        windowtmpu = windowObject.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetAlpha(float alpha)
    {
        lineLR.startColor = new Color(1, 1, 1, alpha);   //�÷� ���߿� ������ �ʿ�
        lineLR.endColor = new Color(1, 1, 1, alpha);
        windowSR.color = new Color(1, 1, 1, alpha);
        windowtmpu.color = new Color(0, 0, 0, alpha);
    }
}