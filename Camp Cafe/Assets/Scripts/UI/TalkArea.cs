using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TalkArea : MonoBehaviour
{
    public GameObject viewArea;
    public GameObject itemAreaCover;
    public void OnPointerClick(BaseEventData eventData) {
        TalkShow talkShow = TalkShow.instance;
        if (!talkShow.IsPlayingText && talkShow.IsAllowClick && !viewArea.active) {
            itemAreaCover.SetActive(true);
            talkShow.ResolveNextText();
        }
    }
}
