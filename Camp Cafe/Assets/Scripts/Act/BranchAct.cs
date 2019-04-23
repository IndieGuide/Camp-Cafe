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
            //将所有分支对话数据分解，存入列表
            List<string[]> optionData = new List<string[]>(); 
            for (int i = 0; i <optionNumber; i++) {
                string[] dataCell = dataArr[4 + i].Trim().Substring(1).Split('\"');
                optionData.Add(dataCell);
            }
            //设置分支管理实例的数据
            OptionManager optionManager = GameObject.Find("OptionArea").GetComponent<OptionManager>();
            optionManager.ManageBranch(optionData);
            //关闭点击下一行
            TalkShow.instance.IsAllowClick = false;
        }
    }

    public void LoadOriginData() {
        name         = dataArr[1].Trim();
        branchType   = dataArr[2].Trim();
    }
}
