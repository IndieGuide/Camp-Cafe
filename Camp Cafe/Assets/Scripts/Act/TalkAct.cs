using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkAct : MonoBehaviour,IScriptAct
{
    string name;
    string effectType;
    string text;
    string[] dataArr;
    public TalkAct(string[] dataarr) {
        dataArr = dataarr;
        LoadOriginData();
    }
    public void DoAct() {
        TalkShow.instance.nameText.text = "【" + name + "】";
        Debug.Log(text);
        TalkShow.instance.PlayText(text);
    }

    public void LoadOriginData() {
        name         = dataArr[1].Trim();
        effectType   = dataArr[2].Trim();
        text         = dataArr[3].Trim();
    }
}
