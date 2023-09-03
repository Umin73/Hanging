using Kino;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HangingManager : MonoBehaviour, IListener
{
    public AttackerMouseMove attackerMouseMove;
    public AttackerInfo attackerInfo;
    private AnalogGlitch analogGlitch;
    [SerializeField] BossHand bossHand;
    HangingTimer hangingTimer;
    public DialogWindowController dialogWindowController;
    private UiManager _uiManager;

    [SerializeField] GameObject convertEffect, nextDayEffect,attackerPrefab;
    public ScrollViewController scrollViewController;

    public bool isTodesstrafe, isExecuteAsk;
    public bool isStatementWrongProcess;

    public GameObject staButton;

    private int _judgeCount = 0;
    public int judgeCount
    {
        get { return _judgeCount; }
        set { 
            _judgeCount = value;
            EventManager.instance.postNotification("updateAttackerCountCCTV", this, _judgeCount + 1);
        }
    }
    private bool isEndCompulsoryDialog;
    private int _correctJudgeCount = 0;
    private int _discorrectJudgeCount = 0;
    private int _discorrectAndTodesstrafedPersonCount = 0;

    public static int day = 1;
#if UNITY_EDITOR
    public int debug_day = 1;
#endif

    private static int badgeCount = 3;

    private void Awake()
    {
#if UNITY_EDITOR
        day = debug_day;
#endif

        dialogWindowController = FindObjectOfType<DialogWindowController>();
        hangingTimer = FindObjectOfType<HangingTimer>();
        analogGlitch = FindObjectOfType<AnalogGlitch>();
        _uiManager = FindObjectOfType<UiManager>();

        scrollViewController=FindObjectOfType<ScrollViewController>();
    }

    void Start()
    {
        EventManager.instance.addListener("amnesty", this);
        EventManager.instance.addListener("todesstrafe", this);
        EventManager.instance.addListener("executeAsk", this);

        createAttacker();

        if (day >= 6)
            OnStaButton();

        FindObjectOfType<BadgeManager>().spawnBadge(badgeCount);
    }

    public void EndTodesstrafe()
    {
        DestroyAllLineAndWindow();
        NextAttacker();

        if ((isExecuteAsk) && (attackerInfo.checkAttackerReplyAsk() == false))
        {
            if (Ask.isFirst)
            {
                Ask.isFirst = false;
                EventManager.instance.postNotification("dialogEvent", this, 63);
            }
            else
            {
                EventManager.instance.postNotification("dialogEvent", this, UnityEngine.Random.Range(64, 71));
            }
        }
    }

    public void Todesstrafe()
    {
        isTodesstrafe = true;

        //���� �Ǻ�//
        if (checkCorrectTodesstrafe(0)) 
            Debug.Log("True");

        Debug.Log("����");

        EndTodesstrafe();
    }

    public void Amnesty()
    {
        //���� �Ǻ�//
        if (checkCorrectTodesstrafe(1)) 
            Debug.Log("True");

        Debug.Log("����");

        EndTodesstrafe();
    }

    private bool checkCorrectTodesstrafe(int mode)
    {
        if (isEndCompulsoryDialog == false || mode == attackerInfo.recordData.isHanging)
        {
            Debug.Log(attackerInfo.recordData.isHanging);

            ++_correctJudgeCount;

            return true;
        }
        else
        {
            Debug.Log(attackerInfo.recordData.isHanging);

            StartCoroutine(StartHoldOutHands());

            ++_discorrectJudgeCount;
            if (mode == 0)
                ++_discorrectAndTodesstrafedPersonCount;

            return false;
        }
    }

    private void DestroyAllLineAndWindow()
    {
        attackerMouseMove.StopAllCoroutines();
        foreach (Line line in Line.lineList)
        {
            Destroy(line.lineObject);
            Destroy(line.windowObject);
        }
        Line.lineList.Clear();
    }

    void NextAttacker()
    {
        judgeCount++;

        StartCoroutine(ConvertAttackerEffect());

        createAttacker();
    }

    IEnumerator ConvertAttackerEffect()
    {
        convertEffect.SetActive(true);

        yield return new WaitForSecondsRealtime(1.5f);

        convertEffect.SetActive(false);
    }

    IEnumerator EndDayEffect()
    {
        nextDayEffect.SetActive(true);

        yield return new WaitForSecondsRealtime(2.2f);

        nextDayEffect.SetActive(false);
    }

    IEnumerator StartHoldOutHands()
    {
        yield return new WaitForSecondsRealtime(1.25f);
        EventManager.instance.postNotification("badge", this, null);
        EventManager.instance.postNotification("dialogEvent", this, UnityEngine.Random.Range(53, 58));
        yield return new WaitForSecondsRealtime(3.0f);
        isStatementWrongProcess = false;
    }

    public IEnumerator StartStateWrong() //진술?�� ?��?��?�� 경우 ?��?���? 출력 & 뱃�?? ?��?�� 
    {
        isStatementWrongProcess = true;

        analogGlitch._isGlitch = true;
        yield return new WaitForSecondsRealtime(0.75f);
        analogGlitch._isGlitch = false;

        StartCoroutine(StartHoldOutHands());
    }

    public void EndCompulsory()
    {
        isEndCompulsoryDialog = true;

        EventManager.instance.postNotification("dialogEvent", this, "createAttacker");
        EventManager.instance.postPossibleEvent();

        hangingTimer.SetTimer(true);
        dialogWindowController.SetEnabled(true);
    }

    void createAttacker()
    {
        if (attackerMouseMove != null)
            Destroy(attackerMouseMove.gameObject);

        GameObject attacker = Instantiate(attackerPrefab);
        attackerMouseMove = attacker.GetComponent<AttackerMouseMove>();
        attackerInfo = attacker.GetComponent<AttackerInfo>();

        if (isEndCompulsoryDialog)
        {
            EventManager.instance.postPossibleEvent();

            attackerMouseMove.setAllPossible();
            Rope rope = attacker.transform.Find("rope").GetComponent<Rope>();
            Debug.Assert(rope, "rope�? �? 찾았?��?��?��.");
            if (rope)
                rope.isPossibleCut = true;
        }

        isTodesstrafe = false;
        isExecuteAsk = false;
    }

    public HangingInfoWrapper getHangingInfo()
    {
        return new HangingInfoWrapper(day, _judgeCount, _correctJudgeCount, _discorrectJudgeCount, _discorrectAndTodesstrafedPersonCount);
    }

    public IEnumerator endDay()
    {
        _uiManager.hideScreenCanvas();
        
      
        //조�?�수 comment : 7?��차에 ?���? ?��?���? 게임 종료?�� ?��?�� ?��?��, 추후?�� �?경�???��?�� ?��?��
        if (day == 7)
        {
            StartCoroutine(FindObjectOfType<GameManager>().endGame());
        }
        else
        {
            yield return StartCoroutine(EndDayEffect());

            _uiManager.showScreenCanvas();
            _uiManager.showDominantImage();
        }
    }

    public void convertSceneNextDay()
    {
        //?��근길 로드�? �?경해?�� ?��
        //?��근길?�� ?��?�� ?��?�� day 증�???��?�� 것으�? �?경해?�� ?��
        day++;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void subtractBadgeCount()
    {
        --badgeCount;
    }

    public void OnEvent(string eventType, Component sender, object parameter = null)
    {
        switch (eventType)
        {
            case "amnesty":
                Amnesty();
                break;
            case "todesstrafe":
                Todesstrafe();
                break;
            case "executeAsk":
                isExecuteAsk = true;
                break;
        }
    }

    private void OnStaButton()
    {
        staButton.SetActive(true);
    }

    public void searchReport()
    {

    }

    public bool checkEndCompulsoryDialog()
    {
        return isEndCompulsoryDialog;
    }
}