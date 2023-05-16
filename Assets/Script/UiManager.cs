using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject GuideWindow;

    [SerializeField]
    private AttackerMouseMove attackerMouseMove;
    [SerializeField]
    private Rope rope;

    private void Awake()
    {
        GuideWindow.SetActive(false);

        rope = GameObject.Find("rope").GetComponent<Rope>();
        attackerMouseMove = GameObject.Find("Prisoner(Clone)").GetComponent<AttackerMouseMove>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (GuideWindow.activeSelf == false)
            {
                GuideWindow.SetActive(true);

            }
            else
            {
                if (GuideWindow.activeSelf == true)
                {
                    GuideWindow.SetActive(false);
                    attackerMouseMove.SetPossibleTodesstrafe(true);
                    //Debug.Log("������ Ŭ�� Ǯ��");
                    rope.SetCutPossible(true);
                    //Debug.Log("���� �� Ǯ��");
                }
            }
        }
    }
}
