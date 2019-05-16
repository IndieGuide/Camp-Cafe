using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicBoxControl : MonoBehaviour
{
    public Image discImage;
    public Image needleImage;
    RectTransform discTrans;
    RectTransform needleTrans;
    float discRotZ = 0;
    public float discRotSpd = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        discTrans = discImage.gameObject.GetComponent<RectTransform>();
        needleTrans = needleImage.gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //discRotZ += discRotSpd;
        //discTrans.localEulerAngles = new Vector3(0, 0, discRotZ);
    }
}
