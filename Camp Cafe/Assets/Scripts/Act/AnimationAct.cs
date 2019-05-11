using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAct : MonoBehaviour, IScriptAct {
    enum ActType {
        Quit,
        Enter,
        Move,
    }
    internal string[] dataArr;
    internal string name;
    internal string actType;
    internal string aniName;
    internal string pos;
    protected List<GameObject> headAniList;
    private ActType aniActType;
    GameObject aniObject;
    public AnimationAct(string[] dataarr) {
        dataArr = dataarr;
        try {
            headAniList = TalkShow.instance.headAniList;

            LoadOriginData();
        }
        catch {
            Debug.Log("AnimationAct初始化数据失败"); 
        }
    }
    public void LoadOriginData() {
        //如果只有三个信息段，应为图片退出操作
        if (dataArr.Length == 3) {
            aniActType = ActType.Quit;
            for (int i = 0; i < headAniList.Count; i++) {
                GameObject animateObject = headAniList[i] as GameObject;
                if (animateObject.GetComponent<FaceAni>().NameId.Trim() == dataArr[1].Trim()) {
                    aniObject = animateObject;
                }
            }
        }
        //有五个数据，是图片进入或者移动操作
        if (dataArr.Length == 5) {
            aniActType = ActType.Enter;
            foreach (GameObject aniobject in headAniList) {
                if (aniobject.GetComponent<FaceAni>().NameId.Trim() == dataArr[1].Trim()) {
                    aniActType = ActType.Move;
                    aniObject = aniobject;
                }
            }
            //得到数据
            name = dataArr[1].Trim();
            actType = dataArr[2].Trim();
            aniName = dataArr[3].Trim();
            pos = dataArr[4].Trim();
        }
    }
    public void DoAct() {
        switch (aniActType) {
            case ActType.Move:
                AniChangePos();
                break;
            case ActType.Enter:
                AniEnter();
                break;
            case ActType.Quit:
                AniQuit();
                break;
            default:
                Debug.Log("人物动画操作错误");
                break;
        }
    }

    private void AniQuit() {
        try {
            aniObject.GetComponent<FaceAni>().FadeOutAndDelete();
            headAniList.Remove(aniObject);
        }
        catch (Exception e) {
            Debug.Log(e);
            Debug.Log("人物动画退出失败,可能没有人物动画存在于场景？");
        }

    }

    private void AniEnter() {
        //创建头像并设置父节点为Canvas
        string path = "Prefabs/Roles/FaceAni" + name;
        //GameObject facePrefab = Resources.Load<GameObject>(path);
        GameObject facePrefab = Instantiate(Resources.Load<GameObject>(path));
        headAniList.Add(facePrefab);

        GameObject parent = GameObject.Find("FaceArea");
        facePrefab.transform.SetParent(parent.transform);

        FaceAni faceAni = facePrefab.transform.GetComponent<FaceAni>();
        //初始化FaceAni时设置NameId
        faceAni.NameId = name;
        //设置动画和位置
        faceAni.SetAniAndPos(aniName, pos);

        //下一行递归
        TalkShow.instance.rowIndex++;
        TalkShow.instance.ResolveNextText();
    }

    private void AniChangePos() {
        aniObject.transform.GetComponent<FaceAni>().SetAniAndPos(aniName, pos);
        //下一行递归
        TalkShow.instance.rowIndex++;
        TalkShow.instance.ResolveNextText();
    }
}
