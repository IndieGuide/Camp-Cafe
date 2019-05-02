﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkOutputManager : MonoBehaviour
{
    public Image drinkImage;
    public Image BackImage;
    public Text nameText;
    public Text qualityText;
    public Sprite normalBackSpr;
    public Sprite goodBackSpr;
    public Sprite perfectBackSpr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void ShowNewDrink(DrinkInst drinkInst) {
        string imagePath = "Sprites/Drinks/" + drinkInst.drinkName;
        Vector3 scale = new Vector3(2.0f, 2.0f, 2.0f);
        UICollection.SetImage(imagePath, drinkImage,scale);
        nameText.text = drinkInst.tagStr + drinkInst.drinkName;
        qualityText.text = drinkInst.qualityName;
    }
    public void BackOnClick() {
        gameObject.SetActive(false);
    }
    public void ChangeBack(DrinkInst.BackType type) {
        Sprite targetSpr;
        switch (type) {
            case DrinkInst.BackType.normal:
                targetSpr = normalBackSpr;
                break;
            case DrinkInst.BackType.good:
                targetSpr = goodBackSpr;
                break;
            case DrinkInst.BackType.perfect:
                targetSpr = perfectBackSpr;
                break;
            default:
                targetSpr = normalBackSpr;
                break;

        }
        Vector3 scale = new Vector3(3.0f, 3.0f, 3.0f);
        Color color = new Color(1.0f,1.0f,1.0f,1.0f);
        UICollection.SetImage(targetSpr, BackImage,scale,color);
    }
}
