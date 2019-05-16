using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TitleImage : MonoBehaviour
{
    public GameObject discArea;
    Image titleImage;
    Color vecNormal = ColorCollection.GetVecNormal();
    Color vecClear = ColorCollection.GetVecClear();
    public GameObject viewArea;
    public void OnPointerEnter(BaseEventData eventData) {
        //Debug.Log("指针进入");
        FxCollection.PlayButtonEnterFx();

    }
    public void OnPointerExit(BaseEventData eventData) {
        FxCollection.PlayButtonUpFx();
        //Debug.Log("指针离开");
    }
    public void MusicPlayerOnClick() {
        if(discArea.active == false) {
            discArea.SetActive(true);
        } else {
            discArea.SetActive(false);
        }
    }
    public void DrinkListOnClick() {
        FxCollection.PlayButtonClickFx();
        if (viewArea.active == false) {
            viewArea.SetActive(true);
        } else {
            viewArea.SetActive(false);
        }
    }
    public void SettingOnClick() {
        FxCollection.PlayButtonClickFx();
        GameObject settingArea = GlobalManager.instance.SettingArea;
        if (settingArea.active == false) {
            settingArea.SetActive(true);
        } else {
            settingArea.SetActive(false);
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
