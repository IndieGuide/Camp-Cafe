using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UICollection;

public class ShowAreaControl : MonoBehaviour {
    public Image upMaskImage;
    public Image downMaskImage;
    public Text showText;
    public GameObject textArea;
    //文字行距
    public float rowSpacing;
    List<Text> textList = new List<Text>();
    Vector3 upMaskOpenPos = new Vector3(0, 820, 0);
    Vector3 downMaskOpenPos = new Vector3(0, -820, 0);
    Vector3 upMaskShutPos = new Vector3(0, 270, 0);
    Vector3 downMaskShutPos = new Vector3(0, -270, 0);
    bool isShowAreaAllowClick = true;
    private bool isOpenOver = true;


    public bool IsShowAreaAllowClick { get => isShowAreaAllowClick; set => isShowAreaAllowClick = value; }

    private void Start() {
        upMaskImage.gameObject.GetComponent<RectTransform>().localPosition = upMaskShutPos;
        downMaskImage.gameObject.GetComponent<RectTransform>().localPosition = downMaskShutPos;
    }
    private void Update() {
        if (!isOpenOver) {
            if (upMaskImage.GetComponent< PosControl>() == null && downMaskImage.GetComponent<PosControl>() == null) {
                isOpenOver = true;
                foreach(Text text in textList) {
                    Destroy(text.gameObject);
                }
                textList.Clear();
                gameObject.SetActive(false);
              
                TalkShow.instance.rowIndex++;
            }
        }
    }
    internal void ShowOpen(float speed,float alpha) {
        IsShowAreaAllowClick = false;
        AlphaFadeImg(upMaskImage.gameObject, false, alpha);
        AlphaFadeImg(downMaskImage.gameObject, false, alpha);
        MoveToPos(upMaskImage.gameObject, upMaskOpenPos, speed);
        MoveToPos(downMaskImage.gameObject, downMaskOpenPos, speed);
        AlphaFade(textArea, false,0,0.2f);
        isOpenOver = false;

    }
    internal void ShowShut(float speed,float alpha) {
        IsShowAreaAllowClick = true;
        AlphaFadeImg(upMaskImage.gameObject, true, alpha);
        AlphaFadeImg(downMaskImage.gameObject, true, alpha);
        MoveToPos(upMaskImage.gameObject, upMaskShutPos, speed);
        MoveToPos(downMaskImage.gameObject, downMaskShutPos, speed);
    }
    internal void ShowText(string text) {
        GameObject newTextObj = Instantiate(Resources.Load<GameObject>("Prefabs/ShowTextPrefab"), textArea.transform);
        Text newText = newTextObj.GetComponent<Text>();
        textList.Add(newText);
        TextsFitting();
        AlphaFadeText(newText.gameObject, true);
        PlayText(newText, text, 0.05f);
    }

    private void TextsFitting() {
        float areaHeight = (textList.Count - 1) * rowSpacing;
        float startPosY = areaHeight / 2;
        int i = 0;
        foreach(Text text in textList) {
            Vector3 targetPos = new Vector3(0, startPosY - rowSpacing*i, 0);
            MoveToPos(text.gameObject, targetPos, 0.1f);
            i++;
        }
    }

    public void OnClick() {
        Debug.Log("ShowArea被点击了！");
        if (IsShowAreaAllowClick) {
            TalkShow.instance.rowIndex++;
            TalkShow.instance.ResolveNextText();
        }
    }

   
}
