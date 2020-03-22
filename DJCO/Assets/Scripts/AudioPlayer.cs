using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class AudioPlayer : MonoBehaviour
{
    public AudioClip firstMusic;
    public AudioClip loopMusic;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playClips()); 
    }

    IEnumerator playClips()
    {
        GetComponent<AudioSource>().clip = firstMusic;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(firstMusic.length);
        GetComponent<AudioSource>().clip = loopMusic;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = true;
    }
}
