using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBridge : MonoBehaviour
{
    public AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene") {
            MenuSetting menuSetting = GlobalManager.instance.menuSetting;
            menuSetting.musicSource = musicSource;

            GameObject returnMainButton = GlobalManager.instance.ReturnMainButton;
            returnMainButton.SetActive(true);

            GlobalManager.instance.SettingArea.SetActive(false);

            MenuSetting.ChangeScreenResolution(GlobalManager.instance.screenResType);
        } else if(SceneManager.GetActiveScene().name == "MenuScene") {
            MenuSetting menuSetting = GlobalManager.instance.menuSetting;
            menuSetting.musicSource = musicSource;

            GameObject returnMainButton = GlobalManager.instance.ReturnMainButton;
            returnMainButton.SetActive(false);
            GlobalManager.instance.SettingArea.SetActive(false);

            MenuSetting.ChangeScreenResolution(GlobalManager.instance.screenResType);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
