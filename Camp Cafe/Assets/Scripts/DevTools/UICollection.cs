using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICollection : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public class JumpBorderControl : MonoBehaviour {
        Transform m_trans;
        float scale = 0.0f;
        float xScale = 0.0f;
        float yScale = 0.0f;
        private void Awake() {
            m_trans = gameObject.GetComponent<RectTransform>();
            m_trans.localScale = new Vector2(xScale, yScale);
        }
        private void Update() {
            if (yScale >= 0.98f) {
                Vector3 normalScale = new Vector3(1.00f, 1.00f, 1.00f);
                m_trans.localScale = normalScale;
                Destroy(this);
                return;
            }
            xScale = Mathf.Lerp(xScale, 1f, 0.4f);
            yScale = Mathf.Lerp(yScale, 1f, 0.25f);
            Vector3 newScale = new Vector3(xScale, yScale, 1.0f);
            m_trans.localScale = newScale;
        }
    }
    public class AlphaControl : MonoBehaviour {
        Image[] images;
        Text[] texts;
        float alpha = 0.0f;
        float clearAlpha = 0.0f;
        float normalAlpha = 1.0f;
        float speed = 0.2f;
        bool isFadeIn;
        bool isImageExists;
        bool isTextExists;
        bool isImageActive = true;
        bool isTextActive = true;
        internal void setInOrOut(bool isfadein) {
            isFadeIn = isfadein;
            if (isfadein) {
                alpha = 0.0f;
            } else {
                alpha = 1.0f;
            }
        }
        internal void setInOrOut(bool isfadein, float targetalpha) {
            isFadeIn = isfadein;
            if (isfadein) {
                alpha = 0.0f;
                normalAlpha = targetalpha;
            } else {
                alpha = 1.0f;
                clearAlpha = targetalpha;
            }
        }
        internal void setSpeed (float speed){
            this.speed = speed;
        }
        private void Awake() {
            images = gameObject.GetComponentsInChildren<Image>();
            texts = gameObject.GetComponentsInChildren<Text>();
            isImageExists = (images != null) ? true : false;
            isTextExists = (texts != null) ? true : false;
        }
        private void Update() {
            if (isFadeIn && isImageExists) {
                
                if (Mathf.Abs(alpha - normalAlpha) <= 0.02f) {

                    foreach (Image image in images) {
                        Color originColor = image.color;
                        Color normalColor = new Color(originColor.r, originColor.g, originColor.b, normalAlpha);
                        image.color = normalColor;
                    }
                    Destroy(this);
                    return;
                }
                alpha = Mathf.Lerp(alpha, normalAlpha, speed);
                foreach (Image image in images) {
                    Color originColor = image.color;
                    Color newColor = new Color(originColor.r, originColor.g, originColor.b, alpha);
                    image.color = newColor;
                }
            } else if (!isFadeIn && isImageExists) {
                if (Mathf.Abs(alpha - clearAlpha) <= 0.02f) {

                    foreach (Image image in images) {
                        Color originColor = image.color;
                        Color normalColor = new Color(originColor.r, originColor.g, originColor.b, clearAlpha);
                        image.color = normalColor;
                    }
                    Destroy(this);
                    return;
                }
                alpha = Mathf.Lerp(alpha, clearAlpha, speed);
                foreach (Image image in images) {
                    Color originColor = image.color;
                    Color newColor = new Color(originColor.r, originColor.g, originColor.b, alpha);
                    image.color = newColor;
                }
            }

            if (isFadeIn && isTextExists) {
                if (Mathf.Abs(alpha - normalAlpha) <= 0.02f) {

                    foreach (Text text in texts) {
                        Color originColor = text.color;
                        Color normalColor = new Color(originColor.r, originColor.g, originColor.b, normalAlpha);
                        text.color = normalColor;
                    }
                    Destroy(this);
                    return;
                }
                alpha = Mathf.Lerp(alpha, normalAlpha, speed);
                foreach (Text text in texts) {
                    Color originColor = text.color;
                    Color newColor = new Color(originColor.r, originColor.g, originColor.b, alpha);
                    text.color = newColor;
                }
            } else if (!isFadeIn && isTextExists) {
                if (Mathf.Abs(alpha - clearAlpha) <= 0.02f) {
                    
                    foreach (Text text in texts) {
                        Color originColor = text.color;
                        Color normalColor = new Color(originColor.r, originColor.g, originColor.b, clearAlpha);
                        text.color = normalColor;
                    }
                    Destroy(this);
                    return;
                }
                alpha = Mathf.Lerp(alpha, clearAlpha, speed);
                
                foreach (Text text in texts) {
                    Color originColor = text.color;
                    Color newColor = new Color(originColor.r, originColor.g, originColor.b, alpha);
                    text.color = newColor;
                }
            }
        }

        internal void setTextActive(bool v) {
            isTextActive = v;
            isTextExists = v;
        }

        internal void setImageActive(bool v) {
            isImageActive = v;
            isImageExists = v;
        }
    }


    public class PosControl : MonoBehaviour {
        RectTransform m_trans;
        Vector3 targetPos;
        Vector3 originPos;
        Vector3 pos;
        float posX;
        float posY;
        float posZ;
        float speedx;
        float speedy;
        float speedLerp;
        //internal void SetPosControl(Vector3 originpos,Vector3 targetpos,float speedpx) {
        //    originPos = originpos;
        //    targetPos = targetpos;
        //    speedx = speedpx;
        //    speedy = speedpx;
        //    speedx = (targetPos.x >= originPos.x) ? speedx : -speedx;
        //    speedy = (targetPos.y >= originPos.y) ? speedy : -speedy;
        //}
        internal void SetPosControl(Vector3 originpos, Vector3 targetpos, float speedlerp) {
            originPos = originpos;
            targetPos = targetpos;
            speedLerp = speedlerp;
            m_trans.localPosition = originPos;
            pos = originPos;
            posX = pos.x;
            posY = pos.y;
            posZ = pos.z;
        }
        private void Awake() {
            m_trans = gameObject.GetComponent<RectTransform>();
        }
        private void Update() {
            if (Mathf.Abs(pos.x - targetPos.x) <= 0.02f && Mathf.Abs(pos.y - targetPos.y) <= 0.02f && Mathf.Abs(pos.z - targetPos.z) <= 0.02f) {
                m_trans.localPosition = targetPos;
                Destroy(this);
            } else {
                posX = Mathf.Lerp(posX, targetPos.x, speedLerp);
                posY = Mathf.Lerp(posY, targetPos.y, speedLerp);
                posZ = Mathf.Lerp(posZ, targetPos.z, speedLerp);
                pos = new Vector3(posX, posY, posZ);
                m_trans.localPosition = pos;
            }
        }

    }
    public class AlphaPingPongControl : MonoBehaviour {
        Image[] images;
        Text[] texts;
        float alpha = 0.0f;
        float alphaMin = 0.0f;
        float alphaMax = 1.0f;
        float speedLerp = 0.2f;
        bool isImageExists;
        bool isTextExists;
        bool isImageActive = true;
        bool isTextActive = true;
        bool isAlphaAdd = true;
        internal void setAlphaRange(float alphamin, float alphamax, float speedlerp) {
            alphaMin = alphamin;
            alphaMax = alphamax;
            speedLerp = speedlerp;
            alpha = alphaMin;
            isAlphaAdd = true;
        }
        private void Awake() {
            images = gameObject.GetComponentsInChildren<Image>();
            texts = gameObject.GetComponentsInChildren<Text>();
            isImageExists = (images != null) ? true : false;
            isTextExists = (texts != null) ? true : false;
        }
        private void Update() {
            if (isImageExists) {
                float targetAlpha = (isAlphaAdd) ? alphaMax : alphaMin;
                if (Mathf.Abs(alpha - targetAlpha) <= 0.02f) {
                    foreach (Image image in images) {
                        Color originColor = image.color;
                    }
                    isAlphaAdd = !isAlphaAdd;
                }
                alpha = Mathf.Lerp(alpha, targetAlpha, speedLerp);
                foreach (Image image in images) {
                    Color originColor = image.color;
                    Color newColor = new Color(originColor.r, originColor.g, originColor.b, alpha);
                    image.color = newColor;
                }
            }

            if (isTextExists) {
                float targetAlpha = (isAlphaAdd) ? alphaMax : alphaMin;
                if (Mathf.Abs(alpha - targetAlpha) <= 0.02f) {
                    foreach (Text text in texts) {
                        Color originColor = text.color;
                    }
                    isAlphaAdd = !isAlphaAdd;
                    return;
                }
                alpha = Mathf.Lerp(alpha, targetAlpha, speedLerp);
                foreach (Text text in texts) {
                    Color originColor = text.color;
                    Color newColor = new Color(originColor.r, originColor.g, originColor.b, alpha);
                    text.color = newColor;
                }
            }
        }
        internal void DestroyConTroller() {
            Destroy(this);
        }
        internal void setTextActive(bool v) {
            isTextActive = v;
            isTextExists = v;
        }

        internal void setImageActive(bool v) {
            isImageActive = v;
            isImageExists = v;
        }
    }
    public class TextPlayControl : MonoBehaviour {

        Text targetText;
        string targetStr;
        float textSpeed;
        bool isPlayingText = true;

        public float TextSpeed { get => textSpeed; set => textSpeed = value; }

        private void Awake() {
            targetText = gameObject.GetComponent<Text>();
            targetStr = targetText.text;
            targetText.text = "";
            
            StartCoroutine(ShowText(targetStr));
        }
        private void Update() {
            if (!isPlayingText) {
                Destroy(this);
            }
        }

        private IEnumerator ShowText(string text) {
            text = text.Trim();
            text = text.Substring(1, text.Length - 2);
            text = "『" + text + "』";
            //i为当前显示字符长度
            int i = 0;
            int strLength = text.Length;
            string colHeadStr = "";
            bool isStringCol = false;
            string showStr = "";
            isPlayingText = true;
            
            while (i < strLength) {
                //识别并不显示颜色代码
                if (text[i].ToString() == "<" && text[i + 1].ToString() != "/") {
                    isStringCol = true;
                    int j = 1;
                    while (text[i + j].ToString() != ">") {
                        j++;
                    }
                    colHeadStr = text.Substring(i, j + 1);
                    i += j + 1;
                } else if (text[i].ToString() == "<" && text[i + 1].ToString() == "/") {
                    i += 8;
                    isStringCol = false;
                }

                //向显示字符中添加新字符
                if (isStringCol) {
                    showStr += colHeadStr + text[i].ToString() + "</color>";
                } else if (text[i] == '\\') {
                    //忽略转行
                    showStr += '\n';
                    i++;
                } else {
                    showStr += text[i].ToString();
                }
                //播放音效
                if (i % 2 == 0) {
                    FxCollection.PlayTextFx();
                }
                //更新当前文字
                targetText.text = showStr;
                //识别换行
                targetText.text = targetText.text.Replace("\\n", "\n");
                i++;
                yield return new WaitForSeconds(TextSpeed);
            }
            FxCollection.PlayTextOverFx();
            isPlayingText = false;
            StopCoroutine("ShowText");
        }
        //还未使用，因为觉得黑场中的文字也许不需要这么花哨，不过如果想使用，BlockText类需要重构，让uicollection来控制，而不是一个static List
        private IEnumerator ShowTextShadow(string text) {

            List<BlockText> blockTexts = new List<BlockText>();

            GameObject blockTextPrefab = Resources.Load<GameObject>("Prefabs/BlockText");
            Transform parent = gameObject.transform.parent;
            GameObject blockTextObjOne = Instantiate(blockTextPrefab, parent);
            blockTexts.Add(blockTextObjOne.GetComponent<BlockText>());
            RectTransform firstRect = blockTextObjOne.GetComponent<RectTransform>();
            RectTransform targetRect = targetText.gameObject.GetComponent<RectTransform>();
            Vector3 targetPos = new Vector3(targetRect.localPosition.x - targetRect.rect.width/2, targetRect.localPosition.y+targetRect.rect.height/2, targetRect.localPosition.z);
            firstRect.localPosition = targetPos;

            text = text.Trim();
            text = text.Substring(1, text.Length - 2);
            text = "『" + text + "』";
            //i为当前显示字符长度
            int i = 0;
            int strLength = text.Length;
            string colHeadStr = "";
            bool isStringCol = false;
            bool isChangeRow = false;
            while (i < strLength) {
                //识别并不显示颜色代码
                if (text[i].ToString() == "<" && text[i + 1].ToString() != "/") {
                    isStringCol = true;
                    int j = 1;
                    while (text[i + j].ToString() != ">") {
                        j++;
                    }
                    colHeadStr = text.Substring(i, j + 1);
                    i += j + 1;
                } else if (text[i].ToString() == "<" && text[i + 1].ToString() == "/") {
                    i += 8;
                    isStringCol = false;
                }
                //向显示字符中添加新字符
                if (isStringCol) {
                    //showStr += colHeadStr + text[i].ToString() + "</color>";
                } else if (text[i] == '\\') {
                    //忽略转行
                    //showStr += '\n';
                    i++;
                    isChangeRow = true;
                } else {
                    //showStr += text[i].ToString();

                    //GameObject blockTextPrefab = Resources.Load<GameObject>("Prefabs/BlockText");
                    //Transform parent = BlockText.blockTextList[0].gameObject.transform.parent;

                    if (i == 0) {
                        GameObject blockTextObj2 = Instantiate(blockTextPrefab, parent);
                        blockTextObj2.GetComponent<BlockText>().SetText(text[i + 1].ToString());
                        i++;
                    } else {

                        GameObject blockTextObj = Instantiate(blockTextPrefab, parent);
                        if (isChangeRow) {
                            blockTextObj.GetComponent<BlockText>().ChangeRow();
                            isChangeRow = false;
                        }
                        blockTextObj.GetComponent<BlockText>().SetText(text[i].ToString());

                    }
                }

                i++;
                yield return new WaitForSeconds(textSpeed);
            }
            StopCoroutine("ShowTextShadow");
            Debug.Log("结束");
            BlockText blockText0 = BlockText.blockTextList[0];
            int index = 0;
            foreach (BlockText item in BlockText.blockTextList) {
                if (index != 0) {
                    Destroy(item.gameObject);
                }
                index++;
            }
            BlockText.blockTextList.Clear();
            BlockText.blockTextList.Add(blockText0);
        }
    }

    internal static void PlayText(Text showText, string text, float speed) {
        if (showText.gameObject.GetComponent<TextPlayControl>() != null) {
            Destroy(showText.gameObject.GetComponent<TextPlayControl>());
        }
        showText.text = text;
        TextPlayControl control = showText.gameObject.AddComponent<TextPlayControl>();
        control.TextSpeed = speed;
    }
    internal static void JumpBorder(GameObject obj) {
        if (obj.GetComponent<JumpBorderControl>() != null) {
            Destroy(obj.GetComponent<JumpBorderControl>());
        }
        obj.AddComponent<JumpBorderControl>();
    }
    internal static void MoveToPos(GameObject obj, Vector3 targetpos, float speedlerp) {
        if (obj.GetComponent<PosControl>() != null) {
            Destroy(obj.GetComponent<PosControl>());
        }
        PosControl posControl = obj.AddComponent<PosControl>();
        posControl.SetPosControl(obj.GetComponent<RectTransform>().localPosition, targetpos, speedlerp);
    }
    internal static void AlphaFade(GameObject obj, bool isfadein) {
        if (obj.GetComponent<AlphaControl>() != null) {
            Destroy(obj.GetComponent<AlphaControl>());
        }
        AlphaControl alphaControl = obj.AddComponent<AlphaControl>();
        alphaControl.setInOrOut(isfadein);
    }
    internal static void AlphaFade(GameObject obj, bool isfadein,float targetalpha,float speed) {
        if (obj.GetComponent<AlphaControl>() != null) {
            Destroy(obj.GetComponent<AlphaControl>());
        }
        AlphaControl alphaControl = obj.AddComponent<AlphaControl>();
        alphaControl.setInOrOut(isfadein,targetalpha);
        alphaControl.setSpeed(speed);
    }
    internal static void AlphaFade(GameObject obj, bool isfadein, float targetalpha) {
        if (obj.GetComponent<AlphaControl>() != null) {
            Destroy(obj.GetComponent<AlphaControl>());
        }
        AlphaControl alphaControl = obj.AddComponent<AlphaControl>();
        alphaControl.setInOrOut(isfadein, targetalpha);
    }
    internal static void AlphaFadeImg(GameObject obj, bool isfadein) {
        if (obj.GetComponent<AlphaControl>() != null) {
            Destroy(obj.GetComponent<AlphaControl>());
        }
        AlphaControl alphaControl = obj.AddComponent<AlphaControl>();
        alphaControl.setInOrOut(isfadein);
        alphaControl.setTextActive(false);
    }
    internal static void AlphaFadeImg(GameObject obj, bool isfadein, float targetalpha) {
        if (obj.GetComponent<AlphaControl>() != null) {
            Destroy(obj.GetComponent<AlphaControl>());
        }
        AlphaControl alphaControl = obj.AddComponent<AlphaControl>();
        alphaControl.setInOrOut(isfadein, targetalpha);
        alphaControl.setTextActive(false);
    }
    internal static void AlphaFadeText(GameObject obj, bool isfadein) {
        if (obj.GetComponent<AlphaControl>() != null) {
            Destroy(obj.GetComponent<AlphaControl>());
        }
        AlphaControl alphaControl = obj.AddComponent<AlphaControl>();
        alphaControl.setInOrOut(isfadein);
        alphaControl.setImageActive(false);
    }
    internal static void AlphaFadeText(GameObject obj, bool isfadein, float targetalpha) {
        if (obj.GetComponent<AlphaControl>() != null) {
            Destroy(obj.GetComponent<AlphaControl>());
        }
        AlphaControl alphaControl = obj.AddComponent<AlphaControl>();
        alphaControl.setInOrOut(isfadein, targetalpha);
        alphaControl.setImageActive(false);
    }
    internal static void AlphaPingPong(GameObject obj, float alphamin, float alphamax, float speedlerp) {
        if (obj.GetComponent<AlphaPingPongControl>() != null) {
            Destroy(obj.GetComponent<AlphaPingPongControl>());
        }
        AlphaPingPongControl alphaControl = obj.AddComponent<AlphaPingPongControl>();
        alphaControl.setAlphaRange(alphamin, alphamax, speedlerp);
    }
    internal static void SetImage(string imagePath, Image targetImage) {
        Sprite spr = Resources.Load<Sprite>(imagePath);
        targetImage.sprite = spr;
        RectTransform imgRecTrans = targetImage.transform.GetComponent<RectTransform>();
        imgRecTrans.sizeDelta = new Vector2(targetImage.sprite.bounds.size.x * 100, targetImage.sprite.bounds.size.y * 100);
    }
    internal static void SetImage(Sprite originCupSpr, Image targetImage) {
        Sprite spr = originCupSpr;
        targetImage.sprite = spr;
        RectTransform imgRecTrans = targetImage.transform.GetComponent<RectTransform>();
        imgRecTrans.sizeDelta = new Vector2(targetImage.sprite.bounds.size.x * 100, targetImage.sprite.bounds.size.y * 100);
    }
    internal static void SetImage(string imagePath, Image targetImage, Vector3 scale) {
        Sprite spr = Resources.Load<Sprite>(imagePath);
        targetImage.sprite = spr;
        RectTransform imgRecTrans = targetImage.transform.GetComponent<RectTransform>();
        imgRecTrans.localScale = scale;
        imgRecTrans.sizeDelta = new Vector2(targetImage.sprite.bounds.size.x * 100, targetImage.sprite.bounds.size.y * 100);
    }
    internal static void SetImage(Sprite originCupSpr, Image targetImage, Vector3 scale, Color color) {
        Sprite spr = originCupSpr;
        targetImage.sprite = spr;
        targetImage.color = color;
        RectTransform imgRecTrans = targetImage.transform.GetComponent<RectTransform>();
        imgRecTrans.localScale = scale;
        imgRecTrans.sizeDelta = new Vector2(targetImage.sprite.bounds.size.x * 100, targetImage.sprite.bounds.size.y * 100);
    }
    internal static void SetImage(Sprite originCupSpr, Image targetImage, Vector3 scale) {
        Sprite spr = originCupSpr;
        targetImage.sprite = spr;
        RectTransform imgRecTrans = targetImage.transform.GetComponent<RectTransform>();
        imgRecTrans.localScale = scale;
        imgRecTrans.sizeDelta = new Vector2(targetImage.sprite.bounds.size.x * 100, targetImage.sprite.bounds.size.y * 100);
    }
    internal static void SetAlphaClear(Image img) {
        Color newColor = new Color(img.color.r, img.color.g, img.color.b, 0f);
        img.color = newColor;
    }
    internal static void SetAlphaClear(Image[] imgs) {
        foreach (Image img in imgs) {
            Color newColor = new Color(img.color.r, img.color.g, img.color.b, 0f);
            img.color = newColor;
        }
    }
    internal static void SetAlphaClear(Text text) {
        Color newColor = new Color(text.color.r, text.color.g, text.color.b, 0f);
        text.color = newColor;
    }
    internal static void SetAlphaClear(Text[] texts) {
        foreach (Text text in texts) {
            Color newColor = new Color(text.color.r, text.color.g, text.color.b, 0f);
            text.color = newColor;
        }
    }
}
