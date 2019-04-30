using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarkCupControl : MonoBehaviour
{
    public Outline m_outline;
    public LiquidImage liquidImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider) {
        m_outline.enabled = true;
        Debug.Log("开始接触");
    }
    void OnTriggerExit2D(Collider2D collider) {
        m_outline.enabled = false;
        if (collider != null) {
            if (!Input.GetMouseButton(0) && !liquidImage.IsCupFull()) {
                CraftItem craftItem = collider.gameObject.GetComponent<CraftItemCollider>().bindItem;
                foreach(AmountCacul item in ItemManager.instance.amountCaculArr) {
                    if(item.bindItem == craftItem) {
                        item.AddOnClick();
                    }
                }
            }
            Debug.Log("接触结束");
        }
    }

}
