using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockText : MonoBehaviour
{
    internal static List<BlockText> blockTextList = new List<BlockText>();
    int m_index;
    RectTransform m_rect;
    Text m_text;
    public void SetText(string str)
    {
        m_text.text = str;
    }
    private void Awake() {

        m_rect = GetComponent<RectTransform>();
        m_text = GetComponent<Text>();
        blockTextList.Add(this);
        m_index = blockTextList.Count - 1;

        m_text.color = ColorCollection.GetRandomGoodColor();

        if (m_index - 1 < 0) return;
        RectTransform m_last_rect = blockTextList[m_index - 1].m_rect;
        m_last_rect.localScale = new Vector3(1, 1, 1);
        float posX = m_last_rect.localPosition.x + m_last_rect.rect.width;
        float posY = m_last_rect.localPosition.y;
        float posZ = m_last_rect.localPosition.z;
        Vector3 newPos = new Vector3(posX, posY, posZ);
        m_rect.localPosition = newPos;

        Vector3 pos = new Vector3(m_rect.localPosition.x, m_rect.localPosition.y + 20f, m_rect.localPosition.z);
        Vector3 originPos = m_rect.localPosition;
        m_rect.localPosition = pos;

        UICollection.MoveToPos(gameObject, originPos, 0.8f);
        UICollection.AlphaFadeText(gameObject, false);
    }
}
