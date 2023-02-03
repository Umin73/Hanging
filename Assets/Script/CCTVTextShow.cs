using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class CCTVTextShow : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;

    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        DateTime date = System.Convert.ToDateTime("2132/2/3");
        date.AddDays(HangingManager.day);

        string text = "CAMERA" + 1 + "\n" // 1 ��� ������ idx
            + "PLAY ��" + "\n"
            + date.ToString("yy/MM/dd ") + " " + date.ToString("ddd");

        textMeshProUGUI.text = text.Replace("\\n", "\n");
    }
}