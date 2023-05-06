using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadPrisonerInfo : MonoBehaviour
{
    public int order;   //������ ��ȣ(����) �����ϴ� ��ũ��Ʈ���� order ������ ����ϵ��� ���� �ʿ�
    string fileName;
    public int day = HangingManager.day;
    public int tmpDay;

    List<Dictionary<string, object>> data;
    public Dictionary<string, object> currentPrisonerInfo = new Dictionary<string, object>();   //������ ������ ���� ��ųʸ�
    /*
        1. currentPrisonerInfo �������� �� �� �������� ���� order ���� �ʿ�.
        2. FieldNameOfCSV���� fieldNames ������
            currentPrisonerInfo[fieldNameOfCSV.fieldNames[i]] ó�� ����� �� �ʵ��� ������ �������� ����
            (�Ǵ� ���� ex) currentPrisonerInfo["Grade"] ó�� ���
    */

    FieldNameOfCSV fieldNameOfCSV;

    private void Awake()
    {
        day = tmpDay;

        char charValue = (char)(day + '0');

        fileName = "Prisoner_day";
        fileName += charValue;

        data = CSVReader2.Read(fileName);

        fieldNameOfCSV = GetComponent<FieldNameOfCSV>();
    }

    private void Start()
    {
        for (int i = 0; i < data.Count; i++)
        {
            for (int j = 1; j < fieldNameOfCSV.fieldNames.Count; j++)
            {
                string fieldName = fieldNameOfCSV.fieldNames[j];
                string curData = data[i][fieldName].ToString();

                if (curData.Length >= 2 && int.TryParse(curData, out int output))
                {
                    SetRandomValue(i, fieldName);
                }
            }
        }

        setCurrentPrisonerInfo(order);

        for(int i=1;i<fieldNameOfCSV.fieldNames.Count;i++)
        {
            Debug.Log(fieldNameOfCSV.fieldNames[i] + "�� ���� " + currentPrisonerInfo[fieldNameOfCSV.fieldNames[i]]);
        }
    }


    void SetRandomValue(int order, string fieldName)
    {
        string tmpString = data[order][fieldName].ToString();
        int randomIdx = UnityEngine.Random.Range(0, tmpString.Length);
        int randomValue = int.Parse(tmpString[randomIdx].ToString());

        data[order][fieldName] = (char)(randomValue + '0');
    }

    void setCurrentPrisonerInfo(int currentOrder)
    {
        for(int i=1;i<fieldNameOfCSV.fieldNames.Count;i++)
        {
            string fieldName = fieldNameOfCSV.fieldNames[i];
            currentPrisonerInfo.Add(fieldName, data[currentOrder][fieldName]);
        }
    }
}
