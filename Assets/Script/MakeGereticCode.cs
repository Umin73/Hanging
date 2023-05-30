using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MakeGereticCode : MonoBehaviour
{
    TextMeshProUGUI code;

    private string humanCloneCode;
    private string geneticCode;

    const int numberOfCode = 9;
    const int lengthOfCode = 6;

    public bool isClone;

    private void Awake()
    {
        code = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        isClone = true; //�ӽ÷� �����ΰ��̶� ����

        SetHumanCloneCode("abcdef");    //�ӽ� �����ΰ� �ڵ� ����
        GenerateCode(isClone);

        code.text = geneticCode.ToString();
    }

    public void SetHumanCloneCode(string _humanCloneCode)
    {
        humanCloneCode = _humanCloneCode;
    }

    public void GenerateCode(bool isClone)
    {
        geneticCode = "";
        System.Random rand = new System.Random();

        //9���� �ڵ幭�� �� ��� �����ΰ� �ڵ带 ���� �������� ���� �ε���
        int randomIdx = rand.Next(numberOfCode);

        for(int i=0;i<numberOfCode;i++)
        {
            if(isClone && randomIdx == i)
            {
                geneticCode += humanCloneCode;
            }
            else
            {
                for (int j = 0; j < lengthOfCode; j++)
                {
                    geneticCode += (char)(rand.Next(26) + 'a');
                }
            }
            geneticCode += " ";

            if ((i+1) % 3 == 0) geneticCode += "\n";
        }
    }
}
