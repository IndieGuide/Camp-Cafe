﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtonControl : MonoBehaviour
{
    public void StartGameClick(BaseEventData e) {
        SceneManager.LoadScene("GameScene");
        
    }
    public void SettingClick(BaseEventData e) {
        GlobalManager.instance.SettingArea.SetActive(true);
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
