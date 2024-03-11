using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileComponent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            Debug.Log("ccc");
            Debug.Log(transform.GetChild(0).gameObject.name);
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}

