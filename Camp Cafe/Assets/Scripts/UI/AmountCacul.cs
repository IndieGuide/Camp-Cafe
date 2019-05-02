using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AmountCacul : MonoBehaviour
{
    public CraftItem bindItem;
    public Text NumberText;
    public Image addButtonAreaImage;
    public Image subButtonAreaImage;
    public Image addButtonImage;
    public Image subButtonImage;
    public Sprite addButton;
    public Sprite addButtonAlpha;
    public Sprite subButton;
    public Sprite subButtonAlpha;
    public LiquidImage liquidImage;

    Color vecNormal = ColorCollection.GetVecNormal();
    Color vecClear = ColorCollection.GetVecClear();
    Color vecClick = ColorCollection.GetVecGreyWithAlpha();
    Color vecEnter = ColorCollection.GetVecGreyEnter();
    public void AddOnClick() {
        int itemNumber = bindItem.itemData.itemNumber;
        if (itemNumber >= 0 && itemNumber < 10 && !liquidImage.IsCupFull()) {
            addButtonImage.sprite = addButton;
            subButtonImage.sprite = subButton;
            bindItem.itemData.itemNumber += 1;
            NumberText.text = bindItem.itemData.itemNumber.ToString();

            liquidImage.AddLiquid(bindItem.itemData);
        }else {
            addButtonImage.sprite = addButtonAlpha;
        }
    }
    public void SubOnClick() {
        int itemNumber = bindItem.itemData.itemNumber;
        if (itemNumber > 0 && itemNumber <= 10) {
            addButtonImage.sprite = addButton;
            subButtonImage.sprite = subButton;
            bindItem.itemData.itemNumber -= 1;
            NumberText.text = bindItem.itemData.itemNumber.ToString();

            liquidImage.SubLiquid(bindItem.itemData);
        } else {
            subButtonImage.sprite = subButtonAlpha;
        }
    }
    public void ClearData() {
        NumberText.text = bindItem.itemData.itemNumber.ToString();
        subButtonImage.sprite = subButtonAlpha;
        addButtonImage.sprite = addButton;
    }
    public void OnPointerEnterAdd(BaseEventData eventData) {
        addButtonAreaImage.GetComponentInChildren<Image>().color = vecEnter;
    }
    public void OnPointerExitAdd(BaseEventData eventData) {
        addButtonAreaImage.GetComponentInChildren<Image>().color = vecClear;
    }
    public void OnPointerDownAdd(BaseEventData eventData) {
        addButtonAreaImage.GetComponentInChildren<Image>().color = vecClick;
    }
    public void OnPointerUpAdd(BaseEventData eventData) {
        addButtonAreaImage.GetComponentInChildren<Image>().color = vecClear;
    }
    public void OnPointerEnterSub(BaseEventData eventData) {
        subButtonAreaImage.GetComponentInChildren<Image>().color = vecEnter;
    }
    public void OnPointerExitSub(BaseEventData eventData) {
        subButtonAreaImage.GetComponentInChildren<Image>().color = vecClear;
    }
    public void OnPointerDownSub(BaseEventData eventData) {
        subButtonAreaImage.GetComponentInChildren<Image>().color = vecClick;
    }
    public void OnPointerUpSub(BaseEventData eventData) {
        subButtonAreaImage.GetComponentInChildren<Image>().color = vecClear;
    }

    public void OnPointerClickSub(BaseEventData eventData) {
        SubOnClick();
    }
    public void OnPointerClickAdd(BaseEventData eventData) {
        AddOnClick();
    }
}
