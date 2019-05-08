using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionText : MonoBehaviour {
    private int rowNumber;
    private int jumpFrontNumber;
    private int jumpAfterNumber;
    private bool isAllowClicked = false;
    private bool isInThisSection = false;
    private int rowIndex = 0;
    private TalkShow talkShow;
    private int textIndex;
    public int RowNumber
    {
        get
        {
            return rowNumber;
        }

        set
        {
            rowNumber = value;
        }
    }

    public int JumpFrontNumber
    {
        get
        {
            return jumpFrontNumber;
        }

        set
        {
            jumpFrontNumber = value;
        }
    }

    public bool IsAllowClicked
    {
        get
        {
            return isAllowClicked;
        }

        set
        {
            isAllowClicked = value;
        }
    }

    public int JumpAfterNumber
    {
        get
        {
            return jumpAfterNumber;
        }

        set
        {
            jumpAfterNumber = value;
        }
    }

    public int TextIndex
    {
        get
        {
            return textIndex;
        }

        set
        {
            textIndex = value;
        }
    }

    public void Click() {
        Debug.Log("点击了按钮");
        if (IsAllowClicked) {
            //得到分支管理实例
            BranchManager branchManager = gameObject.GetComponentInParent<OptionManager>().branchManager;
            //设置进入的分支索引
            branchManager.SetTargetBranchIndex(TextIndex);
            //把按钮内容隐藏
            Text[] optionTextArr = talkShow.optionText;
            foreach (Text text in optionTextArr) {
                text.text = "";
                text.transform.GetComponent<OptionText>().IsAllowClicked = false;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        talkShow = TalkShow.instance;
    }

}
