using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class ScriptActSystemTest {
        GameObject m_obj;
        TalkShow talkShow;
        int rowIndex = 0;
        string[] allStr;
        List<string> roleNameList;
        Dictionary<string,string[]> roleAniDic = new Dictionary<string, string[]>();
        [SetUp]
        public void SetUp() {
            string path = "Texts/script1";
            Debug.Log("处理的脚本为" + path);
            allStr = TalkShow.GetScriptInRow(path);
            roleNameList = new List<string>() {
                "Phree","Soda","Boss"
            };
            roleAniDic.Add("Phree", new string[]{ "普通", "微笑", "悲伤", "生气", "鄙夷", "张嘴", "死目" });
            roleAniDic.Add("Soda", new string[] { "普通", "悲伤", "生气", "微笑", "无语", "打哈欠" });
            roleAniDic.Add("Boss", new string[] { "普通", "悲伤", "生气", "开口笑", "眯眼笑", "阴险笑" });

        }
        // A Test behaves as an ordinary method
        [Test]
        public void 剧情脚本内容检查() {
            ResolveNextText();
            Debug.Log("共处理：" + rowIndex + "行");
        }

        public void ResolveNextText() {
            while (rowIndex < allStr.Length) {
                DelNullOrNoteRow();

                string[] rowText = allStr[rowIndex].Split('|');
                string scriptType = rowText[0];
                //动画操作
                if (scriptType == "0") {

                    AnimationAct act = new AnimationAct(rowText);
                    bool isAniExists = false;
                    bool isNameRight = false;
                    bool isNumberRight = true;
                    //检查行数
                    if (rowText.Length != 5 && rowText.Length != 3) { 
                        isNumberRight = false;
                        Debug.Log("行参数数量错误，错误数量为：" + rowText.Length + "行内容为：" + allStr[rowIndex]);
                    }
                    Assert.AreEqual(true, isNumberRight);
                    //动画退出事件的检查
                    if (rowText.Length == 3) {
                        Assert.AreEqual(1,int.Parse(rowText[2].Trim()));
                        rowIndex++;
                        continue;
                    } 
                    //一般动画事件的检查（进入，更换）
                    //检查角色名
                    foreach (string name in roleNameList) {
                        if (name == rowText[1].Trim())
                            isNameRight = true;
                    }
                    if (!isNameRight) {
                        Debug.Log("角色名称错误，行内容为：" + allStr[rowIndex]);
                    }
                    Assert.AreEqual(true, isNameRight);
                    //检查动画名
                    foreach(string aniname in roleAniDic[rowText[1].Trim()]) {
                        if (aniname == rowText[3].Trim()) {
                            isAniExists = true;
                        }
                    }
                    if (!isAniExists) {
                        Debug.Log("动画名称错误，行内容为：" + allStr[rowIndex]);
                    }
                    Assert.AreEqual(true, isAniExists);
                }
                //对话操作
                if (scriptType == "1") {

                    TalkAct act = new TalkAct(rowText);

                    bool isNumberRight = true;
                    bool isNameRight = false;
                    bool isTextRight = false;
                    if (rowText.Length != 4) {
                        isNumberRight = false;
                        Debug.Log("行参数数量错误，错误数量为：" + rowText.Length + "行内容为：" + allStr[rowIndex]);
                    }
                    foreach (string name in roleNameList) {
                        if (name == act.name || act.name.Contains(","))
                            isNameRight = true;
                    }
                    if (act.text[0] == '\"' && act.text[act.text.Length - 1] == '\"')
                        isTextRight = true;
                    Assert.AreEqual(true, isNumberRight);
                    if (!isNameRight) {
                        Debug.Log("角色名称错误，行内容为：" + allStr[rowIndex]);
                    }
                    Assert.AreEqual(true, isNameRight);
                    Assert.AreEqual(true, isTextRight);

                }
                //物品判断操作
                if (scriptType == "2") {

                    ItemAct act = new ItemAct(rowText);

                    bool isNumberRight = true;
                    if (rowText.Length < 5) {
                        isNumberRight = false;
                        Debug.Log("行参数数量错误，错误数量为：" + rowText.Length + "行内容为：" + allStr[rowIndex]);
                    }

                    Assert.AreEqual(true, isNumberRight);

                }
                //剧本跳转
                if (scriptType == "3") {

                    BranchAct act = new BranchAct(rowText);

                    bool isNumberRight = true;
                    if (rowText.Length < 5) {
                        isNumberRight = false;
                        Debug.Log("行参数数量错误，错误数量为：" + rowText.Length + "行内容为：" + allStr[rowIndex]);
                    }
                    Assert.AreEqual(true, isNumberRight);


                }
                rowIndex++;
            }
        }

        private void DelNullOrNoteRow() {
            string rowStr = allStr[rowIndex];
            string head = rowStr[0].ToString();
            while ((head == "|" || string.IsNullOrWhiteSpace(allStr[rowIndex]))) {
                if (rowIndex < allStr.Length - 1) {
                    rowIndex++;
                    rowStr = allStr[rowIndex];
                    if (rowStr.Length > 0)
                        head = rowStr[0].ToString();
                    else
                        Debug.Log(rowIndex + "行为空");
                } else {
                    break;
                }
            }
        }
    }
}
