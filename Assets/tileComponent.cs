using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tileComponent : MonoBehaviour
{
    [SerializeField]
    GameObject childObj;

    [SerializeField]
    GameObject stateUI;

    [SerializeField]
    Crop crop;


    private void Awake()
    {
        stateUI = FindObjectOfType<VerticalLayoutGroup>().gameObject;
    }

    private void Start()
    {
        childObj = transform.GetChild(0).gameObject;
        stateUI.SetActive(false);

    }
    public void Enter()
    {
        childObj.SetActive(true);
        stateUI.SetActive(true);
    }

    public void Exit()
    {
        childObj.SetActive(false);
        stateUI.SetActive(false);
    }

    private void Update()
    {
    }
}

