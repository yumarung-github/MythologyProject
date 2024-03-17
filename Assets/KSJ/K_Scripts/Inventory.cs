using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public TextMeshProUGUI itemNameObj;
    public TextMeshProUGUI itemNumObj;
    public TextMeshProUGUI itemDescObj;

    //인벤에 넣어주는 곳
    public List<Item> items = new List<Item>();//아이템슬롯 넣어주기
    public Dictionary<int, bool> invenFilledDic = new Dictionary<int, bool>();
    public int slotNum;//인벤 아이템 슬롯 갯수
    public Item selectedItem;

    private void Awake()
    {
        items = transform.GetComponentsInChildren<Item>().ToList();
        slotNum = items.Count;
        InitEmpty();        
    }
    private void Start()
    {
        //Debug.Log(Uimanager.instance.testItems[0].itemName);
        InputItem(Uimanager.instance.testItems[0], 1);
        InputItem(Uimanager.instance.testItems[1], 2);
        InputItem(Uimanager.instance.testItems[2], 3);
    }
    void InitEmpty()
    {
        for(int i = 0; i < slotNum; i++)
        {
            invenFilledDic[i] = false;
            items[i].itemIndex = i;                        
        }
    }
    public int HeadNumCal()
    {
        int i = 0;
        while (true)
        {
            if (invenFilledDic[i] == false)
            {
                break;
            }
            else
            {
                i++;
            }
        }
        return i;
    }
    public void InputItem(ItemInfo findItem, int number)//찾아서 갯수만큼 추가
    {
        Item foundItem = items.Find(item => item.itemInfo.itemName == findItem.itemName);

        //넣을 아이템
        if(foundItem == null)
        {
            int headInvenNum = HeadNumCal();
            Debug.Log("빈 곳 index" + headInvenNum);
            foundItem = items[headInvenNum];

            foundItem.itemInfo = findItem;
            invenFilledDic[headInvenNum] = true;
            //없으면 빈곳중에 제일 앞에 넣어주기
        }

        foundItem.itemNum += number;//넣어준거니까 갯수는 무조건 바뀜
        foundItem.itemInfo.recentIndex = DropManager.instance.recentIndex;
        //최근 얻은 순으로 정렬하기 위함.
        DropManager.instance.recentIndex++;
        
        foundItem.UpdateItem();//넣어줬으면 이미지 업데이트해주기.
    }
    public void UseSelectedItem()
    {
        selectedItem.UseItem();
    }

    public void SelectItem(Item item)
    {
        itemNameObj.text = item.itemInfo.itemName;
        itemNumObj.text = item.itemNum.ToString();
        itemDescObj.text = item.itemInfo.ItemDesc;
    }

    public void ChangeItem()
    {

    }
}
