using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeDrink : MonoBehaviour
{
    public Image cupImage;
    public DrinkOutputManager drinkManager;
    string drinkName;
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

            drinkManager.gameObject.SetActive(true);
            drinkManager.ShowNewDrink(drinkInst);

            string imagePath = "Sprites/Drinks/" + drinkInst.drinkName;
            UICollection.SetImage(imagePath, cupImage);

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
            //在脚本中的所有关键饮料分支中寻找与当前饮料名匹配的分支
            int targetIndex = -1;
            int errorIndex = -1;
            for(int i = 0; i < branchDrinkNames.Count; i++) {
                if (branchDrinkNames[i] == "不可名状") { errorIndex = i; }
                if (drinkName == branchDrinkNames[i]) {
                    targetIndex = i;
                    break;
                } else {
                    //饮料不在分支中的情况
                    targetIndex = errorIndex;
                }
            }
            Debug.Log("targetIndex:" + targetIndex);
            toolsManager.ManageBranch(optionData, targetIndex);
            isDrinkReady = false;
            buttonText.text = makeStr;
            toolsManager.HiddenToolsBoard();
        }
    }

    private void SetDrinkImg(string drinkname) {
        string imagePath = "Sprites/Drinks/" + drinkname;
        Sprite drinkSpr = Resources.Load<Sprite>(imagePath);
        cupImage.sprite = drinkSpr;
        RectTransform imgRecTrans = cupImage.transform.GetComponent<RectTransform>();
        imgRecTrans.sizeDelta = new Vector2(cupImage.sprite.bounds.size.x * 100, cupImage.sprite.bounds.size.y * 100);
    }
    



    public void SetData() {
        TalkShow inst = TalkShow.instance;
        dataArr = inst.allStr[inst.rowIndex].Split('/');
    }
}
