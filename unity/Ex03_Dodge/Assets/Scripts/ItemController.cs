using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        Debug.Log("OnTriggerEnter");
        if(other.tag == "Player") {
            GameManger gameManger = FindObjectOfType<GameManger>();
            if(gameManger != null) {
                gameManger.lifeCount += 1;
            }

            // ������ �Ҹ�
            Destroy(gameObject, 0);
        }
    }

    void Update() {
       
    }
}
