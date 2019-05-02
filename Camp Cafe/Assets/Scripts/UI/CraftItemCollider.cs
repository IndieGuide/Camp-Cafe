using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CraftItemCollider : MonoBehaviour
{
    public CraftItem bindItem;
    private Vector3 mouseOriginPos;
    private Vector3 itemOriginPos;
    private Vector3 dragPos;
    Vector3 normalScale = new Vector3(1.0f, 1.0f, 1.0f);
    Vector3 smallScale = new Vector3(0.6f, 0.6f, 0.6f);
    private RectTransform m_rect;
    private Image m_image;
    public bool isAllowDrag;

    // Start is called before the first frame update
    void Awake()
    {
        //得到自己的必要组件
        m_rect = GetComponent<RectTransform>();
        m_image = GetComponent<Image>();
        //设置拖动部件初始不可见
        m_image.sprite = bindItem.GetComponent<Image>().sprite;
        m_image.color = ColorCollection.GetVecClear();
        //设置用于拖动逻辑的坐标
        itemOriginPos = GetComponent<RectTransform>().localPosition;
        dragPos = itemOriginPos;
    }
    public void ChangeBindItem(CraftItem binditem) {
        bindItem = binditem;
        m_image.sprite = bindItem.GetComponent<Image>().sprite;
        m_image.color = ColorCollection.GetVecClear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(BaseEventData eventData) {
        if (!isAllowDrag) return;
        //Debug.Log("被点击了");
        //Debug.Log("鼠标位置：" + Input.mousePosition);
        //Debug.Log("localPosition：" + m_rect.localPosition);
        //Debug.Log("anchoredPosition：" + m_rect.anchoredPosition);
        //Debug.Log("Position：" + m_rect.position);
        m_image.color = ColorCollection.GetVecNormal();
        m_rect.localScale = smallScale;
        mouseOriginPos = Input.mousePosition;
        
    }
    public void OnPointerUp(BaseEventData eventData) {
        if (!isAllowDrag) return;
        m_rect.localScale = normalScale;
        m_rect.localPosition = itemOriginPos;
        dragPos = itemOriginPos;
        m_image.color = ColorCollection.GetVecClear();
    }
    public void Drag(BaseEventData eventData) {
        if (!isAllowDrag) return;
        Vector3 off = Input.mousePosition - mouseOriginPos;
        mouseOriginPos = Input.mousePosition;
        dragPos = dragPos + off;
        m_rect.localPosition = dragPos;
    }
}
