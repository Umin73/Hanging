using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgeManager : MonoBehaviour
{
    [SerializeField] private GameObject badgePrefab;

    public void spawnBadge(int size)
    {
        if(badgePrefab == null)
        {
            Debug.Assert(false, "���μ� : BadgeWrap�� badgePrefab�� ��� Ȯ�κ�Ź�帳�ϴ�.");
            return;
        }

        for (int index = 0; index < size; ++index)
        {
            Vector3 vector3 = transform.position;
            vector3.x = index - 1;
            Instantiate(badgePrefab, vector3, Quaternion.identity, transform);
        }
    }
}
