using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAct : MonoBehaviour, IScriptAct {
    private string[] dataArr;
    string roleName;
    string tipsStr;
    GameObject talkText;
    
    public ItemAct(string[] dataarr) {
        dataArr = dataarr;
    }

    public void DoAct() {
        ShowTips();
        ShowToolBoard();
        GameObject.Find("MakeButton").GetComponent<MakeDrink>().SetData();
        TalkShow.instance.IsPlayingText = false;
    }

    private static void ShowToolBoard() {
        GameObject.Find("ToolsArea").GetComponent<ToolsManager>().ShowToolsBoard();
    }

    private void ShowTips() {
        talkText = GameObject.Find("TalkText");
        talkText.GetComponent<Text>().text = tipsStr;
    }

    public void LoadOriginData() {
        roleName = dataArr[1].Trim();
        tipsStr = dataArr[2].Trim();
    }
}
