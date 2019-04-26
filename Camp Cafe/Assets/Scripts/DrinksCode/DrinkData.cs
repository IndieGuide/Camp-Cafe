using System;
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

            Tag tag = new Tag(int.Parse(insDataArr[0]), insDataArr[1],insDataArr[2]);
            //Debug.Log(tag.tagName);
            //Debug.Log(tag.tagId);
            //Debug.Log(tag.tagType);
            tags.Add(tag);
        }
        List<string[]> drinkDataList = InstanceLoad.GetInstanceData("Texts/DrinkData");
        foreach (string[] insDataArr in drinkDataList) {
            DrinkInfo drink = new DrinkInfo(int.Parse(insDataArr[0]), int.Parse(insDataArr[1]), insDataArr[2], insDataArr[3]);
            //Debug.Log(drink.drinkName);
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
        drinks[0].GetDrinkHelp();
        //蜂蜜柚子茶
        drinks[1].itemBeanList.Add(new ItemBean("水", 4));
        drinks[1].itemBeanList.Add(new ItemBean("冰块", 2));
        drinks[1].itemBeanList.Add(new ItemBean("葡萄柚粒", 2));
        drinks[1].itemBeanList.Add(new ItemBean("蜂蜜", 2));
        drinks[1].tagList.Add(GetTagByName("清爽的")); 
        drinks[1].tagList.Add(GetTagByName("酸味的")); 
        drinks[1].tagList.Add(GetTagByName("甜味的"));
        drinks[1].GetDrinkHelp();  
        //苏打柠檬
        drinks[2].itemBeanList.Add(new ItemBean("苏打水", 4));
        drinks[2].itemBeanList.Add(new ItemBean("冰块", 2));
        drinks[2].itemBeanList.Add(new ItemBean("柠檬片", 2));
        drinks[2].itemBeanList.Add(new ItemBean("果糖", 2));
        drinks[2].tagList.Add(GetTagByName("冒泡的")); 
        drinks[2].tagList.Add(GetTagByName("酸味的")); 
        drinks[2].tagList.Add(GetTagByName("清淡的"));
        drinks[2].GetDrinkHelp();
        //桂花清凉椰露
        drinks[3].itemBeanList.Add(new ItemBean("椰子汁", 4));
        drinks[3].itemBeanList.Add(new ItemBean("冰块", 2));
        drinks[3].itemBeanList.Add(new ItemBean("西米", 1));
        drinks[3].itemBeanList.Add(new ItemBean("蜂蜜", 2));
        drinks[3].itemBeanList.Add(new ItemBean("薄荷", 1));
        drinks[3].tagList.Add(GetTagByName("甜味的")); 
        drinks[3].tagList.Add(GetTagByName("浓郁的")); 
        drinks[3].tagList.Add(GetTagByName("清凉的"));
        drinks[3].GetDrinkHelp();
        //冰咖啡
        drinks[4].itemBeanList.Add(new ItemBean("咖啡", 4));
        drinks[4].itemBeanList.Add(new ItemBean("冰块", 4));
        drinks[4].itemBeanList.Add(new ItemBean("方糖", 2));
        drinks[4].tagList.Add(GetTagByName("浓郁的")); 
        drinks[4].tagList.Add(GetTagByName("甜味的")); 
        drinks[4].tagList.Add(GetTagByName("清凉的"));
        drinks[4].GetDrinkHelp();    
        //夏绿苏打
        drinks[5].itemBeanList.Add(new ItemBean("  苏打水  ", 4));
        drinks[5].itemBeanList.Add(new ItemBean("   冰块   ", 2));
        drinks[5].itemBeanList.Add(new ItemBean("   薄荷   ", 2));
        drinks[5].itemBeanList.Add(new ItemBean("   方糖   ", 2));
        drinks[5].tagList.Add(GetTagByName("     清凉的    ")); 
        drinks[5].tagList.Add(GetTagByName("    酸味的    ")); 
        drinks[5].tagList.Add(GetTagByName("    冒泡的    "));
        drinks[5].GetDrinkHelp();
        //香草咖啡可乐
        drinks[6].itemBeanList.Add(new ItemBean(" 咖啡", 3));
        drinks[6].itemBeanList.Add(new ItemBean("冰块 ", 2));
        drinks[6].itemBeanList.Add(new ItemBean(" 快乐水 ", 3));
        drinks[6].itemBeanList.Add(new ItemBean(" 方糖", 2));
        drinks[6].tagList.Add(GetTagByName("    冒泡的    ")); 
        drinks[6].tagList.Add(GetTagByName("    酸味的    ")); 
        drinks[6].tagList.Add(GetTagByName("    浓郁的    "));
        drinks[6].GetDrinkHelp();
        //椰奶西米露
        drinks[7].itemBeanList.Add(new ItemBean("  椰子汁  ", 4));
        drinks[7].itemBeanList.Add(new ItemBean("   冰块   ", 2));
        drinks[7].itemBeanList.Add(new ItemBean("西米", 2));
        drinks[7].itemBeanList.Add(new ItemBean("  蜂蜜  ", 2));
        drinks[7].tagList.Add(GetTagByName("     甜味的    ")); 
        drinks[7].tagList.Add(GetTagByName("    浓郁的    ")); 
        drinks[7].tagList.Add(GetTagByName("    清淡的    "));
        drinks[7].GetDrinkHelp();
    }
    Tag GetTagByName(string name) {
        Tag targetTag = new Tag(-1);
        foreach (Tag tag in tags) {
            if (tag.tagName.CompareTo(name.Trim()) == 0) {
                targetTag = tag;
            }
        }
        if (targetTag.tagId != -1) {
            return targetTag;
        } else {
            Debug.Log("饮品获取tag失败");
            return targetTag;
        }
    }

    private void Start() {
        try {
            itemData = GameObject.Find("ItemArea").GetComponent<ItemManager>().itemData;
        } catch(System.Exception e) {
            Debug.Log("ItemManager实例未正常获取");
        }
        try {
            DrinkSetting();
        } catch (System.Exception e) {
            Debug.Log("饮料设置失败");
        }
    }

    public class DrinkInfo {

        public int drinkId;
        public int drinkPrice;
        public string drinkName;
        public string drinkImgPath;
        public string drinkIntro;
        public string drinkHelp;
        public List<ItemBean> itemBeanList = new List<ItemBean>();
        public List<Tag> tagList = new List<Tag>();

        public DrinkInfo(int drinkId, int drinkPrice, string drinkName,string drinkIntro) {
            this.drinkId = drinkId;
            this.drinkName = drinkName;
            this.drinkPrice = drinkPrice;
            this.drinkImgPath = "Sprites/Drinks/" + drinkName;
            this.drinkIntro = drinkIntro;
        }

        public void GetDrinkHelp() {
            try {
                string drinkHelpStr = "";
                string itemsStr = "";
                foreach (ItemBean itembean in itemBeanList) {
                    itemsStr += ("<color=#" + instance.itemData[itembean.itemId].itemColor + ">" + itembean.itemNumber + "份" + itembean.itemName + "</color>" + ",");
                }
                //格式： "一杯蜂蜜柚子茶由<color=#8BBDB5>4份水</color>,<color=#C5D5E3>2份冰块</color>,<color=#E6543C>2份葡萄柚粒</color>,<color=#DFD664>2份蜂蜜</color>构成。"
                drinkHelpStr = "一杯" + drinkName + "由" + itemsStr.Substring(0, itemsStr.Length - 1) + "构成。";
                drinkHelp = drinkHelpStr;
            }catch(Exception e) {
                Debug.Log(e);
            }
        }
    }
    public class ItemBean {
        public int itemId;
        public string itemName;
        public int itemNumber;

        public ItemBean(string itemName, int itemNumber) {
            this.itemName = itemName.Trim();
            this.itemNumber = itemNumber;
            try {
                //根据itemdata得到itemId
                foreach (ItemData item in instance.itemData) {
                    if (item.itemName == this.itemName) {
                        itemId = item.itemId;
                    }
                }
            }
            catch {

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

        public Tag(int id) {
            this.tagId = id;
        }

        public Tag(int tagId, string tagType,string tagName) {
            this.tagId = tagId;
            this.tagType = tagType;
            this.tagName = tagName.Trim();
        }
    }

}
