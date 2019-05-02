using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkInst {
    public string drinkName;
    public string tagStr;
    public List<ItemData> itemList = new List<ItemData>();
    public List<DrinkData.DrinkTag> tagList = new List<DrinkData.DrinkTag>();
    public string qualityName;

    public DrinkInst() {
        itemList = DrinkData.instance.itemSelectedList;
        SetDrinkName();
        SetDrinkTagList();
        SetDrinkQuality();
    }

    private void SetDrinkQuality() {
        qualityName = "普通";
    }

    private void SetDrinkTagList() {
        tagStr = "普通的";
    }
    private static bool IsItemNumberRight(DrinkData.ItemBean itembean) {
        //Debug.Log(itembean.itemName + "所需数量为：" + itembean.itemNumber + '\n' + DrinkData.instance.itemData[itembean.itemId].itemName + "实际数量为" + DrinkData.instance.itemData[itembean.itemId].itemNumber);
        return itembean.itemNumber == DrinkData.instance.itemData[itembean.itemId].itemNumber;
    }
    private static bool IsItemUsed(DrinkData.ItemBean itembean) {
        if (itembean.itemNumber != 0)
            return true;
        else
            return false;
    }
    private void SetDrinkName() {
        List<DrinkData.DrinkInfo> drinks = DrinkData.instance.Drinks;
        int itemNumber = 0;
        foreach (ItemData item in DrinkData.instance.itemSelectedList) {
            itemNumber += item.itemNumber;
        }
        if (itemNumber != 10) {
            drinkName = "不可名状";
            return;
        }
        foreach (DrinkData.DrinkInfo drink in drinks) {
            Debug.Log("查询饮料名：" + drink.drinkName);
            //数量正确的itembean数量
            int mainBeanRightNumber = 0;
            int optionBeanRightNumber = 0;
            List<DrinkData.ItemBean> optionBeanList = drink.optionBeanList;
            List<DrinkData.ItemBean> mainBeanList = drink.mainBeanList;
            if (mainBeanList.Count == 0 || optionBeanList.Count == 0) {
                Debug.Log(drink.drinkName + "bean配置可能有误，mainBean为0或optionBean为0");
            }
            //遍历mainBean
            for (int i = 0; i < mainBeanList.Count; i++) {
                if (IsItemNumberRight(mainBeanList[i])) {
                    mainBeanRightNumber++;
                } else {
                    Debug.Log("mainbean" + mainBeanList[i].itemName + "数量错误");
                    break;
                }
            }
            //遍历optionBean
            for (int i = 0; i < optionBeanList.Count; i++) {
                if (IsItemUsed(mainBeanList[i])) {
                    optionBeanRightNumber++;
                } else {
                    Debug.Log("optionbean" + optionBeanList[i].itemName + "没有被使用");
                    break;
                }
            }
            //检测饮料公式是否正确
            if (mainBeanRightNumber == mainBeanList.Count && optionBeanRightNumber == optionBeanList.Count) {
                Debug.Log("mainBean与optionBean,以及饮料数量全部判定正确,制作出饮料" + drink.drinkName);
                drinkName = drink.drinkName;
                return;
            }
        }
        drinkName = "不可名状";
    }

}
