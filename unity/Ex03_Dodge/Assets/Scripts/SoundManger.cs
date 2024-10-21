using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour {
    // ����� Ŭ��(mp3, wav)
    public AudioClip game_start;
    public AudioClip game_end;

    // ����� �ҽ�(component)
    private AudioSource audioSource;

    public void PlaySound(string soundName) {
        audioSource = GetComponent<AudioSource>();
        if(soundName.Equals(game_start)) {
            audioSource.clip = game_start;
        } else if(soundName.Equals(game_end)) {
            audioSource.clip = game_end;
        }
        audioSource.loop = false;   // �ݺ����
        audioSource.Play();         // �������
    }
}
