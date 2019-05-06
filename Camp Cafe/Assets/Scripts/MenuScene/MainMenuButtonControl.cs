using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtonControl : MonoBehaviour
{
    public void StartGameClick(BaseEventData e) {
        GlobalManager.instance.StartGame();
        
    }
    public void SettingClick(BaseEventData e) {
        GlobalManager.instance.SettingArea.SetActive(true);
    }
    public void QuitClick(BaseEventData e) {
        GlobalManager.instance.QuitGame();
    }
    public void CreatorClick(BaseEventData e) {
        
    }
    public void LoadClick(BaseEventData e) {

    }
}
