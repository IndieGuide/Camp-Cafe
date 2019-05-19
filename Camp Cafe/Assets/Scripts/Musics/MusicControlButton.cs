using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MusicControlButton : MonoBehaviour
{
    public Sprite enterSpr;
    public Sprite upSpr;
    public Sprite downSpr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseEnter(BaseEventData e) {
        UICollection.SetImage(enterSpr, GetComponent<Image>());
        //Debug.Log("enter");
    }
    public void OnMouseUp(BaseEventData e) {
        SetImageUp();
    }

    internal void SetImageUp() {
        UICollection.SetImage(upSpr, GetComponent<Image>());
    }

    public void OnMouseDown(BaseEventData e) {
        UICollection.SetImage(downSpr, GetComponent<Image>());
    }
    public void OnMouseExit(BaseEventData e) {
        SetImageUp();
    }

}
