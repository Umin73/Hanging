using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CursorScript : MonoBehaviour
{
    Texture2D original;
    HangingManager hangingManager;
    [SerializeField] Texture2D changed;

    public bool penCursor;

    void Start()
    {
        original = Resources.Load<Texture2D>("OriginalCursor");
        hangingManager = FindObjectOfType<HangingManager>();
        penCursor = false;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if(hit.collider != null)
            {
                GameObject clickObj = hit.transform.gameObject;
                Debug.Log(clickObj.name);

                if (hit.transform.gameObject.name == "penButton")
                {
                    if (!penCursor)
                        penCursor = true;
                    else
                        penCursor = false;
                }
                if (hit.transform.gameObject.CompareTag("statement") && penCursor==true && hit.transform.gameObject.GetComponent<ChangeTextTexture>().afterClick == false)
                {
                    if (!hit.transform.gameObject.GetComponent<ChangeTextTexture>().mentTureORFalse)
                    {
                        Debug.Log("������ ������ �ٸ�");
                        if (hit.transform.gameObject.GetComponent<ChangeTextTexture>().lieORinfoErrorValue == 1) // lie�� ���
                        {
                            Debug.Log("�����Դϴ�");
                            /*
                            txtALlTmp.text = addStr + "����ġ -> ����";
                            if (txtALlTmp.preferredWidth >= 300)
                            {
                                //���� �۾��� �Ʒ��ٷ�
                                resultStr = resultStr + System.Environment.NewLine + "����ġ -> ����";
                            }
                            else
                            {
                                //���� �۾� �׳� �߰�
                                resultStr = resultStr + "����ġ -> ����";
                            }
                            */

                        }
                        else // infoError�� ���
                        {
                            Debug.Log("���������Դϴ�");
                        }

                        //������ �ٸ� ���� �� ����
                        hit.transform.gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color32(217,66, 66,255);
                        hit.transform.gameObject.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().color = Color.white;
                        hit.transform.gameObject.GetComponent<ChangeTextTexture>().afterClick = true;
                    }
                    else
                    {
                        Debug.Log("������ ������ ����");
                        StartCoroutine(hangingManager.StartStateWrong());

                        hit.transform.gameObject.GetComponent<ChangeTextTexture>().afterClick = true;


                    }
                    
                }
            }
        }
    }

    private void OnMouseEnter()
    {
        if (penCursor)
        {
            Cursor.SetCursor(changed, Vector2.zero, CursorMode.Auto);
        }
        
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(original, Vector2.zero, CursorMode.Auto);
    }
}


