using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UIElements;

public class tileComponent : MonoBehaviour
{
    GameObject childObj;

    bool isSelect;

    public bool IsSelect
    {
        get => isSelect;
        set
        {
            isSelect = value;
            if (isSelect)
                ShowState();
        }
    }    

    private void Start()
    {
        childObj = transform.GetChild(0).gameObject;
    }
    public void Enter()
    {
        childObj.SetActive(true);
    }

    public void Exit()
    {
        childObj.SetActive(false);
    }

    private void Update()
    {
        IsSelect = childObj.activeSelf;
    }

    void ShowState()
    {
        Debug.Log("UI 선택창 나옴(빈 타일이면 작물 선택 농사가 있는 타일이면 현재 상태 표시)");
    }
}

