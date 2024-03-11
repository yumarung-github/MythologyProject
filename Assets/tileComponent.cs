using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileComponent : MonoBehaviour
{
    public void Enter()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void Exit()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}

