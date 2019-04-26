using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsManager : MonoBehaviour
{
    Vector3 normalPos = new Vector3(520, -364, 0);
    Vector3 hiddenPos = new Vector3(3520, -364, 0);

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localPosition = hiddenPos;
    }
    public void HiddenToolsBoard() {
        gameObject.transform.localPosition = hiddenPos;
    }
    public void ShowToolsBoard() {
        gameObject.transform.localPosition = normalPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ManageBranch(List<string[]> optiondata, int targetindex) {
        BranchManager branchManager = gameObject.AddComponent<BranchManager>();
        branchManager.GetBranchData(optiondata);
        //设置进入的分支索引
        branchManager.SetTargetBranchIndex(targetindex);
    }
}
