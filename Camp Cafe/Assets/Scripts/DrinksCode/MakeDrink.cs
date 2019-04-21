using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeDrink : MonoBehaviour
{
    public Image cup1;
    public string[] dataArr;
    private enum DetermineTypeEnum {
        Drink,
        TagAnd,
        TagOr
    }
    DetermineTypeEnum determineType;
    public void OnClick() {
        string createDrinkName = GetDrinkFromItem();
        SetDrinkImg(createDrinkName);
        //if (IsItemRight()) {
        //    TalkShow.instance.IsPlayingText = true;
        //} else {
        //    TalkShow.instance.IsPlayingText = true;
        //    SetWrongImg();
        //}
    }

    private void SetDrinkImg(string drinkname) {
        string imagePath = "Sprites/Drinks/" + drinkname;
        Sprite drinkSpr = Resources.Load<Sprite>(imagePath);
        cup1.sprite = drinkSpr;
        RectTransform imgRecTrans = cup1.transform.GetComponent<RectTransform>();
        imgRecTrans.sizeDelta = new Vector2(cup1.sprite.bounds.size.x * 100, cup1.sprite.bounds.size.y * 100);
        //cup1.color = new Color(255, 255, 255, 255);
    }


    //private bool IsItemRight() {
    //    determineType = (DetermineTypeEnum)int.Parse(dataArr[3]);
    //    if (determineType == DetermineTypeEnum.Drink) {
    //        //目标饮料
    //        string targetDrinkName = dataArr[4].Split('\"')[0];
    //        if (GetDrinkFromItem() == targetDrinkName) {

    //        }
    //        ////目标饮料包含文本行数
    //        //int targetDrinkTextNumber = int.Parse(dataArr[4].Split('\"')[1]);
    //        ////其他有文本反馈的饮料数据
    //        //List<string[]> otherDrinkData = new List<string[]>();
    //        //for (int i = 0; i < dataArr.Length - 5; i++) {
    //        //    otherDrinkData.Add(dataArr[i + 5].Split('\"'));
    //        //}
    //    }
    //}

    private string GetDrinkFromItem() {
        List<DrinkData.DrinkInfo> drinks= DrinkData.instance.Drinks;
        foreach(DrinkData.DrinkInfo drink in drinks) {
            List<DrinkData.ItemBean> itemBeans = drink.itemBeanList;
            Debug.Log(itemBeans.Count);
            int j = 0;
            if (itemBeans.Count == 0) {
                break;
            }
            for(int i = 0;i < itemBeans.Count; i++) {
                Debug.Log(itemBeans[i].itemName);
                if (IsItemNumberRight(itemBeans[i])) {
                    j++;
                } else {
                    Debug.Log(itemBeans[i].itemName + "数量错误");
                    break;
                }
            }
            if (j == itemBeans.Count) {
                Debug.Log(drink.drinkName);
                return drink.drinkName;
            }
        }
        return "错误饮料";
    }

    private static bool IsItemNumberRight(DrinkData.ItemBean itembean) {
        Debug.Log(itembean.itemName + "所需数量为：" + itembean.itemNumber + '\n' + DrinkData.instance.itemData[itembean.itemId].itemName + "实际数量为" + DrinkData.instance.itemData[itembean.itemId].itemNumber);
        return itembean.itemNumber == DrinkData.instance.itemData[itembean.itemId].itemNumber;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable() {
        TalkShow inst = TalkShow.instance;
        dataArr = inst.allStr[inst.rowIndex].Split('/');
    }
}
