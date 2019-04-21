using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkData : MonoBehaviour {
    public static DrinkData instance;
    public List<Tag> tags = new List<Tag>();
    private List<DrinkInfo> drinks = new List<DrinkInfo>();
    public List<ItemData> itemData;

    public List<DrinkInfo> Drinks
    {
        get
        {
            return drinks;
        }

        set
        {
            drinks = value;
        }
    }

    private void Awake() {
        instance = this;
        List<string[]> tagDataList = InstanceLoad.GetInstanceData("Texts/TagData");
        foreach (string[] insDataArr in tagDataList) {

            Tag tag = new Tag(int.Parse(insDataArr[0]), insDataArr[1], insDataArr[2]);
            Debug.Log(tag.tagName);
            tags.Add(tag);
        }
        List<string[]> drinkDataList = InstanceLoad.GetInstanceData("Texts/DrinkData");
        foreach (string[] insDataArr in drinkDataList) {
            DrinkInfo drink = new DrinkInfo(int.Parse(insDataArr[0]), int.Parse(insDataArr[1]), insDataArr[2], insDataArr[3]);
            Debug.Log(drink.drinkName);
            drinks.Add(drink);
        }
        
    }

    private void DrinkSetting() {
        //柠檬红茶
        drinks[0].itemBeanList.Add(new ItemBean("水", 4));
        drinks[0].itemBeanList.Add(new ItemBean("冰块", 2));
        drinks[0].itemBeanList.Add(new ItemBean("红茶", 1));
        drinks[0].itemBeanList.Add(new ItemBean("柠檬片", 2));
        drinks[0].itemBeanList.Add(new ItemBean("果糖", 1));
        drinks[0].tagList.Add(GetTagByName("清爽的")); 
        drinks[0].tagList.Add(GetTagByName("酸味的")); 
        //蜂蜜柚子茶
        drinks[1].itemBeanList.Add(new ItemBean("水", 4));
        drinks[1].itemBeanList.Add(new ItemBean("冰块", 2));
        drinks[1].itemBeanList.Add(new ItemBean("葡萄柚粒", 2));
        drinks[1].itemBeanList.Add(new ItemBean("蜂蜜", 2));
        drinks[1].tagList.Add(GetTagByName("清爽的")); 
        drinks[1].tagList.Add(GetTagByName("酸味的")); 
        drinks[1].tagList.Add(GetTagByName("甜味的"));
    }
    Tag GetTagByName(string name) {
        foreach (Tag tag in tags) {
            if (tag.tagName == name) {
                return tag;
            }
        }
        return null;
    }

    private void Start() {
        itemData = GameObject.Find("ItemArea").GetComponent<ItemManager>().itemData;
        DrinkSetting();
    }

    public class DrinkInfo {

        public int drinkId;
        public int drinkPrice;
        public string drinkName;
        public string drinkImgPath;
        public string drinkIntro;
        public List<ItemBean> itemBeanList = new List<ItemBean>();
        public List<Tag> tagList = new List<Tag>();

        public DrinkInfo(int drinkId, int drinkPrice, string drinkName, string drinkIntro) {
            this.drinkId = drinkId;
            this.drinkName = drinkName;
            this.drinkPrice = drinkPrice;
            this.drinkImgPath = "Sprites/Drinks/" + drinkName;
            this.drinkIntro = drinkIntro;
        }
    }
    public class ItemBean {
        public int itemId;
        public string itemName;
        public int itemNumber;

        public ItemBean(string itemName, int itemNumber) {
            this.itemName = itemName;
            this.itemNumber = itemNumber;
            //根据itemdata得到itemId
            foreach(ItemData item in DrinkData.instance.itemData) {
                if (item.itemName == itemName) {
                    itemId = item.itemId;
                }
            }
        }

        public ItemBean(int itemId, string itemName, int itemNumber) {
            this.itemId = itemId;
            this.itemName = itemName;
            this.itemNumber = itemNumber;
        }
    }

    public class Tag {
        public int tagId;
        public string tagName;
        public string tagType;

        public Tag(int tagId, string tagType,string tagName) {
            this.tagId = tagId;
            this.tagType = tagType;
            this.tagName = tagName;
        }
    }

}
