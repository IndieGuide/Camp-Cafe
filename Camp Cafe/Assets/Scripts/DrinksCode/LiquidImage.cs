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
    public void AddLiquid(ItemData itemdata) {
        Debug.Log("杯子液体增加");
        m_rect.sizeDelta = new Vector2(m_rect.rect.width , m_rect.rect.height + heightMax / 10);
        ChangeLiquidColor(itemdata);
    }
    public void SubLiquid(ItemData itemdata) {
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
