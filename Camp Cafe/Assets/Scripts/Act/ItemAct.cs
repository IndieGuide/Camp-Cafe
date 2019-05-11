using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAct : MonoBehaviour, IScriptAct {
    internal string[] dataArr;
    internal string roleName;
    internal string tipsStr;
    GameObject talkText;
    
    public ItemAct(string[] dataarr) {
        dataArr = dataarr;
    }

    public void DoAct() {
        LoadOriginData();
        ShowTips();
        ShowToolBoard();
        GameObject.Find("MakeButton").GetComponent<MakeDrink>().SetData(dataArr);
        //TalkShow.instance.IsPlayingText = false;
        TalkShow.instance.IsAllowClick = false;
        GameObject itemAreaCover = GameObject.Find("ItemAreaCover");
        itemAreaCover.SetActive(false);
    }

    private static void ShowToolBoard() {
        GameObject.Find("ToolsArea").GetComponent<ToolsManager>().ShowToolsBoard();
    }

    private void ShowTips() {
        talkText = GameObject.Find("TalkText");
        talkText.GetComponent<Text>().text = tipsStr;
        Debug.Log(tipsStr);
    }

    public void LoadOriginData() {
        roleName = dataArr[1].Trim();
        tipsStr = dataArr[2].Trim();
    }
}
