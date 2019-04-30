using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    //主要：水，小苏打，冰块，咖啡粉，椰子粉，红茶包
    //配料：冰淇淋球，椰果，仙草，葡萄柚粒，黄桃片，西米
    //甜味剂：蜂蜜，膳食纤维，方糖，果糖
    //香料：薄荷叶，柠檬片，香草，干桂花

    public Image[] ItemImageArr = new Image[8];
    public AmountCacul[] amountCaculArr = new AmountCacul[8];
    public List<ItemData> itemData = new List<ItemData>();
    public static ItemManager instance;

    public enum ItemBoardEnum {
        Base=0,
        Food = 1,
        Sugar =2,
        Spice=3
    }

    public ItemBoardEnum itemBoardType = ItemBoardEnum.Base;

    // Start is called before the first frame update
    public void Awake()
    {
        instance = this;
        //初始化材料数据
        List<string[]> ItemDataList = InstanceLoad.GetInstanceData("Texts/ItemData");
        foreach (string[] insDataArr in ItemDataList) {
            ItemData item = new ItemData(int.Parse(insDataArr[0]), insDataArr[1], insDataArr[2],insDataArr[3],insDataArr[4],int.Parse(insDataArr[5]));
            itemData.Add(item);
        }
        try {
            RenewItemBoard();
        }catch(Exception e) {
            Debug.Log(e);
            Debug.Log("材料面板刷新失败");
        }
    }
    public void RenewItemBoard() {
        if (itemBoardType == ItemBoardEnum.Base ) {
            for (int i = 0; i < 8; i++) {
                ItemImageArr[i].GetComponent<CraftItem>().ChangeItem(this.itemData[i]);
                amountCaculArr[i].NumberText.text = itemData[i].itemNumber.ToString();
            }
        }
        if (itemBoardType == ItemBoardEnum.Food ) {
            for (int i = 0; i < 8; i++) {
                ItemImageArr[i].GetComponent<CraftItem>().ChangeItem(this.itemData[i + 8]);
                amountCaculArr[i].NumberText.text = itemData[i+8].itemNumber.ToString();
            }
        }
        if (itemBoardType == ItemBoardEnum.Sugar) {
            for (int i = 0; i < 8; i++) {
                ItemImageArr[i].GetComponent<CraftItem>().ChangeItem(this.itemData[i + 8*2]);
                amountCaculArr[i].NumberText.text = itemData[i+8*2].itemNumber.ToString();
            }
        }
        if (itemBoardType == ItemBoardEnum.Spice) {
            for (int i = 0; i < 8; i++) {
                ItemImageArr[i].GetComponent<CraftItem>().ChangeItem(this.itemData[i + 8*3]);
                amountCaculArr[i].NumberText.text = itemData[i+8*3].itemNumber.ToString();
            }
        }

    }

}
