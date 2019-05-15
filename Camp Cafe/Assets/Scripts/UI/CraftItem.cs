using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class CraftItem : MonoBehaviour
{
    public Text nameText;
    public Text introText;
    public ItemData itemData;
    public Color vecClear = new Color(255, 255, 255, 0);
    public Color vecNormal = new Color(255, 255, 255, 255);
    public CraftItemCollider colliderObj;
    //姓名和内容框中原本的文本
    string tempNameStr;
    string tempContentStr;

    public void OnPointerEnter(BaseEventData eventData) {
        //存储原文本
        tempNameStr = nameText.text;
        tempContentStr = introText.text;
        //替换为饮料名及介绍
        nameText.text = itemData.itemName;
        introText.text = itemData.itemIntro;
        
    }
    public void OnPointerExit(BaseEventData eventData) {
        nameText.text = "";
        introText.text = "";
        //还原文本框内容
        nameText.text = tempNameStr;
        introText.text = tempContentStr;
    }

    public void ChangeItem(ItemData item) {
        itemData = item;
        if (itemData.itemName != "") {
            string imagePath = "Sprites/DrinkItem/" + itemData.imgName;
            Sprite spr = Resources.Load<Sprite>(imagePath);
            UICollection.SetImage(spr, GetComponent<Image>());
            UICollection.AlphaFadeImg(gameObject, true);
            colliderObj.isAllowDrag = true;
            try {
                colliderObj.ChangeBindItem(this,spr);
            }
            catch (Exception e){
                Debug.Log("刚启动时绑定拖拽物品CraftItemCollider，好像会报错");
                Debug.Log("报错为：" + e);
            }
        } else {
            gameObject.GetComponent<Image>().sprite = null;
            UICollection.AlphaFadeImg(gameObject, false);

            colliderObj.isAllowDrag = false;
        }
    }
    private void Start() {

    }
}
