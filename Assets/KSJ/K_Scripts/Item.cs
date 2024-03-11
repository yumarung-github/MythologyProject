using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]
public class ItemInfo
{
    public Sprite sprite;
    public string itemName;
    [TextArea (3, 5)]
    public string ItemDesc;
    public ItemInfo(Sprite sprite, string itemName, string itemDesc)
    {
        this.sprite = sprite;
        this.itemName = itemName;
        ItemDesc = itemDesc;
    }
}

public class Item : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{    
    public Slot slot;
    private GraphicRaycaster raycaster;

    [Tooltip("아이템의 원래 위치")]
    public Vector3 itemPosition;
    public Image itemImage;
    public ItemInfo itemInfo;
    public int itemNum; 

    Color offColor;
    Color onColor;

    void Start()
    {
        raycaster = Uimanager.instance.menuCanvas.GetComponent<GraphicRaycaster>();
        slot = transform.GetComponentInParent<Slot>();
        itemImage = GetComponent<Image>();
        itemPosition = slot.transform.position;

        offColor = new Color(0, 0, 0, 0);
        onColor = new Color(1, 1, 1, 1);

        UpdateItem();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent = Uimanager.instance.menuCanvas.transform;
        itemImage.raycastTarget = false;
        Debug.Log("드래그시작");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {                
        //transform.position = new Vector3(0, 0, 0);
        transform.parent = slot.transform;
        gameObject.SetActive(false);
        //그리드 레이아웃 해결법
        Uimanager.instance.SetEndFrameFoo(this);
        itemImage.raycastTarget = true;
    }
    
    public void UpdateItem()
    {
        if (itemInfo != null)
        {
            itemImage.sprite = itemInfo.sprite;
            itemImage.color = onColor;
        }
        else
        {
            itemImage.color = offColor;
        }
    }
    public void UseItem()
    {
        itemInfo = null;
        UpdateItem();
    }
}
