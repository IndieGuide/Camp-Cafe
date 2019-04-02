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

    public void Click() {
        if (isAllowClicked) {
            isInThisSection = true;
            Debug.Log("Button Clicked. TestClick.");
            talkShow.rowIndex += jumpFrontNumber;
            Text[] optionTextArr = talkShow.optionText;
            foreach (Text text in optionTextArr) {
                text.text = "";
                text.transform.GetComponent<OptionText>().IsAllowClicked = false;
            }
            talkShow.ResolveNextText();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        talkShow = GameObject.Find("Canvas").transform.GetComponent<TalkShow>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isInThisSection){
            if (Input.GetMouseButtonDown(0)) {
                rowIndex++;
            }
            if (rowIndex == rowNumber + 1 ) {
                isInThisSection = false;
                rowIndex = 0;
                talkShow.rowIndex += jumpAfterNumber;
            }
            
        }
    }
}
