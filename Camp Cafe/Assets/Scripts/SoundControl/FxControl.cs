using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxControl : MonoBehaviour {
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Awake() {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (GlobalManager.instance != null) {
            audioSource.volume = GlobalManager.instance.soundVolumn;
        } else {
            audioSource.volume = 0.8f;
        }
    }
    internal void SetAudioClip(AudioClip audioclip) {
        audioSource.clip = audioclip;
        audioSource.Play();
    }
    // Update is called once per frame
    void Update() {
        if (!audioSource.isPlaying) {
            Destroy(gameObject);
        }
    }
}
