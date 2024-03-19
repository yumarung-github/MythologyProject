using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum SORT_KIND
{
    NAME,
    RECENT
}
[Serializable]
public class ItemInfo : IComparable<ItemInfo>, IEquatable<ItemInfo>
{
    public Sprite sprite;
    public string itemName;
    [TextArea (3, 5)]
    public string itemDesc;

    public int recentIndex;
    public int itemNum;

    public string sortStandard;

    public ItemInfo(Sprite sprite, string itemName, string itemDesc)
    {
        this.sprite = sprite;
        this.itemName = itemName;
        this.itemDesc = itemDesc;
        recentIndex = DropManager.instance.recentIndex;
        itemNum = 0;
        sortStandard = itemName;
    }
    public ItemInfo()
    {

    }

    public int CompareTo(ItemInfo other)
    {
        return sortStandard.CompareTo(other.sortStandard); 
    }
    public bool Equals(ItemInfo other)
    {
        return sortStandard.Equals(sortStandard);
    }
}

public class Item : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{    
    public Slot slot;
    private GraphicRaycaster raycaster;

    [Tooltip("아이템의 원래 위치")]
    public Vector3 itemPosition;
    public Image itemImage;
    public ItemInfo itemInfo;
    public int itemIndex;

    Color offColor;
    Color onColor;

    void Awake()
    {        
        slot = transform.GetComponentInParent<Slot>();
        itemImage = GetComponent<Image>();
        itemPosition = slot.transform.position;

        offColor = new Color(1, 1, 1, 1);
        onColor = new Color(1, 1, 1, 1);
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
            itemImage.sprite = itemInfo.sprite;
            //itemImage.color = onColor;
        }
    }
    public void UseItem()//사용하는거 1개면 다 사용했으니 없애고
    {
        if(itemInfo.itemNum == 1)
        {
            Debug.Log("아이템 비우기" + this.itemInfo.itemName);
            itemInfo.itemNum = 0;
            Uimanager.instance.inventory.infos.RemoveAt(itemIndex);
            Uimanager.instance.inventory.SortInven();
            Uimanager.instance.inventory.inputIndex--;
            Uimanager.instance.inventory.SetInvenKey();
            Uimanager.instance.inventory.
                items[Uimanager.instance.inventory.inputIndex].itemInfo = null;
            Uimanager.instance.inventory.
                items[Uimanager.instance.inventory.inputIndex].itemImage.sprite = null;
            //Uimanager.instance.inventory.
            //    items[Uimanager.instance.inventory.inputIndex].itemImage.color = offColor;
        }
        else if(itemInfo.itemNum > 1)
        {            
            itemInfo.itemNum--;
            Debug.Log(itemInfo.itemNum);
            Uimanager.instance.inventory.UpdateItemNum(this);
            UpdateItem();
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Uimanager.instance.inventory.selectedItem = this;
        Uimanager.instance.inventory.SelectItem(this);
    }
}
