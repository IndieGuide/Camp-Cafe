using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkShow : MonoBehaviour {
    public Text talkText;
    public Text nameText;
    public Text[] optionText = new Text[4];
    protected ArrayList headImageList = new ArrayList();
    public float textSpeed;
    public GameObject headImagePrefabs;
    
    //存放加载的整个文本
    private string startStr;
    //把加载的文本按行分割存放
    private string[] allStr;
    //
    private string showStr = "";
    public int rowIndex = 0;
    private bool isEnd = false;
    private bool isPlayingText = false;

    public bool IsPlayingText
    {
        get
        {
            return isPlayingText;
        }

        set
        {
            isPlayingText = value;
        }
    }

    // Start is called before the first frame update
    void Start() {
        //读取文本
        string scrPath = "Texts/script1"; 
        startStr = Resources.Load<TextAsset>(scrPath).text;
        //按行分割
        allStr = startStr.Split('\n');
        foreach(Text text in optionText) {
            text.text = "";
        }
    }

    // Update is called once per frame
    void Update() {

        if ((Input.GetKeyDown(KeyCode.B))) {
            talkText.text = allStr[rowIndex];
            rowIndex++;
        }
        if(Input.GetMouseButtonDown(0) && !IsPlayingText) {
            ResolveNextText();
        }

    }

    public void ResolveNextText() {
        DelNullOrNoteRow();
        string[] rowText = allStr[rowIndex].Split('/');
        string scriptType = rowText[0];

        if (scriptType == "0") {
            //如果只有三个信息段，应为图片退出操作
            if (rowText.Length == 3 && rowText[2].Trim() == "1") {
                for (int i = 0; i < headImageList.Count; i++) {
                    GameObject imageObject = headImageList[i] as GameObject;
                    if (imageObject.GetComponent<FaceImage>().nameId == rowText[1].Trim()) {
                        headImageList.Remove(imageObject);
                        Destroy(imageObject);
                        rowIndex++;
                        ResolveNextText();
                        return;
                    }
                }
            }
            //得到数据
            string name = rowText[1].Trim();
            string actType = rowText[2].Trim();
            string imageName = rowText[3].Trim();
            string pos = rowText[4].Trim();

            //已存在人物图片切换,更改位置
            foreach(GameObject imageObject in headImageList) {
                if (imageObject.GetComponent<FaceImage>().nameId == name) {
                    imageObject.transform.GetComponent<FaceImage>().setImg(imageName);
                    imageObject.transform.GetComponent<FaceImage>().changePos(pos);
                    //下一行递归
                    rowIndex++;
                    ResolveNextText();
                    return;
                }
            }


            //创建头像并设置父节点为Canvas
            GameObject faceImg = Instantiate(headImagePrefabs);
            headImageList.Add(faceImg);
            
            faceImg.transform.parent = gameObject.transform;

            //设置识别id
            faceImg.transform.GetComponent<FaceImage>().nameId = name;
            //设置图片
            faceImg.transform.GetComponent<FaceImage>().setImg(imageName);
            //设置位置
            faceImg.transform.GetComponent<FaceImage>().changePos(pos);

            //下一行递归
            rowIndex++;
            ResolveNextText();
            return;
        }
        if (scriptType == "1") {
            string name = rowText[1].Trim();
            string effectType = rowText[2].Trim();
            string text = rowText[3].Trim();
            nameText.text = name;
            PlayText(text);
        }
        if (scriptType == "3") {
            string name = rowText[1].Trim();
            string branchType = rowText[2].Trim();
            if (branchType == "2") {
                string level = rowText[3].Trim();
                int optionNumber = rowText.Length - 4;
                string[] originText = new string[optionNumber];

                for (int i = 0; i < optionNumber; i++) {
                    originText[i] = rowText[4+i].Trim().Substring(1);
                    string[] optionData = originText[i].Split('\"');
                    optionText[i].text = optionData[0];
                    optionText[i].GetComponent<OptionText>().RowNumber = int.Parse(optionData[1]);
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
                    optionText[i].GetComponent<OptionText>().IsAllowClicked = true;
                }

            }
        }

        }

        private void DelNullOrNoteRow() {
        string rowStr = allStr[rowIndex];
        string head = rowStr[0].ToString();
        while (head == "/" || string.IsNullOrWhiteSpace(allStr[rowIndex])) {
            rowIndex++;
            rowStr = allStr[rowIndex];
            head = rowStr[0].ToString();
        }
    }

    private void PlayText(string text) {
        StartCoroutine(ShowText(text));
    }

    private IEnumerator ShowText(string text) {
        text = text.Trim();
        text = text.Substring(1, text.Length -  2);
        //i为当前显示字符长度
        int i = 0;
        int strLength = text.Length;
        string colHeadStr = "";
        bool isStringCol = false;
        IsPlayingText = true;
        showStr = "";
        //识别并不显示颜色代码
        while (i < strLength) {
            if (text[i].ToString() == "<" && text[i + 1].ToString() != "/") {
                isStringCol = true;
                int j = 1;
                while (text[i + j].ToString() != ">") {
                    j++;
                }
                colHeadStr = text.Substring(i, j + 1);
                i += j + 1;
            } else if (text[i].ToString() == "<" && text[i + 1].ToString() == "/") {
                i += 8;
                isStringCol = false;
            }
            if (isStringCol) {
                showStr += colHeadStr + text[i].ToString() + "</color>";
            } else {
                showStr += text[i].ToString();
            }
            //更新当前文字
            talkText.text = showStr;
            //识别换行
            talkText.text = talkText.text.Replace("\\n", "\n");
            i++;
            yield return new WaitForSeconds(textSpeed);
        }
        rowIndex++;
        IsPlayingText = false;
        StopAllCoroutines();
    }

}
