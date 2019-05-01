using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeDrink : MonoBehaviour
{
    public Image cup1;
    public DrinkOutputManager drinkManager;
    string drinkName1;
    public string[] dataArr;
    bool isDrinkReady = false;
    string makeStr = "制  作";
    string giveStr = "上  饮  料";
    Text buttonText;
    ToolsManager toolsManager;
    //private enum DetermineTypeEnum {
    //    Drink,
    //    TagAnd,
    //    TagOr
    //}
    //DetermineTypeEnum determineType;
    public class DrinkInst {
        public string drinkName;
        public List<ItemData> itemList = new List<ItemData>();
        public List<DrinkData.DrinkTag> tagList = new List<DrinkData.DrinkTag>();
        public DrinkInst() {
            itemList = DrinkData.instance.itemSelectedList;
            SetDrinkName();
            //SetDrinkTagList();
        }

        private void SetDrinkTagList() {
            throw new NotImplementedException();
        }
        private static bool IsItemNumberRight(DrinkData.ItemBean itembean) {
            //Debug.Log(itembean.itemName + "所需数量为：" + itembean.itemNumber + '\n' + DrinkData.instance.itemData[itembean.itemId].itemName + "实际数量为" + DrinkData.instance.itemData[itembean.itemId].itemNumber);
            return itembean.itemNumber == DrinkData.instance.itemData[itembean.itemId].itemNumber;
        }
        private void SetDrinkName() {
            List<DrinkData.DrinkInfo> drinks = DrinkData.instance.Drinks;
            foreach (DrinkData.DrinkInfo drink in drinks) {
                Debug.Log("查询饮料名：" + drink.drinkName);
                List<DrinkData.ItemBean> itemBeans = drink.mainBeanList;
                int j = 0;
                if (itemBeans.Count == 0) {
                    break;
                }
                for (int i = 0; i < itemBeans.Count; i++) {
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
                    drinkName = drink.drinkName;
                    return;
                    
                }
            }
            drinkName = "不可名状";
        }
    }


    // Start is called before the first frame update
    void Start() {
        buttonText = gameObject.GetComponentInChildren<Text>();
        buttonText.text = makeStr;
        toolsManager = gameObject.GetComponentInParent<ToolsManager>();
    }
    public void OnClick() {
        if (!isDrinkReady) {
            //制作饮料
            DrinkInst drinkInst = new DrinkInst();
            //drinkManager.gameObject.SetActive(true);
            //drinkManager.ShowNewDrink(drinkInst);
            SetDrinkImg(drinkInst.drinkName);
            isDrinkReady = true;
            buttonText.text = giveStr;
        } else {
            //分支数
            int optionNumber = dataArr.Length - 4;
            Debug.Log("饮料分支数量："+optionNumber);
            //将所有分支对话数据分解，存入列表
            List<string[]> optionData = new List<string[]>();
            List<string> branchDrinkNames = new List<string>();
            for (int i = 0; i < optionNumber; i++) {
                string[] dataCell = dataArr[4 + i].Trim().Substring(1).Split('\"');
                optionData.Add(dataCell);
                branchDrinkNames.Add(dataCell[0]);
            }
            int targetIndex = -1;
            for(int i = 0; i < branchDrinkNames.Count; i++) {
                if(drinkName1 == branchDrinkNames[i]) {
                    targetIndex = i;
                    break;
                }
            }
            toolsManager.ManageBranch(optionData, targetIndex);
            isDrinkReady = false;
            buttonText.text = makeStr;
            toolsManager.HiddenToolsBoard();
        }
    }

    private void SetDrinkImg(string drinkname) {
        string imagePath = "Sprites/Drinks/" + drinkname;
        Sprite drinkSpr = Resources.Load<Sprite>(imagePath);
        cup1.sprite = drinkSpr;
        RectTransform imgRecTrans = cup1.transform.GetComponent<RectTransform>();
        imgRecTrans.sizeDelta = new Vector2(cup1.sprite.bounds.size.x * 100, cup1.sprite.bounds.size.y * 100);
        //cup1.color = new Color(255, 255, 255, 255);
    }
    



    public void SetData() {
        TalkShow inst = TalkShow.instance;
        dataArr = inst.allStr[inst.rowIndex].Split('/');
    }
}
