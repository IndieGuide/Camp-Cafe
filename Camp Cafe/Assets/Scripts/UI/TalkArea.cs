using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TalkArea : MonoBehaviour
{

    public void OnPointerClick(BaseEventData eventData) {
        TalkShow talkShow = TalkShow.instance;
        if (!talkShow.IsPlayingText && talkShow.IsAllowClick) {
            talkShow.ResolveNextText();
        }
    }
}
