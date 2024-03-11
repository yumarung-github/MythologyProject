using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uimanager : MonoBehaviour
{
    public static Uimanager instance;

    [Header("메뉴 캔버스")]
    public GameObject menuCanvas;
    [Space(10f)]
    public GameObject inventory;

    public List<ItemInfo> items = new List<ItemInfo>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }
    public void SetEndFrameFoo(Item item)
    {
        StartCoroutine(SetEndTrans(item));
    }
    private IEnumerator SetEndTrans(Item item)
    {
        yield return new WaitForEndOfFrame();
        item.transform.position = item.slot.transform.position;
        item.gameObject.SetActive(true);
    }
}
