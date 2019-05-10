using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEffectManager : MonoBehaviour
{
    public GameObject[] UIElementsList;
    Image element1;
    Image[] element2;
    Image element3Img;
    Text element3Text;
    Image[] element4;
    public GameObject pressToStart;
    bool isUIViewed = false;
    // Start is called before the first frame update
    void Start() {
        InitUIComponent();
        UICollection.AlphaPingPong(pressToStart, 0.2f, 1.0f, 0.02f);
    }

    private void InitUIComponent() {
        element1 = UIElementsList[0].GetComponent<Image>();
        element2 = UIElementsList[1].GetComponentsInChildren<Image>();
        element3Img = UIElementsList[2].GetComponent<Image>();
        element3Text = UIElementsList[2].GetComponentInChildren<Text>();
        element4 = UIElementsList[3].GetComponentsInChildren<Image>();
        foreach (Image img in element4) {
            img.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        }
        UICollection.SetAlphaClear(element1);
        UICollection.SetAlphaClear(element2);
        UICollection.SetAlphaClear(element3Img);
        UICollection.SetAlphaClear(element3Text);
        UICollection.SetAlphaClear(element4);
    }

    // Update is called once per frame
    void Update() {
        if (!isUIViewed) {
            if (Input.GetKeyUp(KeyCode.Mouse0)) {
                FxCollection.PlayButtonEnterFx();
                UIGetIn();
                pressToStart.SetActive(false);
                isUIViewed = true;
            }
        }
    }
    private void UIGetIn() {
        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() => {
            UICollection.AlphaFade(UIElementsList[0], true);
        }, 0.5f));
        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() => {
            UICollection.AlphaFade(UIElementsList[1], true);
            GameObject role = element2[1].gameObject;
            RectTransform roleRect = role.GetComponent<RectTransform>();
            GameObject shadow = element2[0].gameObject;
            RectTransform shadowRect = role.GetComponent<RectTransform>();
            UICollection.MoveToPos(role, new Vector3(0f, roleRect.localPosition.y, roleRect.localPosition.z), 0.15f);
            UICollection.MoveToPos(shadow, new Vector3(0f, shadowRect.localPosition.y, shadowRect.localPosition.z), 0.15f);
        }, 1.0f));
        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() => {
            UICollection.AlphaFade(UIElementsList[3], true);
            int i = 0;
            foreach (Image item in element4) {
                GameObject obj = element4[i].gameObject;
                RectTransform rect = obj.GetComponent<RectTransform>();
                UICollection.MoveToPos(obj, new Vector3(rect.localPosition.x, -80f * i, rect.localPosition.z), 0.2f);
                i++;
            }
        }, 1.5f));
        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() => {
            UICollection.AlphaFade(element3Img.gameObject, true, 0.7f);
        }, 2.0f));
        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() => {
            UICollection.AlphaFade(element3Text.gameObject, true);
        }, 2.0f));
    }


}
