using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class DrinkDataTest {
        GameObject m_obj;
        DrinkData drinkData;
        ItemManager itemManager;
        [SetUp]
        public void SetUp() {
            m_obj = new GameObject("TestGameObject");
            drinkData = m_obj.AddComponent<DrinkData>();
            itemManager = m_obj.AddComponent<ItemManager>();
            itemManager.Awake();
            drinkData.itemData = itemManager.itemData;
        }

        [UnityTest]
        public IEnumerator 饮料说明格式测试() {
            string drinkHelpStr1 = "一杯蜂蜜柚子茶由<color=#8BBDB5>4份水</color>，<color=#C5D5E3>2份冰块</color>，以及必要的配料<color=#E6543C>葡萄柚粒</color>构成，推荐使用<color=#DFD664>蜂蜜</color>作为甜味剂。";
            string drinkHelpStr2 = "一杯香草咖啡可乐由<color=#B37A67>3份咖啡</color>，<color=#C5D5E3>2份冰块</color>，<color=#D13A18>3份快乐水</color>，以及必要的配料<color=#A899A3>香草</color>构成，推荐使用<color=#6483BD>方糖</color>作为甜味剂。";
            yield return null;
            Assert.AreEqual(drinkHelpStr1, drinkData.Drinks[1].drinkHelp);
            Assert.AreEqual(drinkHelpStr2, drinkData.Drinks[6].drinkHelp);
        }

        [UnityTest]
        public IEnumerator 饮料使用材料总数测试() {

            yield return null;

            foreach (DrinkData.DrinkInfo drinkinfo in drinkData.Drinks) {
                int number = 0;
                foreach (DrinkData.ItemBean bean in drinkinfo.itemBeanList) {
                    number += bean.itemNumber;
                }
                Assert.AreEqual(10, number);
            }
        }
        [UnityTest]
        public IEnumerator 饮料中的材料数据与材料数据库中的材料名是否匹配() {

            yield return null;

            foreach (DrinkData.DrinkInfo drinkinfo in drinkData.Drinks) {
                foreach (DrinkData.ItemBean bean in drinkinfo.itemBeanList) {
                    bool isBeanExists = false;
                    foreach (ItemData item in itemManager.itemData) {
                        if (bean.itemName == item.itemName) {
                            isBeanExists = true;
                            break;
                        }
                    }
                    Assert.AreEqual(true, isBeanExists);
                }

            }
        }
    }
}
