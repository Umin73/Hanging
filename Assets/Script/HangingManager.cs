using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HangingManager : MonoBehaviour
{
    public bool isTodesstrafe;
    public Offender offender;

    private void Awake()
    {
        offender = FindObjectOfType<Offender>();
    }

    public void ConvertScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void EndTodesstrafe()
    {
        offender.SetisPossibleTodesstrafe(false);
    }

    public void Todesstrafe()
    {
        EndTodesstrafe();
        isTodesstrafe = true;
        Debug.Log("����");
        Debug.Log(isTodesstrafe);

        DestroyAllLineAndWindow();
    }

    public void UnTodesstrafe()
    {
        EndTodesstrafe();
        isTodesstrafe = false;
        Debug.Log("����");
    }

    public void DestroyAllLineAndWindow()
    {
        StopAllCoroutines(); // �ӽ� ���� ���� �߰��� ��� ����
        foreach (Line line in Line.lineList)
        {
            Destroy(line.lineObject);
            Destroy(line.windowObject);
        }
        Line.lineList.Clear();
    }
}