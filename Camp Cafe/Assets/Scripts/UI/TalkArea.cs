using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TalkArea : MonoBehaviour
{
    public TalkShow talkShow;
    public void OnPointerClick(BaseEventData eventData) {
        if (!talkShow.IsPlayingText) {
            talkShow.ResolveNextText();
        }
    }
}
