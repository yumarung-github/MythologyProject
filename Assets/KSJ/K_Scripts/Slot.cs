using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public Item item;

    void Start()
    {
        item = transform.GetComponentInChildren<Item>();
        item.itemPosition = transform.position;
    }

}
