using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkAct : MonoBehaviour,IScriptAct
{
    internal string name;
    internal string effectType;
    internal string text;
    internal string[] dataArr;
    public TalkAct(string[] dataarr) {
        dataArr = dataarr;
        LoadOriginData();
    }
    public void DoAct() {
        TalkShow talkShow = TalkShow.instance;
        talkShow.nameText.text = "【" + name + "】";
        Debug.Log(text);
        talkShow.PlayText(text);
        foreach(GameObject obj in talkShow.headAniList) {
            FaceAni faceani = obj.GetComponent<FaceAni>();
            try {
                if(faceani.NameId == name) {
                    faceani.PlayTalk();
                }
            }catch(Exception e) {
                Debug.Log("获取人物动画组件失败，请检查脚本文件是否正确");
                Debug.Log(e);
            }
        }
    }

    public void LoadOriginData() {
        name         = dataArr[1].Trim();
        effectType   = dataArr[2].Trim();
        text         = dataArr[3].Trim();
    }
}
