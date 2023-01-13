using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WindowShowData : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;
    private WindowMouseMove windowMouseMove;
    private string text;

    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        windowMouseMove = transform.parent.GetComponent<WindowMouseMove>();
    }

    private void Start()
    {
        OffenderData offenderdata = Offender.offenderData;

        text = "������: " + offenderdata.fname + " " + offenderdata.name + "\n"
            + "�˸�: " + offenderdata.crime + "\n"
            + "�߻� ���: " + offenderdata.grade + " ���" + "\n"
            + "������: " + offenderdata.vfname + " " + offenderdata.vname + "\n"
            + "����: " + offenderdata.detail;

        textMeshProUGUI.text = text.Replace("\\n", "\n");

        int maxlength = Mathf.Max((offenderdata.fname + offenderdata.name).Length, (offenderdata.vfname + offenderdata.vname).Length);
        float width = 2.3f + 0.3f * (maxlength - 4);
        windowMouseMove.SetSize(new Vector2(width, 4f));
    }
}