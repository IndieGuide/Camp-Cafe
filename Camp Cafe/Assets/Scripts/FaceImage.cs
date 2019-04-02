using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceImage : MonoBehaviour {
    //图片固定位置
    protected Vector2[] imgPosData = {new Vector2(-762, 608), new Vector2(-698, 608 ), new Vector2(-436, 608), new Vector2(-187, 608 ), new Vector2(-126, 608) };
    public string nameId;
    protected Transform borderTrans;
    Vector2 imgPos;
    void Start() {
        borderTrans =GameObject.Find("Border").transform;
    }
    public enum PosEnum{
        Left,
        LittleLeft,
        Middle,
        LittleRight,
        Right
    }
    public void changePos(string postring){
        int posInt = int.Parse(postring);
        FaceImage.PosEnum posType = (FaceImage.PosEnum)posInt;
        switch (posType){
            case PosEnum.Left:
                imgPos.x = imgPosData[0].x;
                break;
            case PosEnum.LittleLeft:
                imgPos.x = imgPosData[1].x;
                break;
            case PosEnum.Middle:
                imgPos.x = imgPosData[2].x;
                break;
            case PosEnum.LittleRight:
                imgPos.x = imgPosData[3].x;
                break;
            case PosEnum.Right:
                imgPos.x = imgPosData[4].x;
                break;
        }
        RectTransform imgRecTrans = gameObject.transform.GetComponent<RectTransform>();

        imgRecTrans.anchoredPosition = imgPos;
        imgRecTrans.localScale = new Vector3(1, 1, 1);
        borderTrans = GameObject.Find("Border").transform;
        gameObject.transform.SetSiblingIndex(borderTrans.GetSiblingIndex() - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    internal void setImg(string imagename) {
        string imagePath = "Sprites/Face/" + imagename;
        Sprite faceSpr = Resources.Load<Sprite>(imagePath);
        Image faceImg = gameObject.transform.GetComponent<Image>();
        faceImg.sprite = faceSpr;
        RectTransform imgRecTrans = gameObject.transform.GetComponent<RectTransform>();
        imgRecTrans.sizeDelta = new Vector2(faceImg.sprite.bounds.size.x * 100, faceImg.sprite.bounds.size.y * 100);
        imgPos.y = faceImg.sprite.bounds.size.y * 100 / 2;
        faceImg.color = new Color(255, 255, 255, 255);
    }
}
