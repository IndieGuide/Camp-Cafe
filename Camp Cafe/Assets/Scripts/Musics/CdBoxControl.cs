﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CdBoxControl : MonoBehaviour
{
    public Image cdSmallImage;
    Vector3 cdSmallOriginPos = new Vector3(0, 0, 0);
    Vector3 cdSmallTargetPos = new Vector3(30, 0, 0);
    Vector3 cdIndexOriginPos = new Vector3(0, 0, 0);
    Vector3 cdIndexTargetPos = new Vector3(-20, 0, 0);
    public Image cdIndexImage;

    Vector3 moveTargetPos = new Vector3(90, 0, 0);

    public bool isChanging = false;
    public bool isSelected = false;

    public Vector3 MoveTargetPos { get => moveTargetPos; set => moveTargetPos = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseEnter(BaseEventData e) {
        if (isChanging) return;
        UICollection.MoveToPos(cdSmallImage.gameObject, cdSmallTargetPos,0.2f);
        UICollection.MoveToPos(cdIndexImage.gameObject, cdIndexTargetPos,0.2f);
    }
    public void OnMouseUp(BaseEventData e) {
        if (isChanging) return;
        UICollection.MoveToPos(cdSmallImage.gameObject, cdSmallOriginPos, 0.2f);
        UICollection.MoveToPos(cdIndexImage.gameObject, cdIndexOriginPos, 0.2f);
    }
    public void OnMouseClick() {
        if (isSelected) return;
        isChanging = true;
        MusicPlayerControl.instance.ChangeDisc(this);
       
    }
}
