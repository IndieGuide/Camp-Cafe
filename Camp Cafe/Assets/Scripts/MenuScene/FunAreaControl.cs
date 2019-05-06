using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FunAreaControl : MonoBehaviour
{
    string[] strArr = new string[]{
        "喝下我这杯红茶,明天就会看到陌生的天花板",
        "果断就会白给，犹豫就会败北",
        "image",
        "创作团队：碗又大又圆，面又长又宽  skr～",
        "我不想回去，至少现在不想"
    };
    public Text m_text;
    public Image m_image;
    public Sprite sprPlayBall;
    public void ChangeContent(int marknum) {
        switch (marknum) {
            case 0:
                m_text.gameObject.SetActive(true);
                m_image.gameObject.SetActive(false);
                m_text.text = strArr[marknum];
                FadeInOrOut(true);
                break;
            case 1:
                m_text.gameObject.SetActive(true);
                m_image.gameObject.SetActive(false);
                m_text.text = strArr[marknum];
                FadeInOrOut(true);
                break;
            case 2:
                m_text.gameObject.SetActive(false);
                m_image.gameObject.SetActive(true);
                UICollection.SetImage(sprPlayBall, m_image,new Vector3(3,3,1));
                FadeInOrOut(true);
                break;
            case 3:
                m_text.gameObject.SetActive(true);
                m_image.gameObject.SetActive(false);
                m_text.text = strArr[marknum];
                FadeInOrOut(true);
                break;
            case 4:
                m_text.gameObject.SetActive(true);
                m_image.gameObject.SetActive(false);
                m_text.text = strArr[marknum];
                FadeInOrOut(true);
                break;
        }
    }
    public void FadeInOrOut(bool isIn) {
        if (isIn) {
            UICollection.AlphaFade(gameObject, isIn, 0.7f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
