using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WindowShowData : MonoBehaviour
{
    protected WindowSetSize windowSetSize;
    protected RecordData recordData;

    protected void Awake()
    {
        windowSetSize = transform.parent.GetComponent<WindowSetSize>();
    }

    //�ؽ�Ʈ ����//
    public void SetText(string str)
    {
        GetComponent<TextMeshProUGUI>().text = str.Replace("\\n", "\n");
    }

    ////â ũ�� ����//
    protected void SetTextSize(float width)
    {
        windowSetSize.SetSize(width);
    }
}
