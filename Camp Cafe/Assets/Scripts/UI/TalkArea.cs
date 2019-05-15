using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TalkArea : MonoBehaviour {
    public GameObject viewArea;
    public GameObject itemAreaCover;
    TalkShow talkShow;

    public void OnPointerClick(BaseEventData eventData) {
        if (!talkShow.IsPlayingText && talkShow.IsAllowClick && !viewArea.active) {
            talkShow.textSpeed = 0.05f;
            itemAreaCover.SetActive(true);
            talkShow.ResolveNextText();
        }
    }
    private void Start() {
        talkShow = TalkShow.instance;
    }
    private void Update() {


        if (!talkShow.IsPlayingText && talkShow.IsAllowClick && !viewArea.active && Input.GetKey(KeyCode.LeftControl)) {
            talkShow.textSpeed = 0.005f;
            itemAreaCover.SetActive(true);
            talkShow.ResolveNextText();
        }
    }
}
