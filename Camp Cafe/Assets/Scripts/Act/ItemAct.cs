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
    MakeDrink makeDrink;
    private void Start() {
        makeDrink = GameObject.Find("MakeButton").GetComponent<MakeDrink>();
    }
    public ItemAct(string[] dataarr) {
        dataArr = dataarr;
    }

    public void DoAct() {
        ShowTips();
        ShowToolBoard();
        TalkShow.instance.IsPlayingText = false;
    }

    private static void ShowToolBoard() {
        TalkShow.instance.toolBoard.SetActive(true);
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
