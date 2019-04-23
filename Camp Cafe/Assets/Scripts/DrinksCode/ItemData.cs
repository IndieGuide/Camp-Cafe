using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{
    public ItemData(int itemid, string itemname, string imgname, string itemintro,int itemnumber) {
        itemId = itemid;
        itemName = itemname;
        itemNumber = itemnumber;
        itemIntro = itemintro;
        imgName = imgname;
    }
    public int itemId;
    public string itemName;
    public int itemNumber;
    public string itemIntro;
    public string imgName;
}
