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
    public int itemIndex;

    Color offColor;
    Color onColor;

    void Awake()
    {
        
        slot = transform.GetComponentInParent<Slot>();
        itemImage = GetComponent<Image>();
        itemPosition = slot.transform.position;

        offColor = new Color(1, 1, 1, 0);
        onColor = new Color(1, 1, 1, 1);

        //UpdateItem();
    }
    void Start()
    {
        raycaster = Uimanager.instance.menuCanvas.GetComponent<GraphicRaycaster>();
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
    
    public void UpdateItem()//이미지 업데이트 해주는거
    {
        if (itemInfo != null)
        {
            Debug.Log(itemInfo.itemName);
            itemImage.sprite = itemInfo.sprite;
            itemImage.color = onColor;
        }
        else
        {
            itemImage.color = offColor;
        }
    }
    public void UseItem()//사용하는거 1개면 다 사용했으니 없애고
    {
        if(itemNum == 1)
        {
            itemInfo = null;
            itemNum--;
            UpdateItem();
        }
        else if(itemNum > 1)
        {
            itemNum--;
            UpdateItem();
        }
        
    }
}
