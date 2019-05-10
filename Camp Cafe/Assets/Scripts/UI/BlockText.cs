using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockText : MonoBehaviour {
    internal static List<BlockText> blockTextList = new List<BlockText>();
    int m_index;
    RectTransform m_rect;
    Text m_text;
    private bool IsForceChangeRow = false;

    public void SetText(string str) {
        m_text.text = str;
        SetPosAndEffect();
    }
    private void Awake() {

        m_rect = GetComponent<RectTransform>();
        m_text = GetComponent<Text>();
        blockTextList.Add(this);
        m_index = blockTextList.Count - 1;

        m_text.color = ColorCollection.GetRandomGoodColor();

    }

    private void SetPosAndEffect() {
        if (m_index - 1 < 0) return;
        RectTransform m_last_rect = blockTextList[m_index - 1].m_rect;
        m_last_rect.localScale = new Vector3(1, 1, 1);
        float posX = m_last_rect.localPosition.x + m_last_rect.rect.width;
        float posY = m_last_rect.localPosition.y;
        if (IsNeedChangeRow(posX) || IsForceChangeRow) {
            posY = posY - m_rect.rect.height;
            posX = blockTextList[0].m_rect.localPosition.x;
        }
        float posZ = m_last_rect.localPosition.z;
        Vector3 newPos = new Vector3(posX, posY, posZ);
        Vector3 pos = new Vector3(newPos.x, newPos.y + 20f, newPos.z);
        m_rect.localPosition = pos;

        UICollection.MoveToPos(gameObject, newPos, 0.8f);
        UICollection.AlphaFadeText(gameObject, false);
        //Debug.Log("原始坐标位置：" + newPos);
        //Debug.Log("BlockTextList长度：" + blockTextList.Count);
    }

    private bool IsNeedChangeRow(float posx) {
        RectTransform talkTextRec = TalkShow.instance.talkText.rectTransform;
        float right = posx + m_rect.rect.width;
        float endPosX = talkTextRec.localPosition.x + talkTextRec.rect.width / 2;
        if (right > endPosX)
            return true;
        else
            return false;
    }

    internal void ChangeRow() {
        IsForceChangeRow = true;
    }
}
