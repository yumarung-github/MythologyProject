using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DropDownControl : MonoBehaviour
{
    TMP_Dropdown options;
    List<string> optionList = new List<string>();
    int currentOption;

    string DROPDOWN_KEY = "DROPDOWN_KEY";
    void Awake()
    {
        if (PlayerPrefs.HasKey(DROPDOWN_KEY) == false) currentOption = 0;
        else currentOption = PlayerPrefs.GetInt(DROPDOWN_KEY);        
    }
    private void Start()
    {
        options = this.GetComponent<TMP_Dropdown>();

        options.ClearOptions();

        optionList.Add("Option 1");
        optionList.Add("Option 2");
        optionList.Add("Option 3");
        optionList.Add("Option 4");

        options.AddOptions(optionList);

        options.onValueChanged.AddListener(delegate { setDropDown(options.value); });
        setDropDown(currentOption);

        options.value = currentOption;
    }
    void setDropDown(int option)
    {
        PlayerPrefs.SetInt(DROPDOWN_KEY, option);

        // option 관련 동작
        Debug.Log("current option : " + option);
    }
}
