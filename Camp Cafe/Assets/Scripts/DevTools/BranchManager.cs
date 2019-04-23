using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchManager : MonoBehaviour {
    List<BranchData> branchDatas = new List<BranchData>();
    int targetBranchIndex;
    TalkShow talkShow;
    private bool isInBranch;
    private int rowIndex;
    private int rowIndexStart;
    private int rowIndexEnd;
    // Start is called before the first frame update
    public BranchManager(){
        rowIndex = 0;
        talkShow = TalkShow.instance;
        isInBranch = true;
    }

    // Update is called once per frame
    private void LateUpdate() {
        if (isInBranch) {

            if (talkShow.rowIndex == rowIndexEnd) {
                isInBranch = false;
                rowIndexStart = 0;
                rowIndexEnd = 0;
                talkShow.rowIndex += branchDatas[targetBranchIndex].jumpAfterNumber - 1;
            }

        } else {
            Destroy(this);
        }
    }
    class BranchData {
        public string branchValue;
        public int jumpFrontNumber;
        public int jumpAfterNumber;
        public int branchNumber;

        public BranchData(string branchValue, int branchNumber) {
            this.branchValue = branchValue;
            this.branchNumber = branchNumber;
        }
    }

    public void SetTargetBranchIndex(int index) {
        Debug.Log("进入分支：" +(index + 1));
        targetBranchIndex = index;
        isInBranch = true;
        talkShow.rowIndex += branchDatas[targetBranchIndex].jumpFrontNumber;
        rowIndexStart = talkShow.rowIndex;
        rowIndexEnd = rowIndexStart + branchDatas[targetBranchIndex].branchNumber;
        talkShow.ResolveNextText();
        talkShow.IsAllowClick = true;
    }
    public void GetBranchData(List<string[]> optiondata) {
        int optionNumber = optiondata.Count;
        for (int i = 0; i < optionNumber; i++) {
            string branchValue = optiondata[i][0];
            int branchNumber = int.Parse(optiondata[i][1]);
            BranchData branchData = new BranchData(branchValue, branchNumber);
            branchDatas.Add(branchData);
        }
        for(int i = 0; i < branchDatas.Count; i++) {
            int jumpFrontNumber = 0;
            int jumpAfterNumber = 0;
            for (int j = 0; j < i; j++) {
                jumpFrontNumber += branchDatas[j].branchNumber;
            }
            for (int k = optionNumber - 1; k > i; k--) {
                jumpAfterNumber += branchDatas[k].branchNumber;
            }
            branchDatas[i].jumpFrontNumber = jumpFrontNumber + 1;
            branchDatas[i].jumpAfterNumber = jumpAfterNumber + 1;
        }
    }
}
