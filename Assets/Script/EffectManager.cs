using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
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

        yield return new WaitForSecondsRealtime(2f);
    }
}
