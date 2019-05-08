using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeDrink : MonoBehaviour {
    public Image cupImage;
    public Sprite originCupSpr;
    public DrinkOutputManager drinkManager;
    DrinkInst drinkInst;
    public string[] dataArr;
    bool isDrinkReady = false;
    public bool isAllowClick = true;
    string makeStr = "制  作";
    string giveStr = "上  饮  料";
    Text buttonText;
    ToolsManager toolsManager;

    // Start is called before the first frame update
    void Start() {
        buttonText = gameObject.GetComponentInChildren<Text>();
        buttonText.text = makeStr;
        toolsManager = gameObject.GetComponentInParent<ToolsManager>();
    }


    internal int InjectText() {
        List<string> tagTalkList = new List<string>();
        foreach (RoleInfo role in RoleData.instance.roles) {
            if (role.roleName != dataArr[1]) continue;
            //人名匹配的话
            foreach (DrinkData.DrinkTag tag in drinkInst.tagList) {
                int id = tag.tagId;
                foreach(int roletagid in role.RoleTagDic.Keys) {
                    if (id != roletagid) continue;
                    //饮料拥有的tagId和人物的tag字典中的id匹配
                    string[] tagStrArr = role.RoleTagDic[roletagid];
                    foreach (string item in tagStrArr) {
                        tagTalkList.Add(item);
                    }
                }
            }
        }
        if (tagTalkList.Count == 0) return 0;
        //如果有要插入的对话，更新当前的全局剧本
        string[] allStr = TalkShow.instance.allStr;
        string[] strArr = new string[allStr.Length + tagTalkList.Count];
        int rowIndex = TalkShow.instance.rowIndex;
        for (int i = 0; i <= rowIndex; i++) {
            strArr[i] = allStr[i];
        }
        for(int i = rowIndex + 1; i <= rowIndex + tagTalkList.Count; i++) {
            strArr[i] = tagTalkList[i - rowIndex - 1];
        }
        for(int i = rowIndex+tagTalkList.Count+1; i <= strArr.Length - 1; i++) {
            strArr[i] = allStr[i - tagTalkList.Count];
        }
        TalkShow.instance.allStr = strArr;
        return tagTalkList.Count;
    }
    public void OnClick() {
        if (!isAllowClick) return;
        if (!isDrinkReady) {
            if (DrinkData.instance.itemSelectedList.Count == 0) return;
            //制作饮料
            drinkInst = new DrinkInst();

            drinkManager.gameObject.SetActive(true);
            drinkManager.ChangeBack(drinkInst.qualityType);
            drinkManager.ShowNewDrink(drinkInst);

            string imagePath = "Sprites/Drinks/" + drinkInst.drinkName;
            UICollection.SetImage(imagePath, cupImage);

            isDrinkReady = true;
            buttonText.text = giveStr;
        } else {
            //分支数
            int optionNumber = dataArr.Length - 4;
            Debug.Log("饮料分支数量：" + optionNumber);

            List<string> branchDrinkNames = new List<string>();
            for (int i = 0; i < optionNumber; i++) {
                string[] dataCell = dataArr[4 + i].Trim().Substring(1).Split('\"');
                branchDrinkNames.Add(dataCell[0]);
            }
            //在脚本中的所有关键饮料分支中寻找与当前饮料名匹配的分支
            int targetIndex = -1;
            int errorIndex = -1;
            int injectRowNumber = 0;
            for (int i = 0; i < branchDrinkNames.Count; i++) {
                if (branchDrinkNames[i] == "不可名状") { errorIndex = i; }
                if (drinkInst.drinkName == branchDrinkNames[i]) {
                    injectRowNumber = InjectText();
                    targetIndex = i;
                    break;
                } else {
                    //饮料不在分支中的情况
                    targetIndex = errorIndex;
                }
            }
            Debug.Log("targetIndex:" + targetIndex);
            //将所有分支对话数据分解，存入列表
            List<string[]> optionData = new List<string[]>();
            for (int i = 0; i < optionNumber; i++) {
                string[] dataCell = dataArr[4 + i].Trim().Substring(1).Split('\"');
                if (injectRowNumber != 0 && i == targetIndex) {
                    int originRowNumber = int.Parse(dataCell[1]);
                    int newRowNumber = originRowNumber + injectRowNumber;
                    dataCell[1] = newRowNumber.ToString();
                }
                optionData.Add(dataCell);
            }
            toolsManager.ManageBranch(optionData, targetIndex);
            isDrinkReady = false;
            buttonText.text = makeStr;

            toolsManager.HiddenToolsBoard();

            GameObject.Find("LiquidImage").GetComponent<LiquidImage>().EmptyCup();

            Sprite spr = originCupSpr;
            UICollection.SetImage(spr, cupImage);

            GameObject viewArea = GameObject.Find("TalkArea").GetComponent<TalkArea>().viewArea;
            if (viewArea.active) {
                viewArea.SetActive(false);
            }
        }
    }


    internal void ClearData() {
        UICollection.SetImage(originCupSpr, cupImage);
        drinkInst = null;
        isDrinkReady = false;
        buttonText.text = makeStr;
        if (drinkManager.gameObject.active)
            drinkManager.gameObject.SetActive(false);
    }

    public void SetData(string[] dataarr) {
        dataArr = dataarr;
    }
}

