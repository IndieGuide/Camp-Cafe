using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsManager : MonoBehaviour
{
    Vector3 normalPos = new Vector3(520, -364, 0);
    Vector3 hiddenPos = new Vector3(3520, -364, 0);
    RectTransform liquidImageRect;
    public MakeDrink makeDrink;
    void Start()
    {
        liquidImageRect = GameObject.Find("LiquidImage").GetComponent<RectTransform>();
        gameObject.transform.localPosition = hiddenPos;
    }
    public void HiddenToolsBoard() {
        gameObject.transform.localPosition = hiddenPos;
    }
    public void ShowToolsBoard() {
        gameObject.transform.localPosition = normalPos;
    }

    public void ManageBranch(List<string[]> optiondata, int targetindex) {
        BranchManager branchManager = gameObject.AddComponent<BranchManager>();
        branchManager.GetBranchData(optiondata);
        //设置进入的分支索引
        branchManager.SetTargetBranchIndex(targetindex);
    }

    public void MixClearOnClick() {
        foreach(ItemData item in DrinkData.instance.itemSelectedList) {
            item.itemNumber = 0;
        }
        foreach (AmountCacul item in ItemManager.instance.amountCaculArr) {
            item.ClearData();
        }
        DrinkData.instance.itemSelectedList.Clear();
        liquidImageRect.sizeDelta = new Vector2(liquidImageRect.rect.width, 0);
    }
    public void MakeClearOnClick() {
        makeDrink.ClearData();
    }
    public void PushClearOnClick() {

    }
}
