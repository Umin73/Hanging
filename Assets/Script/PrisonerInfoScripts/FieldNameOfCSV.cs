using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FieldNameOfCSV : MonoBehaviour
{
    public List<string> fieldNames; //Prisoner_dayN �� �� �ʵ�� ����Ʈ

    [SerializeField]
    string fileName;
    int day = HangingManager.day;

    private void Awake()
    {

        if (day >= 8) return;
        char charValue = (char)(day + '0');

        fieldNames = new List<string>();
        fileName = "Assets/Resources/" + "Prisoner_day" + charValue + ".csv";

        FileInfo fileInfo = new FileInfo(fileName);
        if (fileInfo.Exists == false)
        {
            Debug.Assert(false, "���μ� comment : " + fileName + "�� �����ϴ� ������ �߰����ּ���.");
            return;
        }

        using (var reader = new StreamReader(fileName))
        {
            string line = reader.ReadLine();
            if (line != null)
            {
                string[] fields = line.Split(',');
                foreach (string field in fields)
                {
                    fieldNames.Add(field);
                }
            }
        }

        //Debug.Log("Field Names: " + string.Join(", ", fieldNames.ToArray()));
    }

    void Start()
    {

    }
}
