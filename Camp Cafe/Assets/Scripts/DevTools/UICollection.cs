using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICollection : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    public class JumpBorderControl : MonoBehaviour {
        Transform m_trans;
        float scale = 0.0f;
        float xScale = 0.0f;
        float yScale = 0.0f;
        private void Awake() {
            m_trans = gameObject.GetComponent<RectTransform>();
            m_trans.localScale = new Vector2(xScale, yScale);
        }
        private void Update() {
            if (yScale >= 0.98f) {
                Vector3 normalScale = new Vector3(1.00f, 1.00f, 1.00f);
                m_trans.localScale = normalScale;
                Destroy(this);
                return;
            }
            xScale = Mathf.Lerp(xScale, 1f, 0.4f);
            yScale = Mathf.Lerp(yScale, 1f, 0.25f);
            Vector3 newScale = new Vector3(xScale, yScale, 1.0f);
            m_trans.localScale = newScale;
        }
    }
    internal static void JumpBorder(GameObject obj) {
        if (obj.GetComponent<JumpBorderControl>() != null) return;
        obj.AddComponent<JumpBorderControl>();
    }

    internal static void SetImage(string imagePath, Image targetImage) {
        Sprite spr = Resources.Load<Sprite>(imagePath);
        targetImage.sprite = spr;
        RectTransform imgRecTrans = targetImage.transform.GetComponent<RectTransform>();
        imgRecTrans.sizeDelta = new Vector2(targetImage.sprite.bounds.size.x * 100, targetImage.sprite.bounds.size.y * 100);
    }
    internal static void SetImage(Sprite originCupSpr, Image targetImage) {
        Sprite spr = originCupSpr;
        targetImage.sprite = spr;
        RectTransform imgRecTrans = targetImage.transform.GetComponent<RectTransform>();
        imgRecTrans.sizeDelta = new Vector2(targetImage.sprite.bounds.size.x * 100, targetImage.sprite.bounds.size.y * 100);
    }
    internal static void SetImage(string imagePath, Image targetImage, Vector3 scale) {
        Sprite spr = Resources.Load<Sprite>(imagePath);
        targetImage.sprite = spr;
        RectTransform imgRecTrans = targetImage.transform.GetComponent<RectTransform>();
        imgRecTrans.localScale = scale;
        imgRecTrans.sizeDelta = new Vector2(targetImage.sprite.bounds.size.x * 100, targetImage.sprite.bounds.size.y * 100);
    }
    internal static void SetImage(Sprite originCupSpr, Image targetImage, Vector3 scale, Color color) {
        Sprite spr = originCupSpr;
        targetImage.sprite = spr;
        targetImage.color = color;
        RectTransform imgRecTrans = targetImage.transform.GetComponent<RectTransform>();
        imgRecTrans.localScale = scale;
        imgRecTrans.sizeDelta = new Vector2(targetImage.sprite.bounds.size.x * 100, targetImage.sprite.bounds.size.y * 100);
    }
    internal static void SetImage(Sprite originCupSpr, Image targetImage, Vector3 scale) {
        Sprite spr = originCupSpr;
        targetImage.sprite = spr;
        RectTransform imgRecTrans = targetImage.transform.GetComponent<RectTransform>();
        imgRecTrans.localScale = scale;
        imgRecTrans.sizeDelta = new Vector2(targetImage.sprite.bounds.size.x * 100, targetImage.sprite.bounds.size.y * 100);
    }
}
