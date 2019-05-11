using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAct : MonoBehaviour, IScriptAct {
    internal string[] dataArr;
    internal ShowActTypeEnum showType;
    //动画演出参数
    internal ShowAnimeTypeEnum animeType;
    internal float animeParam;
    //音乐演出参数
    internal string musicName;
    //文本演出参数
    internal string textStr;

    GameObject showArea;
    internal enum ShowActTypeEnum {
        anime,
        music,
        text
    }
    internal enum ShowAnimeTypeEnum {
        fadein,
        fadeout
    }

    public ShowAct(string[] dataarr) {
        dataArr = dataarr;
        LoadOriginData();
    }

    public void DoAct() {
        switch (showType) {
            case ShowActTypeEnum.anime:
                DoActAnime();
                break;
            case ShowActTypeEnum.music:
                DoActMusic();
                break;
            case ShowActTypeEnum.text:
                DoActText();
                break;

        }
    }

    private void DoActText() {
        ShowAreaControl control = GameObject.Find("ShowArea").GetComponent<ShowAreaControl>();
        control.ShowText(textStr);
    }

    private void DoActMusic() {
        throw new NotImplementedException();
    }

    private void DoActAnime() {
        if (animeType == ShowAnimeTypeEnum.fadein) {
            showArea.SetActive(true);
            ShowAreaControl control = showArea.GetComponent<ShowAreaControl>();
            control.ShowShut(0.2f);
            
        } else if(animeType == ShowAnimeTypeEnum.fadeout) {
            ShowAreaControl control = GameObject.Find("ShowArea").GetComponent<ShowAreaControl>();
            control.ShowOpen(0.2f);
           
        }
    }

    public void LoadOriginData() {

        showArea = TalkShow.instance.showArea;

        switch (dataArr[1].Trim()) {
            case "Anime":
                showType = ShowActTypeEnum.anime;
                GetShowType();
                animeParam = float.Parse(dataArr[3]);
                break;
            case "Music":
                showType = ShowActTypeEnum.music;
                musicName = dataArr[2];
                break;
            case "Text":
                showType = ShowActTypeEnum.text;
                textStr = dataArr[2];
                break;
            default:
                Debug.Log("演出类型错误");
                break;
        }


    }

    private void GetShowType() {
        if (showType != ShowActTypeEnum.anime) return;
        switch (dataArr[2]) {
            case "FadeIn":
                animeType = ShowAnimeTypeEnum.fadein;
                break;
            case "FadeOut":
                animeType = ShowAnimeTypeEnum.fadeout;
                break;
        }
    }

   
}
