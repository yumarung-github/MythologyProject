using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //인벤에 넣어주는 곳
    public List<Item> items = new List<Item>();
    public Dictionary<int, bool> invenEmpty = new Dictionary<int, bool>();
    //public int headInvenNum;

    private void Awake()
    {
        //headInvenNum = 0;
    }
    public int HeadNumCal()
    {
        int i = 0;
        while (true)
        {
            if (invenEmpty[i] == false)
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
    public void InputItem(Item findItem, int number)//찾아서 갯수만큼 추가
    {
        Item foundItem = items.Find(item => item.itemInfo.itemName == findItem.itemInfo.itemName);
        if(foundItem != null)
        {
            foundItem.itemNum += number;
        }
        else
        {
            int headInvenNum = HeadNumCal();
            items[headInvenNum] = findItem;
            //findItem
            //없으면 빈곳중에 제일 앞에 넣어주기 
        }
        findItem.UpdateItem();//넣어줬으면 이미지 업데이트해주기.
    }
}
