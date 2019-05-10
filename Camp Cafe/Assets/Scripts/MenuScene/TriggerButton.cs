using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TriggerButton : MonoBehaviour {
    public Image m_image;
    public Sprite normalSpr;
    public Sprite enterSpr;
    public Sprite downSpr;
    public int markNum;

    public void PointUp(BaseEventData e) {
        ChangeImage(normalSpr);
    }
    public void PointDown(BaseEventData e) {
        ChangeImage(downSpr);
    }
    public void PointEnter(BaseEventData e) {
        FxCollection.PlayButtonEnterFx();
        ChangeImage(enterSpr);
        GameObject.Find("FunArea").GetComponent<FunAreaControl>().ChangeContent(markNum);
    }
    public void PointExit(BaseEventData e) {
        ChangeImage(normalSpr);
    }
    public void ChangeImage(Sprite spr) {
        Image img = GetComponent<Image>();
        img.sprite = spr;
        RectTransform imgRecTrans = gameObject.transform.GetComponent<RectTransform>();
        imgRecTrans.sizeDelta = new Vector2(spr.bounds.size.x * 100, spr.bounds.size.y * 100);
    }

}
