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

    ReadPrisonerInfo readPrisonerInfo;  //�ӽ�

    private void Awake()
    {
        readPrisonerInfo = GetComponent<ReadPrisonerInfo>();    //�ӽ�
        day = readPrisonerInfo.day; //�ӽ�

        char charValue = (char)(day + '0');

        fileName = "Prisoner_day";
        fileName += charValue;

        fieldNames = new List<string>();

        using (var reader = new StreamReader("Assets/Resources/" + fileName + ".csv"))
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
