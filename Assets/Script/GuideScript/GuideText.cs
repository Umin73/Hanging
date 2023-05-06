using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[AddComponentMenu("UI/DebugTextComponentName", 11)]
public class GuideText : MonoBehaviour
{
    public int day;
    public GuideDB guideDB;

    public TMP_FontAsset font;
    public int BasicFontSize;
    public int width;
    public int height;
    public Vector2 vector2;

    public GameObject scrollViewContent;
    public Button buttonPrefab;

    public List<GameObject> guideObjectList;

    private GuideButton guideButtonSC;
    private bool isLoaded = false;

    private void Awake()
    {
        guideButtonSC = GetComponent<GuideButton>();
    }

    private void Start()
    {
        for (int i = 0; i < guideDB.Entities.Count; i++)
        {
            if (guideDB.Entities[i].day == day)
            {
                if (guideDB.Entities[i].type == "����" || guideDB.Entities[i].type == "�Ҹ���"
                    || guideDB.Entities[i].type == "�ҼҸ���")
                {
                    createButton(guideDB.Entities[i]);
                }
                else if(guideDB.Entities[i].type == "����")
                {
                    createGuideText(guideDB.Entities[i], BasicFontSize, true, Color.black);
                }
                else
                {
                    createGuideText(guideDB.Entities[i], BasicFontSize, false, Color.gray);
                }
            }
        }

        isLoaded = true;
    }

    private void Update()
    {
    }

    void createGuideText(GuideDBEntity guideDB, int fontSize, bool isBold, Color fontColor)
    {
        GameObject guideText;
        if (guideDB.type == "����")
            guideText = new GameObject("guide" + guideDB.number); //���� �ش��ϴ� ���� ������ ������ ��ȣ�� �̸� ����
        else
            guideText = new GameObject("guideText");

        guideText.transform.SetParent(scrollViewContent.transform);

        //���̵峻�� �⺻ ����
        setGuideInfo(guideText, guideDB);

        TextMeshProUGUI newTextComponent = guideText.AddComponent<TextMeshProUGUI>();

        newTextComponent.text = guideDB.contents.ToString();

        //��Ʈ �÷�
        newTextComponent.color = fontColor;

        //��Ʈ ����
        newTextComponent.font = font;

        //��Ʈ ����
        if(isBold)
        {
            newTextComponent.fontStyle = FontStyles.Bold;
        }

        //��Ʈ ������
        newTextComponent.fontSize = fontSize;

        //�ؽ�Ʈ ��ġ, ũ�� ����
        RectTransform rectTransform = newTextComponent.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(width, height);
        rectTransform.localScale = vector2;

        //���� ���̸� ����Ʈ������ ���ͷ� ����
        ContentSizeFitter sizeFitter = guideText.AddComponent<ContentSizeFitter>();
        sizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

        guideObjectList.Add(guideText);
    }

    void createButton(GuideDBEntity guideDB)
    {
        Button newButton = Instantiate(buttonPrefab);
        newButton.transform.transform.SetParent(scrollViewContent.transform);

        //���̵峻�� �⺻ ����
        setGuideInfo(newButton.gameObject, guideDB);

        TextMeshProUGUI newTextComponent = newButton.GetComponentInChildren<TextMeshProUGUI>();

        newTextComponent.text = guideDB.contents.ToString();

        //Button�� rectTransform ����
        RectTransform rectTransform = newButton.GetComponent<RectTransform>();
        rectTransform.localScale = vector2;

        //Text�� rectTransform ����
        RectTransform btnRect = newTextComponent.GetComponent<RectTransform>();
        if (guideDB.type == "�Ҹ���") 
        {
            btnRect.offsetMin = new Vector2(5, 0);
        }
        else if (guideDB.type == "�ҼҸ���")
        {
            btnRect.offsetMin = new Vector2(10, 0);
        }
    }

    void setGuideInfo(GameObject guideText, GuideDBEntity guideDBEntity)
    {
        GuideTextInfo guideTextInfo = guideText.AddComponent<GuideTextInfo>();

        guideTextInfo.day = guideDBEntity.day;
        guideTextInfo.number = guideDBEntity.number;
        guideTextInfo.type = guideDBEntity.type;
    }

    public bool checkLoaded()
    {
        return isLoaded;
    }
}
