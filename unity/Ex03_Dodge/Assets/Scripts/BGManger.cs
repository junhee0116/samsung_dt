using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGManger : MonoBehaviour{
    // ����� Ŭ��(mp3, wav)
    public AudioClip backgroundMusic;

    // ����� �ҽ�(component)
    private AudioSource audioSource;
    
    void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;   // �ݺ����
        audioSource.Play();        // �������
    }
}
