using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiquidImage : MonoBehaviour
{
    int heightMax = 320;
    RectTransform m_rect;
    Image m_image;

    private void Start() {
        m_rect = GetComponent<RectTransform>();
        m_image = GetComponent<Image>();
    }
    public void EmptyCup() {
        foreach (ItemData item in DrinkData.instance.itemSelectedList) {
            item.itemNumber = 0;
        }
        foreach (AmountCacul item in ItemManager.instance.amountCaculArr) {
            item.ClearData();
        }
        m_rect.sizeDelta = new Vector2(m_rect.rect.width, 0);
    }
    public void AddLiquid(ItemData itemdata) {
        ChangeItemSelectedList(itemdata,true);
        m_rect.sizeDelta = new Vector2(m_rect.rect.width, m_rect.rect.height + heightMax / 10);
        ChangeLiquidColor(itemdata);
    }

    private static void ChangeItemSelectedList(ItemData itemdata,bool isAdd) {
        if (isAdd) {
            bool isItemInList = false;
            foreach (ItemData item in DrinkData.instance.itemSelectedList) {
                if (item.itemId == itemdata.itemId) {
                    isItemInList = true;
                    break;
                }
            }
            if (!isItemInList) {
                DrinkData.instance.itemSelectedList.Add(itemdata);
            }
        } else {
            if (itemdata.itemNumber == 0) {
                DrinkData.instance.itemSelectedList.Remove(itemdata);
            }
        }

    }

    public void SubLiquid(ItemData itemdata) {
        ChangeItemSelectedList(itemdata,false);
        m_rect.sizeDelta = new Vector2(m_rect.rect.width , m_rect.rect.height - heightMax / 10);
        ChangeLiquidColor(itemdata);
    }

    public void ChangeLiquidColor(ItemData itemdata) {
        Color localColor = m_image.color;
        Color itemColor = ColorCollection.HexToColor(itemdata.itemColor);
        Color newColor = ColorCollection.ColorMix(localColor,itemColor);
        m_image.color = newColor;
        
    }

    public bool IsCupFull() {
        if (m_rect.rect.height >= heightMax)
            return true;
        else
            return false;
    }

}
