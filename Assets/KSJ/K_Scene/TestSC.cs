using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestSC : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 endVec = Vector3.forward - new Vector3(0, 2f, 0);
        Debug.DrawRay(transform.position + Vector3.up, endVec, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, endVec, out hit, 3f))
        {
            Debug.Log(hit.collider.name);
        }
    }
}
