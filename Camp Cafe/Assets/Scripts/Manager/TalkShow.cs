using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TalkShow : MonoBehaviour {
    public static TalkShow instance;
    public Text talkText;
    public Text nameText;
    public Text[] optionText = new Text[4];
    public ArrayList headImageList = new ArrayList();
    public float textSpeed;
    public GameObject headImagePrefabs;
    public AudioSource audioSource;
    public GameObject toolBoard;
    //饮料data实例
    //private DrinkData drinkData= new DrinkData();
    //存放加载的整个文本
    private string startStr;
    //把加载的文本按行分割存放
    public string[] allStr;
    //
    private string showStr = "";
    public int rowIndex = 0;
    private bool isEnd = false;
    private bool isPlayingText = false;
    bool isAllowClick = true;

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

    public bool IsAllowClick
    {
        get
        {
            return isAllowClick;
        }

        set
        {
            isAllowClick = value;
        }
    }

    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start() {
        //初始化文本框
        talkText.text = "";
        nameText.text = "";

        //读取文本
        string scrPath = "Texts/script1"; 
        startStr = Resources.Load<TextAsset>(scrPath).text;
        //去掉空格空行
        startStr = startStr.Replace(" ", "").Replace("\r\n\r\n", "\r\n").Replace("\r\n\r\n", "\r\n");
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
        //if(Input.GetMouseButtonDown(0) && !IsPlayingText) {
        //    ResolveNextText();
        //}



    }



    public void ResolveNextText() {
        DelNullOrNoteRow();
        string[] rowText = allStr[rowIndex].Split('/');
        string scriptType = rowText[0];
        //图片操作
        if (scriptType == "0") {
            ImageAct act = new ImageAct(rowText);
            Debug.Log(0);
            act.DoAct();
        }
        //对话操作
        if (scriptType == "1") {
            TalkAct act = new TalkAct(rowText);
            act.DoAct();
        }
        //物品判断操作
        if (scriptType == "2") {
            ItemAct act = new ItemAct(rowText);
            Debug.Log("物品操作");
            act.DoAct();
        }
        //剧本跳转
        if (scriptType == "3") {
            BranchAct act = new BranchAct(rowText);
            act.DoAct();
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

    public void PlayText(string text) {
        StartCoroutine(ShowText(text));
    }

    private IEnumerator ShowText(string text) {
        text = text.Trim();
        text = text.Substring(1, text.Length -  2);
        text = "『" + text + "』";
        //i为当前显示字符长度
        int i = 0;
        int strLength = text.Length;
        string colHeadStr = "";
        bool isStringCol = false;
        IsPlayingText = true;
        showStr = "";

        while (i < strLength) {
            //识别并不显示颜色代码
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

            //向显示字符中添加新字符
            if (isStringCol) {
                showStr += colHeadStr + text[i].ToString() + "</color>";
            } else if (text[i] == '\\') {
                //忽略转行
                showStr += '\n';
                i++;
            } else { 
                showStr += text[i].ToString();
            }
            //播放音效
            if (i % 2 == 0) {
                Instantiate(audioSource, this.transform.position, Quaternion.identity);
                
            }
            //更新当前文字
            talkText.text = showStr;
            //识别换行
            talkText.text = talkText.text.Replace("\\n", "\n");
            i++;
            yield return new WaitForSeconds(textSpeed);
        }
        this.GetComponent<AudioSource>().Play();
        rowIndex++;
        IsPlayingText = false;
        StopAllCoroutines();
    }

}
