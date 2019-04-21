using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TitleImage : MonoBehaviour
{
    Image titleImage;
    Color vecNormal = new Color(255, 255, 255, 255);
    Color vecClear = new Color(255, 255, 255, 0);
    public void OnPointerEnter(BaseEventData eventData) {
        Debug.Log("指针进入");
        titleImage.color = vecClear;
    }
    public void OnPointerExit(BaseEventData eventData) {
        Debug.Log("指针离开");
        titleImage.color = vecNormal;
    }
    // Start is called before the first frame update
    void Start()
    {
        titleImage = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
