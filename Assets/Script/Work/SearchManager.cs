using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchManager : MonoBehaviour
{
    public enum SearchMode {
        body,
        face
    }

    [SerializeField] List<GameObject> _bodyPrefabList = new List<GameObject>();
    [SerializeField] List<GameObject> _facePrefabList = new List<GameObject>();

    private void Start()
    {
        Debug.Assert(_bodyPrefabList.Count == 0, "������ ���� ������ �־��ּ���");
        Debug.Assert(_facePrefabList.Count == 0, "�󱼼��� ���� ������ �־��ּ���");
    }

    public void startSearch(SearchMode searchMode)
    {
        List<GameObject> bodySearchObjectList = new List<GameObject>();
        List<GameObject> faceSearchObjectList = new List<GameObject>();

        //���⼭ ������ ����

        switch (searchMode)
        {
            case SearchMode.body:
                {
                    FindObjectOfType<UISearch>().showSearchObject(ref bodySearchObjectList);
                }
                break;
            case SearchMode.face:
                {
                    FindObjectOfType<UISearch>().showSearchObject(ref faceSearchObjectList);
                }
                break;
            default:
                return;
        }
    }
}