using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HJS
{ 
    public class TestManager : MonoBehaviour
    {
        [SerializeField]
        LayerMask farmzone;
        public GameObject obj;
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
            
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                point.z += 1.5f;
                Instantiate(obj, point, transform.rotation);
            }
        }
    }

}

