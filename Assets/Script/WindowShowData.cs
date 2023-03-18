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
    protected void SetTextSize(int maxLength)
    {
        float width = 2.3f + 0.15f * (maxLength - 3);
        windowSetSize.SetSize(width);
    }

    virtual protected void Showdata() { }
}
