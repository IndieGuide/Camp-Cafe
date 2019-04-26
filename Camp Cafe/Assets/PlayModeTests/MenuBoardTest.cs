using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MenuBoardTest
    {
        GameObject m_obj;
        DrinkData drinkData;
        MenuManager menuManager;
        [SetUp]
        public void SetUp() {
            m_obj = new GameObject("MenuBoardObject");
            drinkData = m_obj.AddComponent<DrinkData>();
            menuManager = m_obj.AddComponent<MenuManager>();
            menuManager.buttonPreb = Resources.Load<GameObject>("Prefabs/DrinkNameButton");
        }
        [UnityTest]
        public IEnumerator 菜单面板按钮数量测试()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
            Assert.AreEqual(drinkData.Drinks.Count, menuManager.DrinkList.Count);
        }
    }
}
