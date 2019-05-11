using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UICollection;

public class ShowAreaControl : MonoBehaviour {
    public Image upMaskImage;
    public Image downMaskImage;
    public Text showText;
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
                gameObject.SetActive(false);
              
                TalkShow.instance.rowIndex++;
            }
        }
    }
    internal void ShowOpen(float speed) {
        IsShowAreaAllowClick = false;
        UICollection.MoveToPos(upMaskImage.gameObject, upMaskOpenPos, speed);
        UICollection.MoveToPos(downMaskImage.gameObject, downMaskOpenPos, speed);
        UICollection.AlphaFadeText(showText.gameObject, false);
        isOpenOver = false;

    }
    internal void ShowShut(float speed) {
        IsShowAreaAllowClick = true;
        UICollection.MoveToPos(upMaskImage.gameObject, upMaskShutPos, speed);
        UICollection.MoveToPos(downMaskImage.gameObject, downMaskShutPos, speed);
    }
    internal void ShowText(string text) {
        UICollection.AlphaFadeText(showText.gameObject, true);
        UICollection.PlayText(showText, text, 0.05f);
    }

    public void OnClick() {
        Debug.Log("ShowArea被点击了！");
        if (IsShowAreaAllowClick) {
            TalkShow.instance.rowIndex++;
            TalkShow.instance.ResolveNextText();
        }
    }

   
}
