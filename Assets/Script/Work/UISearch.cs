using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISearch : MonoBehaviour
{
    //���μ� : startSearch �Լ��� ���� �����ϴ� ��ư�� ������ ������
    public void startFaceSearch()
    {
        SearchManager searchManager = FindObjectOfType<SearchManager>();
        if (searchManager == null)
            return;

        searchManager.startSearch(SearchManager.SearchMode.face);
    }

    public void startBodySearch()
    {
        SearchManager searchManager = FindObjectOfType<SearchManager>();
        if (searchManager == null)
            return;

        searchManager.startSearch(SearchManager.SearchMode.body);
    }

    public void showSearchObject(ref List<GameObject> objectList)
    {

    }    

    //���μ� : report �Լ��� �Ű� ��ư�� ������ ������
    public void report()
    {
        FindObjectOfType<HangingManager>().searchReport();
    }
}
