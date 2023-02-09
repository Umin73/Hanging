using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WindowShowData : MonoBehaviour
{
    WindowSetSize windowSetSize;
    RecordData recordData;

    void Awake()
    {
        windowSetSize = FindObjectOfType<WindowSetSize>();
    }

    public void SetText()
    {
        recordData = FindObjectOfType<AttackerInfo>().recordData;

        //�ؽ�Ʈ ����//
        string text = "������: " + recordData.fname + " " + recordData.name + "\n"
            + "�˸�: " + recordData.crime + "\n"
            + "�߻� ���: " + recordData.crimePlaceText + " ���" + "\n"
            + "������: " + recordData.victimFamilyName + " " + recordData.victimName + "\n"
            + "����: " + recordData.crimeReasonText;

        GetComponent<TextMeshProUGUI>().text = text.Replace("\\n", "\n");

        //â ũ�� ����//
        int maxlength = Mathf.Max((recordData.fname + recordData.name).Length, (recordData.victimFamilyName + recordData.victimName).Length);
        float width = 2.3f + 0.3f * (maxlength - 4);
        windowSetSize.SetSize(width);
    }
}
