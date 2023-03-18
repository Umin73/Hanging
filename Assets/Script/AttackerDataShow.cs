using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerDataShow : WindowShowData
{
    private void Start()
    {
        Line.lineList[Line.lineList.Count - 1].GetShowData(ShowData);
    }

    void ShowData()
    {
        recordData = FindObjectOfType<AttackerInfo>().recordData;

        string str = recordData.attackerData["familyName"] + " " + recordData.attackerData["name"] + "\n"
            + "����: " + recordData.attackerData["gender"] + "\n"
            + "����: " + recordData.attackerData["age"] + "��\n"
            + "����: " + recordData.attackerData["jobText"] + "\n"
            + "����: Ȯ��";

        int maxLength = (recordData.attackerData["familyName"] + recordData.attackerData["name"]).Length;
        float width = 1.8f + 0.2f * (maxLength - 7);

        SetText(str);
        if (maxLength > 7) SetTextSize(width);
    }
}