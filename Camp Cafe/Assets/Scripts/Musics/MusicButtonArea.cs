using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButtonArea : MonoBehaviour
{
    public Image pauseImg;
    public Sprite pauseSpr;
    public Sprite playSpr;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void LastButtonOnClick() {

    }
    public void PauseButtonOnClick() {
        Sprite spr;
        if (pauseImg.sprite == pauseSpr) {
            spr = playSpr;
        } else {
            spr = pauseSpr;
        }
        UICollection.SetImage(spr,pauseImg);
    }
    public void NextButtonOnClick() {

    }
}
