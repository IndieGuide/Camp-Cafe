using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CdData : MonoBehaviour
{
    internal static CdData instance;
    internal List<OneMusic> musicList = new List<OneMusic>();
    internal List<SoundTrack> trackList = new List<SoundTrack>();
    private void Awake() {
        instance = this;

        List<string[]> trackDataList = InstanceLoad.GetInstanceData("Texts/TrackData");
        foreach (string[] insDataArr in trackDataList) {
            SoundTrack oneTrack = new SoundTrack(int.Parse(insDataArr[0]), insDataArr[1], insDataArr[2], insDataArr[3]);
            trackList.Add(oneTrack);
        }
        List<string[]> musicDataList = InstanceLoad.GetInstanceData("Texts/MusicData");
        foreach (string[] insDataArr in musicDataList) {
            OneMusic oneMusic = new OneMusic(int.Parse(insDataArr[0]), int.Parse(insDataArr[1]), insDataArr[2], insDataArr[3], insDataArr[4]);
            musicList.Add(oneMusic);
            trackList[oneMusic.trackId].musicList.Add(oneMusic);
        }
    }
    internal class OneMusic {
        public int musicId;
        public string musicName;
        public string musicInfo;
        public string musicAuthor;
        public int trackId;
        public OneMusic(int musicId, int trackId,string musicName, string musicInfo, string musicAuthor) {
            this.musicId = musicId;
            this.musicName = musicName;
            this.musicInfo = musicInfo;
            this.musicAuthor = musicAuthor;
            this.trackId = trackId;
        }
    }
    internal class SoundTrack {
        public int trackId;
        public string trackName;
        public List<OneMusic> musicList = new List<OneMusic>();
        public string trackInfo;
        public string trackAuthor;
        public SoundTrack(int trackId, string trackName, string trackInfo, string trackAuthor) {
            this.trackId = trackId;
            this.trackName = trackName;
            this.trackInfo = trackInfo;
            this.trackAuthor = trackAuthor;
        }

    }


}
