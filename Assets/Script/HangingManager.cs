using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HangingManager : MonoBehaviour
{
    public bool isTodesstrafe;
    public Offender offender;
    public static int day = 2;

    private void Awake()
    {
        offender = FindObjectOfType<Offender>();
    }

    //public void ConvertScene()
    //{
    //    SceneManager.LoadScene("SampleScene");
    //}

    public void EndTodesstrafe()
    {
        offender.SetisPossibleTodesstrafe(false);
        DestroyAllLineAndWindow();
    }

    public void Todesstrafe()
    {
        EndTodesstrafe();
        isTodesstrafe = true;

        //���� �Ǻ�//
        if (offender.offenderData.isHanging == 0) Debug.Log("True");
        else Debug.Log("False");
        Debug.Log("����");
    }

    public void UnTodesstrafe()
    {
        EndTodesstrafe();
        isTodesstrafe = false;

        //���� �Ǻ�//
        if (offender.offenderData.isHanging == 1) Debug.Log("True");
        else Debug.Log("False");
        Debug.Log("����");
    }

    public void DestroyAllLineAndWindow()
    {
        offender.StopAllCoroutines();
        foreach (Line line in Line.lineList)
        {
            Destroy(line.lineObject);
            Destroy(line.windowObject);
        }
        Line.lineList.Clear();
    }
}