using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    List<DrinkNameButton> drinkList = new List<DrinkNameButton>();
    List<TagButton> tagList = new List<TagButton>();
    List<DrinkData.DrinkInfo> drinks;
    List<DrinkData.Tag> tags;
    public GameObject buttonPreb;
    public GameObject tagButtonPrefab;
    public Text drinkNameText;
    public Text drinkIntroText;
    public Text drinkHelpText;
    
    public Transform drinkButtonNode;
    public Transform tagButtonNode;
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
        try {
            if (areaRecTrans.localPosition.x > targetPos.x) {
                Vector3 pos = areaRecTrans.localPosition;
                pos.x -= 20;
                areaRecTrans.localPosition = pos;
            } else if (areaRecTrans.localPosition.x < targetPos.x) {
                Vector3 pos = areaRecTrans.localPosition;
                pos.x += 20;
                areaRecTrans.localPosition = pos;
            }
        }catch(Exception e) {
            Debug.Log(e);
        }
    }
    public void RenderMenuByTag(DrinkData.Tag tag) {
        //清空列表中的对象
        for (int i = drinkList.Count - 1; i >= 0; i--) {
            Destroy(drinkList[i].gameObject);
            drinkList.Remove(drinkList[i]);
        }
        //渲染新的对象
        List<DrinkData.DrinkInfo> selectedDrinks = new List<DrinkData.DrinkInfo>();
        foreach (DrinkData.DrinkInfo drink in drinks) {
            foreach(DrinkData.Tag tagvar in drink.tagList) {
                if(tag.tagId == tagvar.tagId) {
                    selectedDrinks.Add(drink);
                    break;
                }
            }
        }
        RenderMenu(selectedDrinks);
    }
    void RenderMenu(List<DrinkData.DrinkInfo> drinks) {
        try {
            foreach (DrinkData.DrinkInfo drinkinfo in drinks) {
                GameObject inst = Instantiate(buttonPreb);
                inst.GetComponent<DrinkNameButton>().drinkInfo = drinkinfo;
                inst.transform.SetParent(drinkButtonNode);
                inst.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                DrinkList.Add(inst.GetComponent<DrinkNameButton>());
            }
        }
        catch (Exception e) {
            Debug.Log("菜单列表数据获取出错");
            Debug.Log(e);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        areaRecTrans = this.GetComponent<RectTransform>();
        drinks = DrinkData.instance.Drinks;
        RenderMenu(drinks);
        try {
            tags = DrinkData.instance.tags;
            int index = 0;
            foreach(DrinkData.Tag tag in tags) {
                GameObject inst = Instantiate(tagButtonPrefab);
                inst.GetComponent<TagButton>().tag = tag;
                inst.transform.SetParent(tagButtonNode);
                inst.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                inst.GetComponent<RectTransform>().anchoredPosition = new Vector3(3.5f, 20f - 60f * index, 0f);

                tagList.Add(inst.GetComponent<TagButton>());
                index++;
            }
        }
        catch(Exception e) {
            Debug.Log("Tag列表数据获取错误");
            Debug.Log(e);
        }
        
    }
    public void ReturnButtonOnClick() {
        FxCollection.PlayButtonClickFx();
        FocusOnMain();
    }

    // Update is called once per frame
    void Update()
    {
        MoveArea();
    }
}
