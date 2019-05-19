using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CdManager : MonoBehaviour {
    List<CdBoxControl> cdControls = new List<CdBoxControl>();
    RectTransform m_rect;
    List<RectTransform> cdRects = new List<RectTransform>();
    // Start is called before the first frame update
    void Start() {
        m_rect = gameObject.GetComponent<RectTransform>();
        //初始化专辑
        foreach (CdData.SoundTrack track in CdData.instance.trackList) {
            GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/CdBoxPrefab"), gameObject.transform);
            obj.GetComponent<CdBoxControl>().SetTrack(track.trackId);
            obj.GetComponent<CdBoxControl>().siblingIndex = obj.transform.GetSiblingIndex();
            cdControls.Add(obj.GetComponent<CdBoxControl>());
            cdRects.Add(obj.GetComponent<RectTransform>());
        }
        SetTracksPos();
    }

    internal void SetTracksPos() {
        float top = m_rect.rect.yMin;
        float bottom = m_rect.rect.yMax;
        float height = m_rect.rect.height;
        float heightFix = height - 200;

        int i = 0;
        float heightAdd = heightFix / (cdControls.Count - 1);
        float yStart = heightFix / 2;
        Debug.Log(heightAdd);
        foreach (RectTransform rect in cdRects) {
            //UICollection.MoveToPos(rect.gameObject, new Vector3(rect.localPosition.x, yStart - i * heightAdd, rect.localPosition.z), 0.2f);
            rect.localPosition = new Vector3(rect.localPosition.x, yStart - i * heightAdd, rect.localPosition.z);
            //Debug.Log("设置坐标");
            i++;
        }
    }
    // Update is called once per frame
    void Update() {

    }
}
