using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public tileComponent tile;
    public LayerMask farm;
    public LayerMask ground;
    Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    { 
        Vector3 direction = Vector3.forward - new Vector3(0, 2, 0);
        RaycastHit hit;

        Debug.DrawRay(transform.position + Vector3.up, direction, Color.red);
        if (Physics.Raycast(transform.position + Vector3.up, direction.normalized, out hit, 3f, farm | ground))
        {
            tileComponent temptile = hit.collider.GetComponent<tileComponent>();
            if(LayerMask.Equals(hit.collider.gameObject.layer, ground))
            {
                tile?.Exit();
                tile = null;
            }
            else if (tile != temptile || tile == null)
            {
                tile?.Exit();
                tile = temptile;
                tile?.Enter();
            }
        }
         
    }
}

