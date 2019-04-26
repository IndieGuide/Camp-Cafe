using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TagButton : MonoBehaviour
{
    public Text tagNameText;
    public DrinkData.Tag tag;
    public void OnPointerEnter(BaseEventData eventData) {
        Debug.Log("指针进入");
        tagNameText.fontStyle = FontStyle.Bold;
    }
    public void OnPointerExit(BaseEventData eventData) {
        Debug.Log("指针离开");
        tagNameText.fontStyle = FontStyle.Normal;
    }
    public void OnPointerClick(BaseEventData eventData) {
        Debug.Log("指针点击");
        MenuManager.instance.RenderMenuByTag(tag);

    }
    // Start is called before the first frame update
    void Start() {
        tagNameText.text = tag.tagName;
    }
}
