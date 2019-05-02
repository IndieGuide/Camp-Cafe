using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkOutputManager : MonoBehaviour
{
    public Image drinkImage;
    public Text nameText;
    public Text qualityText;
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
        UICollection.SetImage(imagePath, drinkImage);
        nameText.text = drinkInst.tagStr + drinkInst.drinkName;
        qualityText.text = drinkInst.qualityName;
    }
    public void BackOnClick() {
        gameObject.SetActive(false);
    }
}
