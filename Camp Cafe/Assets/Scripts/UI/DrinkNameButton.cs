using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DrinkNameButton : MonoBehaviour
{
    Text drinkNameText;
    public DrinkData.DrinkInfo drinkInfo;
    public void OnPointerEnter(BaseEventData eventData) {
        Debug.Log("指针进入");
        drinkNameText.fontStyle = FontStyle.Bold;
    }
    public void OnPointerExit(BaseEventData eventData) {
        Debug.Log("指针离开");
        drinkNameText.fontStyle = FontStyle.Normal;
    }
    public void OnPointerClick(BaseEventData eventData) {
        Debug.Log("指针点击");
        MenuManager.instance.SetMenuContent(drinkInfo);
        MenuManager.instance.FocusOnContent();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        drinkNameText = GetComponentInChildren<Text>();
        drinkNameText.text = drinkInfo.drinkName;
    }

}
