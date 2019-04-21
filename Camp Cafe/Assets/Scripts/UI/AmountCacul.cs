using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmountCacul : MonoBehaviour
{
    public CraftItem bindItem;
    public Text NumberText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddOnClick() {
        bindItem.itemData.itemNumber += 1;
        NumberText.text = bindItem.itemData.itemNumber.ToString();
    }
    public void SubOnClick() {
        bindItem.itemData.itemNumber -= 1;
        NumberText.text = bindItem.itemData.itemNumber.ToString();
    }
}
