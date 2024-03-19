using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    public static DropManager instance;

    string RECENT_INDEX = "RECENT_INDEX_KEY";
    public int recentIndex;//유저 데이터 저장할 때 이거 갱신해줘야함.

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        if (PlayerPrefs.HasKey(RECENT_INDEX) == false) recentIndex = 0;
        else recentIndex = PlayerPrefs.GetInt(RECENT_INDEX);
        //유저데이터 만들면 데이터 값으로 넣기
    }

    void SaveAsCSV(List<ItemInfo> items, string path)
    {
        StringBuilder csv = new StringBuilder();
        csv.AppendLine("Name,Id,Value");

        foreach (ItemInfo item in items)
        {
            //csv.AppendLine(string.Format("{0},{1},{2}", item.itemName, item., item.value));
        }

        File.WriteAllText(path, csv.ToString());
    }

}
