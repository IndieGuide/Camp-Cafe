using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TitleImage : MonoBehaviour
{
    Image titleImage;
    Color vecNormal = ColorCollection.GetVecNormal();
    Color vecClear = ColorCollection.GetVecClear();
    public GameObject musicPlayer;
    public GameObject viewArea;
    public void OnPointerEnter(BaseEventData eventData) {
        Debug.Log("指针进入");
        titleImage.color = vecClear;
        foreach(Image image in musicPlayer.GetComponentsInChildren<Image>()) {
            image.color = vecNormal;
        }
    }
    public void OnPointerExit(BaseEventData eventData) {
        Debug.Log("指针离开");
        titleImage.color = vecNormal;
        foreach (Image image in musicPlayer.GetComponentsInChildren<Image>()) {
            image.color = vecClear;
        }

    }
    public void DrinkListOnClick() {
        if (viewArea.active == false) {
            viewArea.SetActive(true);
        } else {
            viewArea.SetActive(false);
        }
        

    }
    // Start is called before the first frame update
    void Start()
    {
        titleImage = gameObject.GetComponent<Image>();
        viewArea.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
