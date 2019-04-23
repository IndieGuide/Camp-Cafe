using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    Text[] optionText;
    TalkShow talkShow;
    public BranchManager branchManager;

    // Start is called before the first frame update
    void Start()
    {
        talkShow = GameObject.Find("Canvas").transform.GetComponent<TalkShow>();
        optionText = gameObject.GetComponentsInChildren<Text>();
    }


    public void ManageBranch(List<string[]> optiondata) {
        branchManager.GetBranchData(optiondata);
        int optionNumber = optiondata.Count;
        //循环记录每个分支前面有多少行，后面有多少行
        for (int i = 0; i < optionNumber; i++) {
            //更改按钮文本
            optionText[i].text = optiondata[i][0];
            //使按钮点击生效
            optionText[i].GetComponent<OptionText>().IsAllowClicked = true;
            optionText[i].GetComponent<OptionText>().TextIndex = i;
        }
    }
}
