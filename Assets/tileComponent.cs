using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;

public class tileComponent : MonoBehaviour
{
    [SerializeField]
    GameObject childObj;

    [SerializeField]
    GameObject stateUI;


    private void Awake()
    {
        stateUI = FindObjectOfType<Image>().gameObject;
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
        stateUI.transform.position = Camera.main.WorldToScreenPoint(transform.position);
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

