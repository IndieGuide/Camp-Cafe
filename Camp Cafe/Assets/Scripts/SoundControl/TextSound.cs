using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSound : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        try {
            audioSource.volume = GlobalManager.instance.soundVolumn;
        }
        catch {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying) {
            Destroy(gameObject);
        }
    }
}
