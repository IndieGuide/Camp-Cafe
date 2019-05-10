using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtonControl : MonoBehaviour
{
    public void StartGameClick(BaseEventData e) {
        FxCollection.PlayButtonClickFx();
        GlobalManager.instance.StartGame();
        
    }
    public void SettingClick(BaseEventData e) {
        FxCollection.PlayButtonClickFx();
        GlobalManager.instance.SettingArea.SetActive(true);
    }
    public void QuitClick(BaseEventData e) {
        FxCollection.PlayButtonClickFx();
        GlobalManager.instance.QuitGame();
    }
    public void CreatorClick(BaseEventData e) {
        FxCollection.PlayButtonClickFx();

    }
    public void LoadClick(BaseEventData e) {
        FxCollection.PlayButtonClickFx();

    }
}
