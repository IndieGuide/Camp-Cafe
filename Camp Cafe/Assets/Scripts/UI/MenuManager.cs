using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    List<DrinkNameButton> drinkList = new List<DrinkNameButton>();
    List<DrinkData.DrinkInfo> drinks;
    public GameObject buttonPreb;
    public Text drinkNameText;
    public Text drinkIntroText;
    public Text drinkHelpText;
    
    public Transform menuScrollContentTrans;
    public static MenuManager instance;
    RectTransform areaRecTrans;
    private Vector3 contentPos = new Vector3(-660,0,0);
    private Vector3 mainPos = new Vector3(0,0,0);
    private Vector3 targetPos;
    public List<DrinkNameButton> DrinkList
    {
        get
        {
            return drinkList;
        }

        set
        {
            drinkList = value;
        }
    }

    public void SetMenuContent(DrinkData.DrinkInfo drink) {
        drinkNameText.text = drink.drinkName;
        drinkIntroText.text = drink.drinkIntro; 
        drinkHelpText.text = drink.drinkHelp; 
    }

    public void FocusOnContent() {
        targetPos = contentPos;
    }
    public void FocusOnMain() {
        targetPos = mainPos;
    }
    void MoveArea() {
        if (areaRecTrans.localPosition.x > targetPos.x) {
            Vector3 pos = areaRecTrans.localPosition;
            pos.x -= 20;
            areaRecTrans.localPosition = pos;
        } else if(areaRecTrans.localPosition.x < targetPos.x) {
            Vector3 pos = areaRecTrans.localPosition;
            pos.x += 20;
            areaRecTrans.localPosition = pos;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        areaRecTrans = this.GetComponent<RectTransform>();
        try {
            drinks = DrinkData.instance.Drinks;
            foreach (DrinkData.DrinkInfo drinkinfo in drinks) {
                GameObject inst = Instantiate(buttonPreb);
                inst.GetComponent<DrinkNameButton>().drinkInfo = drinkinfo;
                inst.transform.SetParent(menuScrollContentTrans);
                inst.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                DrinkList.Add(inst.GetComponent<DrinkNameButton>());
            }
        }
        catch (Exception e){
            Debug.Log("菜单列表数据获取出错");
            Debug.Log(e);
        }
        
    }
    public void ReturnButtonOnClick() {
        FocusOnMain();
    }

    // Update is called once per frame
    void Update()
    {
        MoveArea();
    }
}
