using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WindowShowData : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI, buttonTextMeshProUGUI;
    private WindowSetSize windowSetSize;
    private string text;
    private OffenderData offenderdata;

    private void Awake()
    {
        offenderdata = FindObjectOfType<Offender>().offenderData;
    }

    public void ShowData()
    {
        textMeshProUGUI = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        buttonTextMeshProUGUI = transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        

        buttonTextMeshProUGUI.text = "������: " + offenderdata.fname + " " + offenderdata.name;
        text = "�˸�: " + offenderdata.crime + "\n"
            + "�߻� ���: " + offenderdata.grade + " ���" + "\n"
            + "������: " + offenderdata.vfname + " " + offenderdata.vname + "\n"
            + "����: " + offenderdata.detail;

        textMeshProUGUI.text = text.Replace("\\n", "\n");

        //â ũ�� ����//
        windowSetSize = GetComponent<WindowSetSize>();
        int maxlength = Mathf.Max((offenderdata.fname + offenderdata.name).Length, (offenderdata.vfname + offenderdata.vname).Length);
        float width = 2.3f + 0.3f * (maxlength - 4);
        windowSetSize.SetSize(width);
    }
}
