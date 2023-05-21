using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour, IListener
{
    private GameObject illusionFullScreen;

    private void Awake()
    {
        illusionFullScreen = GameObject.Find("etc_effect").transform.Find("illusion_FullScreen").gameObject;
        Debug.Assert(illusionFullScreen, "���μ� : illusion_FullScreen ������Ʈ�� �����ϴ�.");
    }

    public IEnumerator activeFullillusion()
    {
        illusionFullScreen.SetActive(true);
        yield return new WaitForSecondsRealtime(5f);
        illusionFullScreen.SetActive(false);
    }

    public void OnEvent(string eventType, Component sender, object parameter = null)
    {
        switch (eventType)
        {
            case "activeFullillusion":
                StartCoroutine(activeFullillusion());
                break;
        }
    }
}
