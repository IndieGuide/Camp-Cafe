using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxCollection : MonoBehaviour
{
    internal static AudioClip m_fx_text = Resources.Load<AudioClip>("SoundsFx/textEfect");
    internal static AudioClip m_fx_text_over = Resources.Load<AudioClip>("SoundsFx/textOverEffect");
    internal static AudioClip m_fx_click = Resources.Load<AudioClip>("SoundsFx/ClickFx");
    internal static AudioClip m_fx_low = Resources.Load<AudioClip>("SoundsFx/一个低音");

    internal static void PlayButtonClickFx(float v) {
        GameObject fxObj = Instantiate(Resources.Load<GameObject>("Prefabs/SoundFxPrefab"));
        FxControl controller = fxObj.GetComponent<FxControl>();
        controller.SetAudioClip(m_fx_click);
        controller.audioSource.volume = v;
        Debug.Log("增加音效");
    }

    internal static AudioClip m_fx_low_to_high = Resources.Load<AudioClip>("SoundsFx/低到高按键音效");
    internal static AudioClip m_fx_high_to_low = Resources.Load<AudioClip>("SoundsFx/高到低按键音效");

  
    internal static void PlayTextFx() {
        GameObject fxObj = Instantiate(Resources.Load<GameObject>("Prefabs/SoundFxPrefab"));
        FxControl controller = fxObj.GetComponent<FxControl>();
        controller.SetAudioClip(m_fx_text);
        Debug.Log("增加音效");
    }  
    internal static void PlayTextOverFx() {
        GameObject fxObj = Instantiate(Resources.Load<GameObject>("Prefabs/SoundFxPrefab"));
        FxControl controller = fxObj.GetComponent<FxControl>();
        controller.SetAudioClip(m_fx_text_over);
        Debug.Log("增加音效");
    }  
    internal static void PlayButtonEnterFx() {
        GameObject fxObj = Instantiate(Resources.Load<GameObject>("Prefabs/SoundFxPrefab"));
        FxControl controller = fxObj.GetComponent<FxControl>();
        controller.SetAudioClip(m_fx_low_to_high);
        Debug.Log("增加音效");
    }
    internal static void PlayButtonUpFx() {
        GameObject fxObj = Instantiate(Resources.Load<GameObject>("Prefabs/SoundFxPrefab"));
        FxControl controller = fxObj.GetComponent<FxControl>();
        controller.SetAudioClip(m_fx_high_to_low);
        Debug.Log("增加音效");
    }
    internal static void PlayButtonClickFx() {
        GameObject fxObj = Instantiate(Resources.Load<GameObject>("Prefabs/SoundFxPrefab"));
        FxControl controller = fxObj.GetComponent<FxControl>();
        controller.SetAudioClip(m_fx_click);
        Debug.Log("增加音效");
    }
    internal static void PlayLowFx() {
        GameObject fxObj = Instantiate(Resources.Load<GameObject>("Prefabs/SoundFxPrefab"));
        FxControl controller = fxObj.GetComponent<FxControl>();
        controller.SetAudioClip(m_fx_low);
        Debug.Log("增加音效");
    }


}
