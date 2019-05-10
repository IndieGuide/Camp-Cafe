using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceAni : MonoBehaviour {
    //图片固定位置
    protected Vector3[] aniPosData = { new Vector3(-372, 0, 0), new Vector3(-250, 0, 0), new Vector3(0, 0, 0), new Vector3(250, 0, 0), new Vector3(372, 0, 0) };
    private string nameId;
    protected Transform borderTrans;
    Vector3 aniPos;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    string aniName;
    bool isAniEndTriggered;
    //左是否是人物正面
    bool isLeftFront;
    float eyesTimer = 0;
    float eyesTimerLength = 3.0f;
    private AniTypeEnum lastAniType;

    public string NameId { get => nameId; set => nameId = value; }

    void Awake() {
        borderTrans = GameObject.Find("Border").transform;
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        isLeftFront = !spriteRenderer.flipX;
        animator.speed = 0.6f;
        PlayEyesAni();
    }

    internal void PlayTalk() {
        //animator.SetInteger("AniState",(int)m_state);
        PlayTalksAni();

    }

    public enum PosEnum {
        Left,
        LittleLeft,
        Middle,
        LittleRight,
        Right
    }
    public void ChangePos(string postring) {
        int posInt = int.Parse(postring);
        PosEnum posType = (PosEnum)posInt;
        switch (posType) {
            case PosEnum.Left:
                aniPos.x = aniPosData[0].x;
                spriteRenderer.flipX = isLeftFront ? true : false;
                break;
            case PosEnum.LittleLeft:
                aniPos.x = aniPosData[1].x;
                spriteRenderer.flipX = isLeftFront ? true : false;
                break;
            case PosEnum.Middle:
                aniPos.x = aniPosData[2].x;
                spriteRenderer.flipX = isLeftFront ? false : true;
                break;
            case PosEnum.LittleRight:
                aniPos.x = aniPosData[3].x;
                spriteRenderer.flipX = isLeftFront ? false : true;
                break;
            case PosEnum.Right:
                aniPos.x = aniPosData[4].x;
                spriteRenderer.flipX = isLeftFront ? false : true;
                break;
        }
        RectTransform aniRecTrans = gameObject.transform.GetComponent<RectTransform>();
        //设置坐标和缩放倍数
        aniRecTrans.localPosition = aniPos;
        aniRecTrans.localScale = new Vector3(3, 3, 1);
        //确保被UI框遮挡
        borderTrans = GameObject.Find("Border").transform;
        gameObject.transform.SetSiblingIndex(borderTrans.GetSiblingIndex() - 1);
    }
    internal void SetAniAndPos(string aniname, string postring) {
        SetAni(aniname);
        ChangePos(postring);
    }
    // Update is called once per frame
    void Update() {

        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);

        if (info.normalizedTime >= 1.0f && !isAniEndTriggered) {
            isAniEndTriggered = true;
            //Debug.Log("动画播放完毕");

            if (lastAniType == AniTypeEnum.Talk && UnityEngine.Random.Range(0f, 1f) <= 0.5f) {
                PlayEyesAni();
            }
            if (lastAniType == AniTypeEnum.Talk && TalkShow.instance.IsPlayingText) {
                PlayTalksAni();
            }

            if ((!TalkShow.instance.IsPlayingText || TalkShow.instance.nameText.text != nameId) && Time.time - eyesTimer >= eyesTimerLength) {
                PlayEyesAni();
                eyesTimerLength = UnityEngine.Random.Range(2.5f, 3.5f);
            }
            eyesTimer = Time.time;
        } else if ((info.normalizedTime < 1.0f) && isAniEndTriggered) {
            //Debug.Log("动画播放中");
            isAniEndTriggered = false;
        }
        if (Time.time - eyesTimer > eyesTimerLength) {
            isAniEndTriggered = false;
        }

    }
    internal void SetAni(string aniname) {
        aniName = aniname;
        Sprite spr = spriteRenderer.sprite;
        RectTransform imgRecTrans = gameObject.transform.GetComponent<RectTransform>();
        imgRecTrans.sizeDelta = new Vector2(spr.bounds.size.x * 100, spr.bounds.size.y * 100);
        spriteRenderer.color = new Color(255, 255, 255, 255);
    }

    public void PlayTalksAni() {
        PlayAni(AniTypeEnum.Talk);
    }
    public void PlayEyesAni() {
        PlayAni(AniTypeEnum.Eyes);
    }
    internal enum AniTypeEnum {
        Eyes = 0,
        Talk = 1,
        Static = 2

    }
    internal void PlayAni(AniTypeEnum anitype) {
        string message;
        string aniname = aniName;
        if (IsStaticAni(aniname)) {
            anitype = AniTypeEnum.Static;
        }
        lastAniType = anitype;
        switch (anitype) {
            case AniTypeEnum.Eyes:
                message = nameId + "播放眨眼动画";
                aniname = aniName + "0";
                break;
            case AniTypeEnum.Talk:
                message = nameId + "播放说话动画";
                aniname = aniName + "1";
                break;
            case AniTypeEnum.Static:
                message = nameId + "播放静态动画";
                aniname = aniName;
                break;
            default:
                Debug.Log("类型错误");
                break;
        }
        animator.Play(aniname, 0, 0f);

    }

    private bool IsStaticAni(string aniname) {
        if (nameId == "Phree" && (aniname == "死目" || aniname == "张嘴"))
            return true;
        if (nameId == "Soda" && (aniname == "打哈欠"))
            return true;
        if (nameId == "Boss" && (aniname == "开口笑" || aniname == "阴险笑"))
            return true;
        return false;
    }

    internal void FadeOutAndDelete() {
        TalkShow.instance.rowIndex++;
        TalkShow.instance.ResolveNextText();
        Destroy(gameObject);
    }
}
