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
    Color vecNormal = ColorCollection.GetVecNormal();
    Color vecClear = ColorCollection.GetVecClear();
    Color vecClick = ColorCollection.GetVecGrey();
    Color vecSelected = ColorCollection.GetVecGrey();
    private void Start() {
        buttonBack = gameObject.GetComponent<Image>();
        buttonBack.color = vecNormal;
        if (gameObject.name == "ItemGroupButton1") {
            buttonBack.color = vecSelected;
            isSelected = true;
        }
    }
    public void OnPointerEnter(BaseEventData eventData) {
        if (!isSelected) {
            Debug.Log("指针进入");
            buttonBack.color = vecClick;
        }
    }
    public void OnPointerExit(BaseEventData eventData) {
        if (!isSelected) {
            Debug.Log("指针离开");
            buttonBack.color = vecNormal;
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
            buttonScr.buttonBack.color = vecNormal;
        }
        buttonBack.color = vecSelected;
        isSelected = true;

    }
}
