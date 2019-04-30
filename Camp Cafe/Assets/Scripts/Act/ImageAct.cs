using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageAct : MonoBehaviour, IScriptAct
{
    enum ActType {
        Quit,
        Enter,
        Move,
    }
    string[] dataArr;
    string name;
    string actType;
    string imageName;
    string pos;
    protected ArrayList headImageList;
    private ActType imgActType;
    GameObject imgObject;
    public ImageAct(string[] dataarr) {
        dataArr = dataarr;
        headImageList = TalkShow.instance.headImageList;
        LoadOriginData();
    }
    public void LoadOriginData() {
        //如果只有三个信息段，应为图片退出操作
        if (dataArr.Length == 3) {
            imgActType = ActType.Quit;
            for (int i = 0; i < headImageList.Count; i++) {
                GameObject imageObject = headImageList[i] as GameObject;
                if (imageObject.GetComponent<FaceImage>().nameId.Trim() == dataArr[1].Trim()) {
                    imgObject = imageObject;
                }
            }
        }
        //有五个数据，是图片进入或者移动操作
        if (dataArr.Length == 5) {
            imgActType = ActType.Enter;
            foreach (GameObject imageObject in headImageList) {
                if (imageObject.GetComponent<FaceImage>().nameId.Trim() == dataArr[1].Trim()) {
                    imgActType = ActType.Move;
                    imgObject = imageObject;
                }
            }
            //得到数据
            name = dataArr[1].Trim();
            actType = dataArr[2].Trim();
            imageName = dataArr[3].Trim();
            pos = dataArr[4].Trim();
        }
    }
    public void DoAct() {
        switch (imgActType) {
            case ActType.Move:
                ImgChangePos();
                break;
            case ActType.Enter:
                ImgEnter();
                break;
            case ActType.Quit:
                ImgQuit();
                break;
            default:
                Debug.Log("图片操作错误");
                break;
        }
    }

    private void ImgQuit() {
        imgObject.GetComponent<FaceImage>().FadeOutAndDelete();
        headImageList.Remove(imgObject);

    }

    private void ImgEnter() {
        //创建头像并设置父节点为Canvas
        GameObject faceImg = Instantiate(TalkShow.instance.headImagePrefabs);
        headImageList.Add(faceImg);

        //faceImg.transform.parent = TalkShow.instance.transform;
        GameObject parent = GameObject.Find("FaceArea");
        faceImg.transform.SetParent(parent.transform);

        //设置识别id
        faceImg.transform.GetComponent<FaceImage>().nameId = name;
        //设置图片
        faceImg.transform.GetComponent<FaceImage>().SetImg(imageName);
        //设置位置
        faceImg.transform.GetComponent<FaceImage>().ChangePos(pos);

        //下一行递归
        TalkShow.instance.rowIndex++;
        TalkShow.instance.ResolveNextText();
    }

    private void ImgChangePos() {
        imgObject.transform.GetComponent<FaceImage>().SetImg(imageName);
        imgObject.transform.GetComponent<FaceImage>().ChangePos(pos);
        //下一行递归
        TalkShow.instance.rowIndex++;
        TalkShow.instance.ResolveNextText();
    }
}
