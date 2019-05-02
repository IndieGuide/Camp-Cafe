using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICollection : MonoBehaviour
{
    public static void SetImage(string imagePath,Image targetImage) {
        Sprite spr = Resources.Load<Sprite>(imagePath);
        targetImage.sprite = spr;
        RectTransform imgRecTrans = targetImage.transform.GetComponent<RectTransform>();
        imgRecTrans.sizeDelta = new Vector2(targetImage.sprite.bounds.size.x * 100, targetImage.sprite.bounds.size.y * 100);
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
