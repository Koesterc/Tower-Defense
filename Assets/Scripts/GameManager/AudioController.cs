using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour {

    [HideInInspector]
    public AudioSource audioSource;
    [SerializeField]
    AudioClip audioClip;
    static int playing = 0;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    public void Play()
    {
        if (playing >= 35)
            return;
        audioSource.PlayOneShot(audioClip, 1);
        playing++;
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(audioClip.length);
        playing--;
    }
}
