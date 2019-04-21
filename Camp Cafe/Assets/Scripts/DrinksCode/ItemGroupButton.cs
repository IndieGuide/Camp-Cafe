using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemGroupButton : MonoBehaviour
{
    public int buttonId;
    public ItemManager itemManager;
    Image buttonBack;
    bool isSelected = false;
    public Color vecNormal = new Color(255,255,255,255);
    public Color vecClear = new Color(255,255,255,0);
    public Color vecClick = new Color(128,128,128,255);
    private void Start() {
        buttonBack = gameObject.GetComponent<Image>();
        buttonBack.color = vecClear;
    }
    public void OnPointerEnter(BaseEventData eventData) {
        if (!isSelected) {
            Debug.Log("指针进入");
            buttonBack.color = vecNormal;
        }
    }
    public void OnPointerExit(BaseEventData eventData) {
        if (!isSelected) {
            Debug.Log("指针离开");
            buttonBack.color = vecClear;
        }
    }
    public void OnPointerClick(BaseEventData eventData) {
        Debug.Log("指针单击");
        GroupSelected();
        buttonBack.color = vecClick;
        itemManager.itemBoardType = (ItemManager.ItemBoardEnum)buttonId;
        itemManager.RenewItemBoard();
    }

    private void GroupSelected() {
        foreach(Transform child in transform.parent.transform) {
            ItemGroupButton buttonScr = child.GetComponent<ItemGroupButton>();
            buttonScr.isSelected = false;
            buttonScr.buttonBack.color = vecClear;
        }
        isSelected = true;
    }
}
