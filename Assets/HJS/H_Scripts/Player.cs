using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = transform.position - new Vector3(0,0,-1);
        RaycastHit hit;
        Debug.DrawRay(transform.position + Vector3.up, direction, Color.red);
        if(Physics.Raycast(transform.position + Vector3.up, direction.normalized, out hit, 3f))
        {
            Debug.Log(hit.collider.name);
        }
    }
}
