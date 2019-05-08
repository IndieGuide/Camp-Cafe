using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceAni : MonoBehaviour
{
    //图片固定位置
    protected Vector2[] aniPosData = { new Vector2(-794, 608), new Vector2(-698, 608), new Vector2(-436, 608), new Vector2(-187, 608), new Vector2(-84, 608) };
    public string nameId;
    protected Transform borderTrans;
    Vector2 aniPos;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    void Awake() {
        borderTrans = GameObject.Find("Border").transform;
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    public enum PosEnum {
        Left,
        LittleLeft,
        Middle,
        LittleRight,
        Right
    }
    public void ChangePos(string postring) {
        //先放大图片
        int posInt = int.Parse(postring);
        PosEnum posType = (PosEnum)posInt;
        //Sprite sprite = gameObject.GetComponent<Image>().sprite;
        //aniPos.y = sprite.rect.height * 3 / 2;
        //switch (posType) {
        //    case PosEnum.Left:
        //        aniPos.x = aniPosData[0].x;
        //        break;
        //    case PosEnum.LittleLeft:
        //        aniPos.x = aniPosData[1].x;
        //        break;
        //    case PosEnum.Middle:
        //        aniPos.x = aniPosData[2].x;
        //        break;
        //    case PosEnum.LittleRight:
        //        aniPos.x = aniPosData[3].x;
        //        break;
        //    case PosEnum.Right:
        //        aniPos.x = aniPosData[4].x;
        //        break;
        //}
        RectTransform aniRecTrans = gameObject.transform.GetComponent<RectTransform>();

        aniRecTrans.anchoredPosition = aniPos;
        aniRecTrans.localScale = new Vector3(3, 3, 1);
        borderTrans = GameObject.Find("Border").transform;
        gameObject.transform.SetSiblingIndex(borderTrans.GetSiblingIndex() - 1);
    }

    // Update is called once per frame
    void Update() {

    }
    internal void SetAni(string aniname) {
        ChangeState(aniname);
        Sprite spr = spriteRenderer.sprite;
        RectTransform imgRecTrans = gameObject.transform.GetComponent<RectTransform>();
        imgRecTrans.sizeDelta = new Vector2(spr.bounds.size.x * 100, spr.bounds.size.y * 100);
        aniPos.y = spr.bounds.size.y * 100 / 2;
        spriteRenderer.color = new Color(255, 255, 255, 255);
    }

    private void ChangeState(string aniname) {
        switch (aniname) {
            case "普通":
                Debug.Log("进入状态机:" + aniname);
                animator.SetInteger("AniState", 0);
                break;
            case "微笑":
                Debug.Log("进入状态机:" + aniname);
                animator.SetInteger("AniState", 1);
                break;
            case "生气":
                Debug.Log("进入状态机:" + aniname);
                animator.SetInteger("AniState", 2);
                break;
            case "悲伤":
                Debug.Log("进入状态机:" + aniname);
                animator.SetInteger("AniState", 3);
                break;
            case "鄙夷":
                Debug.Log("进入状态机:" + aniname);
                animator.SetInteger("AniState", 4);
                break;
            case "张嘴":
                Debug.Log("进入状态机:" + aniname);
                animator.SetInteger("AniState", 5);
                break;
            case "死目":
                Debug.Log("进入状态机:" + aniname);
                animator.SetInteger("AniState", 6);
                break;
            default:
                Debug.Log("从default进入状态机:" + aniname);
                animator.SetInteger("AniState", 0);
                break;
        }
    }

    internal void FadeOutAndDelete() {
        TalkShow.instance.rowIndex++;
        TalkShow.instance.ResolveNextText();
        Destroy(gameObject);
    }
}
