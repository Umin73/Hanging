using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// 1~7���� ������ ���� ������ ����

public class ReadPrisonerInfo : MonoBehaviour
{
    public int order;   //������ ��ȣ(����) �����ϴ� ��ũ��Ʈ���� order ������ ����ϵ��� ���� �ʿ�
    string fileName;
    int day = HangingManager.day;
    //public int tmpDay;

    List<Dictionary<string, object>> data;
    public Dictionary<string, string> currentPrisonerInfo = new Dictionary<string, string>();   //������ ������ ���� ��ųʸ�

    /*
        1. currentPrisonerInfo �������� �� �� �������� ���� order ���� �ʿ�.
        2. FieldNameOfCSV���� fieldNames ������
            currentPrisonerInfo[fieldNameOfCSV.fieldNames[i]] ó�� ����� �� �ʵ��� ������ �������� ����
            (�Ǵ� ���� ex) currentPrisonerInfo["Grade"] ó�� ���
    */

    public FieldNameOfCSV fieldNameOfCSV;
    TableManager tableManager;
    HangingManager hangingManager;

    private void Awake()
    {
        char charValue = (char)(day + '0');
        fileName = "Prisoner_day" + charValue;

        FileInfo fileInfo = new FileInfo(fileName);
        if (fileInfo.Exists == false)
        {
            Debug.Assert(false, "���μ� comment : " + fileName + "�� �����ϴ� ������ �߰����ּ���.");
            return;
        }

        data = CSVReader2.Read(fileName);

        fieldNameOfCSV = GetComponent<FieldNameOfCSV>();
        tableManager = FindObjectOfType<TableManager>();
        hangingManager = FindObjectOfType<HangingManager>();

        order = hangingManager.judgeCount;
    }

    private void Start()
    {
        if (data == null)
            return;

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
        for (int i = 1; i < fieldNameOfCSV.fieldNames.Count; i++)
        {
            string fieldName = fieldNameOfCSV.fieldNames[i];
            currentPrisonerInfo.Add(fieldName, data[currentOrder][fieldName].ToString()) ;
        }
    }

    public int GetGrade()
    {
        if (currentPrisonerInfo.ContainsKey("Grade"))
        {
            return int.Parse(currentPrisonerInfo["Grade"]);
        }
        else return -1;
    }

    public int GetCrimeGrade()
    {
        if (currentPrisonerInfo.ContainsKey("CrimeGrade"))
        {
            return int.Parse(currentPrisonerInfo["CrimeGrade"]);
        }
        else return -1;
    }

    public int GetCrimeReason()
    {
        if(currentPrisonerInfo.ContainsKey("CrimeReason"))
        {
            return int.Parse(currentPrisonerInfo["CrimeReason"]);
        }
        return -1;
    }

    public int GetAttackerMove()
    {
        if (currentPrisonerInfo.ContainsKey("AttackerMove"))
        {
            return int.Parse(currentPrisonerInfo["AttackerMove"]);
        }
        return -1;
    }

    public int GetVictimMove()
    {
        if (currentPrisonerInfo.ContainsKey("VictimMove"))
        {
            return int.Parse(currentPrisonerInfo["VictimMove"]);
        }
        return -1;
    }

    public int GetAttackerJob()
    {
        if (currentPrisonerInfo.ContainsKey("AttackerJob"))
        {
            return int.Parse(currentPrisonerInfo["AttackerJob"]);
        }
        return -1;
    }

    public int GetVictimJob()
    {
        if (currentPrisonerInfo.ContainsKey("VictimJob"))
        {
            return int.Parse(currentPrisonerInfo["VictimJob"]);
        }
        return -1;
    }

    public string GetVictimGrade()
    {
        if (currentPrisonerInfo.ContainsKey("VictimGrade"))
        {
            return currentPrisonerInfo["VictimGrade"];
        }
        return null;
    }

    public int GetCrimeRecord()
    {
        if (currentPrisonerInfo.ContainsKey("CrimeRecord"))
        {
            return int.Parse(currentPrisonerInfo["CrimeRecord"]);
        }
        else return -1;
    }

    public int GetLie()
    {
        if (currentPrisonerInfo.ContainsKey("Lie"))
        {
            return int.Parse(currentPrisonerInfo["Lie"]);
        }
        return -1;
    }

    public int GetInfoError()
    {
        if (currentPrisonerInfo.ContainsKey("InfoError"))
        {
            return int.Parse(currentPrisonerInfo["InfoError"]);
        }
        return -1;
    }

    public string GetAsk()
    {
        if (currentPrisonerInfo.ContainsKey("Ask"))
        {
            return currentPrisonerInfo["Ask"];
        }
        else return null;
    }

    public int getAnswer()
    {
        int answer = 1;
        if (currentPrisonerInfo.ContainsKey("Answer"))
        {
            answer = int.Parse(currentPrisonerInfo["Answer"]);
        }
        return answer;
    }
}
