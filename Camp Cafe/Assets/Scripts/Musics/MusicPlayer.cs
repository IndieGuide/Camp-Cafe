using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;
    private bool isPlaying = true;
    public List<AudioClip> musicList;
    private int musicIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void ClickPauseButton() {
        isPlaying = !isPlaying;
        if (isPlaying) {
            audioSource.Play();
        } else {
            audioSource.Pause();
        }
    }
    public void ClickLastButton() {
        if (musicIndex > 0) {
            audioSource.clip = musicList[--musicIndex];
            audioSource.Play();
        } else {
            musicIndex = musicList.Count - 1;
            audioSource.clip = musicList[musicIndex];
            audioSource.Play();
        }
    }
    public void ClickNextButton() {
        if (musicIndex < musicList.Count - 1) {
            audioSource.clip = musicList[++musicIndex];
            audioSource.Play();
        } else {
            musicIndex = 0;
            audioSource.clip = musicList[musicIndex];
            audioSource.Play();
        }
    }
}
