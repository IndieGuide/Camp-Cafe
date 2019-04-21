using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BranchAct : MonoBehaviour,IScriptAct
{
    private string[] dataArr;
    string name;
    string branchType;

    public BranchAct(string[] dataarr) {
        dataArr = dataarr;
        LoadOriginData();
    }

    public void DoAct() {
        if (branchType == "2") {
            //对话层级
            string level = dataArr[3].Trim();
            //分支数
            int optionNumber = dataArr.Length - 4;
            //包含文本和行数的初始字符串
            string[] originText = new string[optionNumber];
            //要输出选项文本的Text
            Text[] optionText = TalkShow.instance.optionText;
            //循环给选项文本赋值，记录选项对话行数
            for (int i = 0; i < optionNumber; i++) {
                originText[i] = dataArr[4 + i].Trim().Substring(1);
                string[] optionData = originText[i].Split('\"');
                optionText[i].text = optionData[0];
                optionText[i].GetComponent<OptionText>().RowNumber = int.Parse(optionData[1]);

            }
            //循环记录每个分支前面有多少行，后面有多少行
            for (int i = 0; i < optionNumber; i++) {
                int jumpFrontNumber = 0;
                int jumpAfterNumber = 0;
                for (int j = 0; j < i; j++) {
                    jumpFrontNumber += optionText[j].GetComponent<OptionText>().RowNumber;
                }
                for (int k = optionNumber - 1; k > i; k--) {
                    jumpAfterNumber += optionText[k].GetComponent<OptionText>().RowNumber;
                }
                optionText[i].GetComponent<OptionText>().JumpFrontNumber = jumpFrontNumber + 1;
                optionText[i].GetComponent<OptionText>().JumpAfterNumber = jumpAfterNumber + 1;
                //使按钮点击生效
                optionText[i].GetComponent<OptionText>().IsAllowClicked = true;
                Debug.Log(optionText[i].GetComponent<OptionText>().JumpFrontNumber);
                Debug.Log(optionText[i].GetComponent<OptionText>().JumpAfterNumber);
            }
        }
    }

    public void LoadOriginData() {
        name         = dataArr[1].Trim();
        branchType   = dataArr[2].Trim();
    }
}
