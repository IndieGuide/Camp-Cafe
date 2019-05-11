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
        [SetUp]
        public void SetUp() {
            string path = "Texts/script1";
            Debug.Log("处理的脚本为" + path);
            allStr = TalkShow.GetScriptInRow(path);
            roleNameList = new List<string>() {
                "Phree","Soda","Boss"
            };

        }
        // A Test behaves as an ordinary method
        [Test]
        public void ScriptActSystemTestSimplePasses() {
            ResolveNextText();
            Debug.Log("共处理：" + rowIndex + "行");
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator ScriptActSystemTestWithEnumeratorPasses() {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }

        public void ResolveNextText() {
            while (rowIndex < allStr.Length) {
                DelNullOrNoteRow();

                string[] rowText = allStr[rowIndex].Split('|');
                string scriptType = rowText[0];
                //图片操作
                if (scriptType == "0") {

                    AnimationAct act = new AnimationAct(rowText);

                    bool isNumberRight = true;
                    if (rowText.Length != 5 && rowText.Length != 3) { 
                        isNumberRight = false;
                        Debug.Log("行参数数量错误，错误数量为：" + rowText.Length + "行内容为：" + allStr[rowIndex]);
                    }
                    Assert.AreEqual(true, isNumberRight);



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
