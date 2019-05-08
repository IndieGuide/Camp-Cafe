using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceImage : MonoBehaviour {
    //图片固定位置
    protected Vector2[] imgPosData = {new Vector2(-794, 608), new Vector2(-698, 608 ), new Vector2(-436, 608), new Vector2(-187, 608 ), new Vector2(-84, 608) };
    public string nameId;
    protected Transform borderTrans;
    Vector2 imgPos;
    void Start() {
        borderTrans =GameObject.Find("Border").transform;
        //gameobject.transform.localscale = new vector3(3, 3, 3);
    }
    public enum PosEnum{
        Left,
        LittleLeft,
        Middle,
        LittleRight,
        Right
    }
    public void ChangePos(string postring){
        //先放大图片
        int posInt = int.Parse(postring);
        PosEnum posType = (PosEnum)posInt;
        Sprite sprite = gameObject.GetComponent<Image>().sprite;
        imgPos.y = sprite.rect.height * 3 / 2;
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
        imgRecTrans.localScale = new Vector3(3, 3, 3);
        borderTrans = GameObject.Find("Border").transform;
        gameObject.transform.SetSiblingIndex(borderTrans.GetSiblingIndex() - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    internal void SetImg(string imagename) {
        string imagePath = "Sprites/Roles/" +nameId+"/Face/"+ imagename;
        Sprite faceSpr = Resources.Load<Sprite>(imagePath);
        Image faceImg = gameObject.transform.GetComponent<Image>();
        faceImg.sprite = faceSpr;
        RectTransform imgRecTrans = gameObject.transform.GetComponent<RectTransform>();
        imgRecTrans.sizeDelta = new Vector2(faceImg.sprite.bounds.size.x * 100, faceImg.sprite.bounds.size.y * 100);
        imgPos.y = faceImg.sprite.bounds.size.y * 100 / 2;
        faceImg.color = new Color(255, 255, 255, 255);
    }

    internal void FadeOutAndDelete() {
        TalkShow.instance.rowIndex++;
        TalkShow.instance.ResolveNextText();
        Destroy(this.gameObject);
    }
}
