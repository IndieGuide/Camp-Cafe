using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class DrinkDataTest
    {
        GameObject m_obj;
        DrinkData drinkData;
        ItemManager itemManager;
        [SetUp]
        public void SetUp() {
            m_obj = new GameObject("TestGameObject");
            drinkData = m_obj.AddComponent<DrinkData>();
            itemManager = m_obj.AddComponent<ItemManager>();
        }

        [UnityTest]
        public IEnumerator DrinkDataTestWithEnumeratorPasses()
        {
            string drinkHelpStr1 = "一杯蜂蜜柚子茶由4份水,2份冰块,2份葡萄柚粒,2份蜂蜜构成。";
            yield return null;

            Assert.AreEqual(drinkHelpStr1, drinkData.Drinks[1].drinkHelp);
        }

        [UnityTest]
        public IEnumerator DrinkDataItemNumberTest() {

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
        public IEnumerator DrinkDataItemInstanceTest() {

            yield return null;
            
            foreach (DrinkData.DrinkInfo drinkinfo in drinkData.Drinks) {
                foreach (DrinkData.ItemBean bean in drinkinfo.itemBeanList) {
                    bool isBeanExists = false;
                    foreach (ItemData item in itemManager.itemData) {
                        if(bean.itemName == item.itemName) {
                            isBeanExists = true;
                            break;
                        } 
                    }
                    if (!isBeanExists) {
                        Debug.Log(bean.itemName);
                    }
                    Assert.AreEqual(true, isBeanExists);
                }

            }
        }
    }
}
