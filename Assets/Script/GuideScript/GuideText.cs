using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[AddComponentMenu("UI/DebugTextComponentName", 11)]
public class GuideText : MonoBehaviour
{
    [SerializeField]
    private int day;
    public GuideDBBase guideDBBase;

    public TMP_FontAsset font;
    public int BasicFontSize;
    public int width;
    public int height;
    public Vector2 vector2;

    public GameObject scrollViewContent;
    public Button buttonPrefab;

    private GuideButton guideButtonSC;

    public List<GameObject> guideObjectList;

    private void Awake()
    {
        day = HangingManager.day;

        guideButtonSC = GetComponent<GuideButton>();

        guideDBBase = GetGuideDB();
    }

    void Start()
    {
        Debug.Log("GuideDBBase�� Entities Count!! = " + guideDBBase.Entities.Count);
        for (int i = 0; i < guideDBBase.Entities.Count; i++)
        {
            if (guideDBBase.Entities[i].day == day)
            {
                //Debug.Log("day : " + guideDBBase.Entities[i].day + ", type : " + guideDBBase.Entities[i].type + ", " + guideDBBase.Entities[i].contents);
                if (guideDBBase.Entities[i].type == "����" || guideDBBase.Entities[i].type == "�Ҹ���"
                    || guideDBBase.Entities[i].type == "�ҼҸ���")
                {
                    createButton(guideDBBase.Entities[i]);
                }
                else if(guideDBBase.Entities[i].type == "����")
                {
                    createGuideText(guideDBBase.Entities[i], BasicFontSize, true, Color.black);
                }
                else
                {
                    createGuideText(guideDBBase.Entities[i], BasicFontSize, false, Color.gray);
                }
            }
        }
    }

    private void Update()
    {
    }

    public GuideDBBase GetGuideDB()
    {
        return Resources.Load<GuideDB_day1>("GuideResources/GuideDB_day" + day);
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
}
