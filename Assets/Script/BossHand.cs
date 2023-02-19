using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHand : MonoBehaviour
{
    public static BossHand instance;

    public GameObject button;

    private Vector3 originalLoca;
    private Vector3 destination;

    private bool isHoldOut;
    public bool isSubmit;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        originalLoca = transform.position;
        destination = new Vector3(3, transform.position.y, transform.position.z);
        isHoldOut = false;
        isSubmit = false;
    }

    private void Update()
    {
        if (isSubmit)
        {
            //BossHand�� badge �浹 �� ���� ȸ�� ����
            Invoke("takeaBadge", 1.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isSubmit = true;

        //badge�� BossHand�� �ڽ�����
        GameObject badge = GameObject.FindGameObjectWithTag("badge");
        badge.transform.parent = this.gameObject.transform;
    }

    public void holdOutHand() //��� �� ���б�
    {
        if(!isHoldOut)
        {
            StartCoroutine(MoveTo(gameObject, destination));
            isHoldOut = true;
        }
    }

    public void takeaBadge() //���� ȸ��
    {
        StartCoroutine(MoveTo(gameObject, originalLoca));
        isSubmit = false;
        isHoldOut = false;
    }

    IEnumerator MoveTo(GameObject obj, Vector3 toPos)
    {
        float cnt = 0;
        Vector3 nowPos = obj.transform.position;

        while(true)
        {
            cnt += Time.deltaTime;
            obj.transform.position = Vector3.Lerp(nowPos, toPos, cnt);

            if(cnt >= 1)
            {
                obj.transform.position = toPos;
                break;
            }
            yield return null;
        }
    }

}
