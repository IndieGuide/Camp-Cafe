using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayerControl : MonoBehaviour {
    public static MusicPlayerControl instance;
    internal AudioSource audioSource;
    private bool isPlaying = true;
    public List<AudioClip> musicList;
    internal CdData.SoundTrack track;
    private int musicIndex = 0;
    public MusicControlButton pauseBtn;
    public Sprite pauseEnterSpr;
    public Sprite pauseUpSpr;
    public Sprite pauseDownSpr;
    public Sprite playEnterSpr;
    public Sprite playUpSpr;
    public Sprite playDownSpr;

    public Image discImage;
    public float needleRot = 5.0f;
    public Image needleImage;
    public Text musicNameText;

    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start() {
        
        //初始化播放器及唱片机
        audioSource = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();
        if (audioSource.isPlaying) {
            ChangeToPauseSpr();
            DiscStartRotating();
        } else {
            ChangeToPlaySpr();
        }
        
    }

    public void ClickPauseButton() {
        isPlaying = !isPlaying;
        if (isPlaying) {
            audioSource.Play();
            NeedleIn(needleRot);
            DiscStartRotating();
            ChangeToPauseSpr();
        } else {
            audioSource.Pause();
            NeedleOut();
            DiscStopRotating();
            ChangeToPlaySpr();

        }
    }

    private void ChangeToPlaySpr() {
        pauseBtn.enterSpr = playEnterSpr;
        pauseBtn.upSpr = playUpSpr;
        pauseBtn.downSpr = playDownSpr;
    }

    private void ChangeToPauseSpr() {
        pauseBtn.enterSpr = pauseEnterSpr;
        pauseBtn.upSpr = pauseUpSpr;
        pauseBtn.downSpr = pauseDownSpr;
    }

    public void ClickLastButton() {
        if (musicIndex > 0) {
            audioSource.clip = musicList[--musicIndex];
            audioSource.Play();
            musicNameText.text = audioSource.clip.name;
        } else {
            musicIndex = musicList.Count - 1;
            audioSource.clip = musicList[musicIndex];
            audioSource.Play();
            musicNameText.text = audioSource.clip.name;
        }
        if (needleRot > 0f) {
            needleRot -= 1.0f;
        }
        NeedleIn(needleRot);
        ChangeToPauseSpr();
        DiscStartRotating();
    }
    public void ClickNextButton() {
        if (musicIndex < musicList.Count - 1) {
            audioSource.clip = musicList[++musicIndex];
            audioSource.Play();
            musicNameText.text = audioSource.clip.name;
        } else {
            musicIndex = 0;
            audioSource.clip = musicList[musicIndex];
            audioSource.Play();
            musicNameText.text = audioSource.clip.name;
        }
        if (needleRot < 5f) {
            needleRot += 1.0f;
        }
        NeedleIn(needleRot);
        ChangeToPauseSpr();
        DiscStartRotating();

    }

    public void ChangeDisc(CdBoxControl control) {
        //切换歌曲列表
        track = control.track;
        musicList.Clear();
        foreach (CdData.OneMusic music in track.musicList) {
            AudioClip clip = Resources.Load<AudioClip>("Musics/"+music.musicName);
            musicList.Add(clip);
        }

        Image cdSmallImage = control.cdSmallImage;
        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() => {
            UICollection.MoveToPos(cdSmallImage.gameObject, control.MoveTargetPos, 0.2f);
        }, 0.0f));
        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() => {
            UICollection.AlphaFadeImg(cdSmallImage.gameObject, false);
        }, 0.2f));
        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() => {

            NeedleOut();
            UICollection.AlphaFadeImg(discImage.gameObject, false);
            DiscStopRotating();
        }, 1f));
        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() => {
            NeedleIn(5.0f);
            UICollection.SetImage(control.cdSmallImage.sprite, discImage);
            UICollection.AlphaFadeImg(discImage.gameObject, true);
            control.isChanging = false;
            control.isSelected = true;
        }, 2f));
        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() => {
            DiscStartRotating();
            audioSource.Play();
            musicNameText.text = audioSource.clip.name;
            ChangeToPauseSpr();
            UICollection.SetImage(pauseBtn.upSpr, pauseBtn.gameObject.GetComponent<Image>());
        }, 2.5f));

    }

    private void NeedleIn(float targetrot) {
        float targetRot = targetrot;
        UICollection.SetRotateTo(needleImage.gameObject, 0.2f, targetRot);
    }

    private void NeedleOut() {
        float targetRot = 15.0f;
        UICollection.SetRotateTo(needleImage.gameObject, 0.2f, targetRot);
    }

    private void DiscStartRotating() {
        UICollection.SetRotateStart(discImage.gameObject, 15.0f, true, true);
    }

    private void DiscStopRotating() {
        UICollection.SetRotateStop(discImage.gameObject, true);
    }
}
