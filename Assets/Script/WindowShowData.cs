using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WindowShowData : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;
    private string text;

    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        OffenderData offenderdata = Offender.offenderData;

        text = "      ������: " + offenderdata.fname + " " + offenderdata.name + "\n"
            + "      �˸�: " + offenderdata.crime + "\n"
            + "      �߻� ���: " + offenderdata.grade + " ���" + "\n"
            + "      ������: " + offenderdata.vfname + " " + offenderdata.vname + "\n"
            + "      ����: " + offenderdata.detail;

        textMeshProUGUI.text = text.Replace("\\n", "\n");
    }
}
