using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DrinkData;

public class DrinkTagData : MonoBehaviour
{
    public static DrinkTagData instance;
    public List<Func<DrinkInst, DrinkTag>> tagFuncList = new List<Func<DrinkInst, DrinkTag>>();
    public void InitTagFunc() {
        tagFuncList.Add(Func0);
        tagFuncList.Add(Func1);
    }

    static DrinkTag Func0(DrinkInst inst) {
        //冰块数量大于等于2，得到冰凉一夏tag
        DrinkInfo targetDrink = DrinkData.instance.GetDrinkInfo(inst.drinkName);
        if (DrinkData.instance.itemData[4].itemNumber >= 2) {
            return DrinkData.instance.drinkTags[0];
        } else {
            return null;
        }
    }
    static DrinkTag Func1(DrinkInst inst) {
        //蜂蜜数量大于等于2，得到甜蜜十足tag
        DrinkInfo targetDrink = DrinkData.instance.GetDrinkInfo(inst.drinkName);
        if (DrinkData.instance.itemData[16].itemNumber >= 2) {
            return DrinkData.instance.drinkTags[1];
        } else {
            return null;
        }
    }
    private void Awake() {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        InitTagFunc();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
