using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalManager : MonoBehaviour {
    static GlobalManager StaticObject;
    public GameObject SettingArea;
    public MenuSetting menuSetting;

    internal void StartGame() {
        SceneManager.LoadScene("GameScene");
    }

    public GameObject ReturnMainButton;
    public Text t;
    private bool LastMusicOn = true;
    public float audioVolumn = 0.8f;

    internal void QuitGame() {
        Application.Quit();
    }

    public float soundVolumn = 0.8f;
    public int screenResType = 0;

    public static GlobalManager instance
    {
        get
        {
            if (StaticObject == null) {
                StaticObject = FindObjectOfType<GlobalManager>();
                try {
                    DontDestroyOnLoad(StaticObject.gameObject);
                }
                catch (Exception e){
                    return null;
                }
            }
            return StaticObject;
        }
    }
    void Awake() {
        if (StaticObject == null) {
            StaticObject = this;
            DontDestroyOnLoad(this);
        } else if (this != StaticObject) {
            Destroy(gameObject);
        }
        //设置初始窗口化
        MenuSetting.ChangeScreenResolution(screenResType);
        SettingArea.SetActive(false);
    }
    private void Update() {
        //t.text = screenResType.ToString();
    }
    internal static void SaveData() {

    }
}