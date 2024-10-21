using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGManger : MonoBehaviour{
    // 오디오 클립(mp3, wav)
    public AudioClip backgroundMusic;

    // 오디오 소스(component)
    private AudioSource audioSource;
    
    void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;   // 반복재생
        audioSource.Play();        // 재생시작
    }
}
