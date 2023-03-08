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
        string text = "������: " + recordData.attackerData["familyName"] + " " + recordData.attackerData["name"] + "\n"
            + "�˸�: " + recordData.attackerData["crime"] + "\n"
            + "�߻� ���: " + recordData.attackerData["crimePlaceText"] + " ���" + "\n"
            + "������: " + recordData.victimData["familyName"] + " " + recordData.victimData["name"] + "\n"
            + "����: " + recordData.attackerData["crimeReasonText"];

        GetComponent<TextMeshProUGUI>().text = text.Replace("\\n", "\n");

        //â ũ�� ����//
        int maxlength = Mathf.Max((recordData.attackerData["familyName"] + recordData.attackerData["name"]).Length, 
            (recordData.victimData["familyName"] + recordData.victimData["name"]).Length);
        float width = 2.3f + 0.15f * (maxlength - 3);
        windowSetSize.SetSize(width);
    }
}
