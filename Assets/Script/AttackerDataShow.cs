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
            + "�ù� ���: " + recordData.attackerData["positionGrade"] + "���\n"
            + "����: " + recordData.attackerData["gender"] + "\n"
            + "����: " + recordData.attackerData["jobText"] + "\n"
            + "����: Ȯ��"; 

        int maxlength = Mathf.Max((recordData.attackerData["familyName"] + recordData.attackerData["name"]).Length,
                        (recordData.victimData["familyName"] + recordData.victimData["name"]).Length);

        SetText(str);
        SetTextSize(maxlength);
    }
}
