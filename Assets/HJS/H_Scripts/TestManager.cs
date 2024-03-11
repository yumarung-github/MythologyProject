using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace HJS
{ 
    public class TestManager : MonoBehaviour
    {
        [SerializeField]
        LayerMask farmzone;
        public GameObject obj;
        public int count;
        public float xLocalsize = 0;
        public float zLocalsize = 0;
        void Start()
        {

        }

        void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, farmzone))
            {
                Debug.Log("농사 가능");
            }

            if(Input.GetKeyDown(KeyCode.S))
            {
                for(int i = 0; i < count; i++)
                {
                    for(int j = 0; j < count; j++)
                    {
                        Instantiate(obj, new Vector3(obj.transform.localScale.x + xLocalsize, 0, obj.transform.localScale.z + zLocalsize), transform.rotation);
                        xLocalsize += obj.transform.localScale.x; 
                    }
                    zLocalsize -= obj.transform.localScale.z;
                    xLocalsize = 0;
                }

            }
        }
    }

}

