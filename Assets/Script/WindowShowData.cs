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
        
        text = "가해자: " + offenderdata.fname + " " + offenderdata.name + "\n"
            + "죄목: " + offenderdata.crime + "\n"
            + "발생 장소: " + offenderdata.crimePlaceText + " 등급" + "\n"
            + "피해자: " + offenderdata.victimFamilyName + " " + offenderdata.victimName + "\n"
            + "경위: " + offenderdata.crimeReasonText;

        textMeshProUGUI.text = text.Replace("\\n", "\n");

        //창 크기 조절//
        windowSetSize = GetComponent<WindowSetSize>();
        int maxlength = Mathf.Max((offenderdata.fname + offenderdata.name).Length, (offenderdata.victimFamilyName + offenderdata.victimName).Length);
        float width = 2.3f + 0.3f * (maxlength - 4);
        windowSetSize.SetSize(width);
    }
}
