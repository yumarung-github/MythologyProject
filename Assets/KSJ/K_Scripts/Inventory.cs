using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    string INPUT_INDEX = "INPUT_INDEX_KEY";
    public int inputIndex;//유저 데이터 저장할 때 이거 갱신해줘야함.

    public TextMeshProUGUI itemNameObj;
    public TextMeshProUGUI itemNumObj;
    public TextMeshProUGUI itemDescObj;

    //인벤에 넣어주는 곳
    public List<Item> items = new List<Item>();//아이템슬롯 넣어주기

    public List<ItemInfo> infos = new List<ItemInfo>();

    public int slotNum;//인벤 아이템 슬롯 갯수
    public Item selectedItem;//선택된 아이템

    private void Awake()
    {
        items = transform.GetComponentsInChildren<Item>().ToList();
        slotNum = items.Count;
        InitEmpty();
        if (PlayerPrefs.HasKey(INPUT_INDEX) == false) inputIndex = 0;
        else inputIndex = PlayerPrefs.GetInt(INPUT_INDEX);
        //테스트용
        inputIndex = 0;
    }
    private void Start()
    {        
        //Debug.Log(Uimanager.instance.testItems[0].itemName);
        InputItem(Uimanager.instance.testItems[0], 1);
        InputItem(Uimanager.instance.testItems[1], 2);
        InputItem(Uimanager.instance.testItems[2], 3);
    }
    private void Update()
    {
        
    }
    void InitEmpty()
    {
        for(int i = 0; i < slotNum; i++)
        {
            items[i].itemIndex = i;
        }
    }
    public void InputItem(ItemInfo inputItemInfo, int number)//찾아서 갯수만큼 추가
    {
        Item foundItem = items.Find(item => item.itemInfo?.itemName == inputItemInfo.itemName);
        Debug.Log(foundItem);
        //넣을 아이템
        if(foundItem == null)
        {
            Debug.Log("빈 곳 index" + inputIndex);
            foundItem = items[inputIndex];
            Debug.Log(infos.Count);
            infos.Add(new ItemInfo());
            Debug.Log(inputIndex);
            infos[inputIndex] = inputItemInfo;
            foundItem.itemInfo = inputItemInfo;
            //없으면 빈곳중에 제일 앞에 넣어주기

            inputIndex++;//새로얻은거면 인벤토리 빈곳의 위치를 옮겨줌
        }

        foundItem.itemInfo.itemNum += number;//넣어준거니까 갯수는 무조건 바뀜
        foundItem.itemInfo.recentIndex = DropManager.instance.recentIndex;
        //최근 얻은 순으로 정렬하기 위함.(아이템의 얻은 순)
        DropManager.instance.recentIndex++;
        
        foundItem.UpdateItem();//넣어줬으면 이미지 업데이트해주기.
    }
    public void UseSelectedItem()
    {
        selectedItem.UseItem();
    }

    public void SelectItem(Item item)//선택된 아이템 정보 UI업데이트
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("NAME : ").Append(item.itemInfo.itemName);
        itemNameObj.text = sb.ToString();
        sb.Clear();
        sb.Append("Num : ").Append(item.itemInfo.itemNum.ToString());
        itemNumObj.text = sb.ToString();
        sb.Clear();
        sb.Append("Desc : ").Append(item.itemInfo.itemDesc.ToString());
        itemDescObj.text = sb.ToString();
        sb.Clear();
    }
    public void UpdateItemNum(Item item)
    {
        StringBuilder sb = new StringBuilder();        
        sb.Append("Num : ").Append(item.itemInfo.itemNum.ToString());
        
        itemNumObj.text = sb.ToString();
        sb.Clear();
    }

    public void SetInvenKey()
    {
        PlayerPrefs.SetInt(INPUT_INDEX, inputIndex);
    }
    public void SortInven()
    {
        infos.Sort();
        foreach(ItemInfo item in infos) 
        {
            Debug.Log("정렬할거" + item.itemName);
        }
        for(int i = 0; i< infos.Count; i++)
        {
            items[i].itemInfo = infos[i];
            items[i].UpdateItem();
        }
    }
}
