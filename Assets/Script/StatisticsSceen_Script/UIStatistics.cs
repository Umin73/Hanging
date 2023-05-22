using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIStatistics : MonoBehaviour
{
    private TMP_Text _date;
    private TMP_Text _judgeCount;
    private TMP_Text _correctJudgeCount;
    private TMP_Text _discorrectJudgeCount;
    private TMP_Text _discorrectAndTodesstrafedPersonCount;

    private void Awake()
    {
        _date = GameObject.Find("Date").GetComponent<TMP_Text>();
        _judgeCount = GameObject.Find("JudgeCount").GetComponent<TMP_Text>();
        _correctJudgeCount = GameObject.Find("CorrectJudgeCount").GetComponent<TMP_Text>();
        _discorrectJudgeCount = GameObject.Find("DiscorrectJudgeCount").GetComponent<TMP_Text>();
        _discorrectAndTodesstrafedPersonCount = GameObject.Find("DiscorrectAndTodesstrafedPersonCount").GetComponent<TMP_Text>();
    }

    private void Start()
    {
        Debug.Assert(_date != null, "date�� ������Ʈ�� �����ϴ�.");
        Debug.Assert(_judgeCount != null, "judgeCount�� ������Ʈ�� �����ϴ�.");
        Debug.Assert(_correctJudgeCount != null, "correctJudgeCount�� ������Ʈ�� �����ϴ�.");
        Debug.Assert(_discorrectJudgeCount != null, "discorrectJudgeCount�� ������Ʈ�� �����ϴ�.");
        Debug.Assert(_discorrectAndTodesstrafedPersonCount != null, "discorrectAndTodesstrafedPersonCount�� ������Ʈ�� �����ϴ�.");
    }

    public void setStatistics(HangingInfoWrapper hangingInfo)
    {
        _date.text = System.Convert.ToDateTime("2132/2/1").AddDays(hangingInfo._day - 1).ToString("yy-mm-dd");
        _judgeCount.text = hangingInfo._judgeCount.ToString();
        _correctJudgeCount.text = hangingInfo._correctJudgeCount.ToString();
        _discorrectJudgeCount.text = hangingInfo._discorrectJudgeCount.ToString();
        _discorrectAndTodesstrafedPersonCount.text = hangingInfo._discorrectAndTodesstrafedPersonCount.ToString();
    }
}
