using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Badge : MonoBehaviour
{
    public static Badge instance;

    public bool stopDrag;

    private void Awake()
    {
        instance = this;
    }

    /*    private void Update()
        {
            //BossHand�� Badge ���� �� �巡�� X
            if (BossHand.instance.isSubmit)
                stopDrag = true;
        }*/

    private void OnMouseDown()
    {
        //BossHand�� Badge ���� �� �巡�� X
        if (BossHand.instance.isSubmit)
            stopDrag = true;
    }

    private void OnMouseDrag()
    {
        if (!stopDrag)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = pos;
        }
    }
}
