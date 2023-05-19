using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MakeStamement : MonoBehaviour
{
    public GameObject uiPrefab;
    public AttackerInfo attackerInfo;
    public TMP_Text txtALlTmp;
    public TMP_Text forWidth;
    private bool compareMent;
    private bool flag;
    private void Start()
    {
        attackerInfo= FindObjectOfType<AttackerInfo>();
        flag = false;
        //MakeMentList();
    }
    private void Update()
    {
        if (flag == false)
        {
            
            flag = true;
            MakeMentList();

        }
    }
    public void AddMent(string str, bool compareMent, int lieORinfoErrorValue)
    {
        var newUi = Instantiate(uiPrefab, this.transform.position, Quaternion.identity);
        

        //str = "�ȳ��ϼ���ȳ��ϼ���ȳ��ϼ���ȳ��ϼ���ȳ��ϼ���";

        string txtAll = str;
        int lineCnt = 1;
        if (txtALlTmp == null) Debug.Log("���¤�");
        //txtALlTmp=new tmp
        txtALlTmp.text = txtAll;

        string resultStr = "";
        string addStr = "";

        //���ڰ� â�� �Ѿ�� ���̸� ���๮�� �߰���//
        if (txtALlTmp.preferredWidth >= 300)
        {
            while (txtALlTmp.preferredWidth > 300)
            {
                //�ʱ�ȭ
                addStr = "";
                forWidth.text = "";

                for (int i = 0; forWidth.preferredWidth <= 300; i++)
                {
                    addStr = addStr + txtAll[0];
                    txtAll = txtAll.Remove(0, 1);
                    txtALlTmp.text = txtAll;

                    forWidth.text = addStr; // addStr�� ���̸� �˾Ƴ��� ����

                }
                lineCnt++;
                resultStr = resultStr + addStr + System.Environment.NewLine; //�ٹٲ�


            }

            resultStr = resultStr + txtAll;

            //�����ٸ����� ������ ���� ����
            if (compareMent == false)
            {
                newUi.GetComponent<ChangeTextTexture>().lastMent = txtAll;
            }
        }
        else
        {
            //txtALlTmp.text = resultStr; //����/�������� �۾� ���� �Ǵ��� ����
            //�����ٸ����� ������ ���� ����
            if (compareMent == false)
            {
                newUi.GetComponent<ChangeTextTexture>().lastMent = resultStr;
            }

            resultStr = str;
        }


        newUi.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = resultStr;
        newUi.GetComponent<ChangeTextTexture>().mentTureORFalse = compareMent;
        newUi.GetComponent<ChangeTextTexture>().lieORinfoErrorValue = lieORinfoErrorValue;


        newUi.transform.parent = this.transform;

        Debug.Log("��Ʈ �߰�");
    }
    void MakeMentList()
    {
        string[] fixtext = { "�̸� : ", "���� : ", "������� : ", "���˰��� : " };
        for (int i = 0; i < 4; i++)
        {
            compareMent = attackerInfo.recordData.correctState[i].Equals(attackerInfo.recordData.currentState[i]) ? true : false;
            AddMent(fixtext[i] + attackerInfo.recordData.currentState[i], compareMent, attackerInfo.recordData.lieORinfoErrorValue);
        }
    }
}
