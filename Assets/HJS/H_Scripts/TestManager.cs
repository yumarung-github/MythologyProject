using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HJS
{ 
    public class TestManager : MonoBehaviour
    {
        public List<Crop> cropList;
        [SerializeField]
        LayerMask farmzone;

        int groundMask;
        [SerializeField]
        tileComponent tile;
        public GameObject obj;
        Camera cam;
        Vector3 prevPos;

        void Start()
        {
            cam = Camera.main;
            prevPos = Camera.main.transform.position;
            groundMask = LayerMask.NameToLayer("Ground");
        }

        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, farmzone))
                {
                    Debug.Log(hit.collider.name);
                    tileComponent temptile = hit.collider.GetComponent<tileComponent>();

                    if(EventSystem.current.IsPointerOverGameObject() == false)
                    {
                        if (hit.collider.gameObject.layer == groundMask)
                        {
                            cam.transform.position = prevPos;
                            tile?.Exit();
                            tile = null;
                        }
                        else if (tile != temptile || tile == null)
                        {
                            cam.transform.position = temptile.transform.position + Vector3.up + (-Vector3.forward);
                            cam.transform.LookAt(temptile.transform.position);
                            tile?.Exit();
                            tile = temptile;
                            tile?.Enter();
                        }
                    }

                }
            }
        }


        public void Test(int index)
        {
            Instantiate(cropList[index], tile.transform.position, tile.transform.rotation);
        }
            
    }

}

