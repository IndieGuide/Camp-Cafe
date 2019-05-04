using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSetting : MonoBehaviour {
    public Slider m_audio_slider;
    public Slider m_sound_slider;
    public AudioSource musicSource;
    public Text screenResText;
    int screenResType;

    public string[] screenResStrArr = new string[]{"窗口", "全屏幕", "1280x720", "1920x1080"};
    private void OnEnable() {
        m_audio_slider.value = GlobalManager.instance.audioVolumn;
        m_sound_slider.value = GlobalManager.instance.soundVolumn;
        screenResType = GlobalManager.instance.screenResType;
        screenResText.text = screenResStrArr[screenResType];

        UICollection.JumpBorder(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ReturnOnClick() {
        gameObject.SetActive(false);
    }
    public void ReturnMainOnClick() {
        GlobalManager.SaveData();
        SceneManager.LoadScene("MenuScene");
    }
    public void AudioSliderChange() {
        float volume = m_audio_slider.value;
        GlobalManager.instance.audioVolumn = volume;
        musicSource.volume = volume;
    }
    public void SoundSliderChange() {
        float volume = m_sound_slider.value;
        GlobalManager.instance.soundVolumn = volume;
    }
    public void CanvasLeftButton() {
        if (screenResType != 0) {
            screenResType -= 1;
        } else {
            screenResType = 3;
        }
        screenResText.text = screenResStrArr[screenResType];
    }
    public void CanvasRightButton() {
        if (screenResType != 3) {
            screenResType += 1;
        } else {
            screenResType = 0;
        }
        screenResText.text = screenResStrArr[screenResType];
    }
    public void ChangeScreenOnClick() {
        GlobalManager.instance.screenResType = screenResType;
        ChangeScreenResolution(GlobalManager.instance.screenResType);
    }
    public static void ChangeScreenResolution(int screenrestype) {
        //获取设置当前屏幕分辩率  
        Resolution[] resolutions = Screen.resolutions;
        switch (screenrestype) {
            case 0:
                //设置当前分辨率  
                Screen.SetResolution(resolutions[resolutions.Length - 1].width, resolutions[resolutions.Length - 1].height, false);
                break;
            case 1:
                //设置当前分辨率  
                Screen.SetResolution(resolutions[resolutions.Length - 1].width, resolutions[resolutions.Length - 1].height, true);
                Screen.fullScreen = true;  //设置成全屏,  
                break;
            case 2:
                Screen.SetResolution(1280, 720, false);
                break;
            case 3:
                Screen.SetResolution(1920, 1080, false);
                break;
            default:
                Screen.SetResolution(resolutions[resolutions.Length - 1].width, resolutions[resolutions.Length - 1].height, false);
                break;
        }
    }
}
