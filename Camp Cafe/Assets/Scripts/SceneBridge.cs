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
        //为了开发便利，使在游戏开始界面创建的globalmanager可以在其他场景直接创建，不安全，应在正式版本删除
        if(GameObject.Find("GlobalManager") == null) {
            Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
        }

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

}
