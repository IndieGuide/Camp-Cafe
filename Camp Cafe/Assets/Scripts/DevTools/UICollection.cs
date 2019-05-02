using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICollection : MonoBehaviour
{
    public static void SetImage(string imagePath,Image targetImage) {
        Sprite spr = Resources.Load<Sprite>(imagePath);
        targetImage.sprite = spr;
        RectTransform imgRecTrans = targetImage.transform.GetComponent<RectTransform>();
        imgRecTrans.sizeDelta = new Vector2(targetImage.sprite.bounds.size.x * 100, targetImage.sprite.bounds.size.y * 100);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
