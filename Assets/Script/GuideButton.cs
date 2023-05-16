using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideButton : MonoBehaviour
{
    [SerializeField]
    private ScrollRect scrollRect;

    private void Awake()
    {
        //scrollRect = GetComponentInChildren<ScrollRect>();
        scrollRect = GameObject.Find("GuideScrollView").GetComponent<ScrollRect>();
    }

    private void OnEnable()
    {
        if (scrollRect != null)
        {
            scrollRect.verticalNormalizedPosition = 1f;
        }
    }

    //���̵�â �ݱ�
    public void close()
    {
        this.gameObject.SetActive(false);
    }

    //��ũ�� �� ���� �ø���
    public void upToTop()
    {
        //Debug.Log("Guide Scroll : UpToTop!! ");
        scrollRect.verticalNormalizedPosition = 1f;
    }

    //��ũ���� �ش� ��ġ��
    public void goToLoc()
    {
        //�ش� ��ư�� ���� ��������
        GuideTextInfo guideTextInfo = this.GetComponent<GuideTextInfo>();

        GameObject content = GameObject.Find("guide" + guideTextInfo.number);
        Debug.Log(content.name);

        RectTransform rectTransform = content.GetComponent<RectTransform>();

        float normalizedPosition
            = rectTransform.anchoredPosition.y
            / (rectTransform.rect.height - scrollRect.content.rect.height);

        scrollRect.verticalNormalizedPosition = 1f - normalizedPosition;
    }
}

