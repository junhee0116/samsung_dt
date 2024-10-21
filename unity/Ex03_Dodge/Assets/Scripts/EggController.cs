using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour {
    public float speed = 8f;
    private Rigidbody eggRigidbody;

    void Start() {
        eggRigidbody = GetComponent<Rigidbody>();
        // Rigidbody 속도 설정: 앞쪽 방향(Z+)으로 이동
        eggRigidbody.velocity = transform.forward * speed;
    }

    // 충돌 처리 메소드
    // 일반 물리적 충돌
    void OnCollisionEnter(Collision collision) {
        // Debug.Log("OnCollisionEnter");
    }
    void OnCollisionStay(Collision collision) {
        // Debug.Log("OnCollisionStay");
    }
    void OnCollisionExit(Collision collision) {
        // Debug.Log("OnCollisionExit");
    }

    // 트리거 충돌 처리
    void OnTriggerEnter(Collider other) {
        // 플레이어와 충돌 시
        if(other.tag == "Player") {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if(playerController != null) {
                playerController.Die();  // 플레이어 죽음 처리
            }

            // 총알 소멸
            Destroy(gameObject);
        }

        // 벽과 충돌 시
        if(other.tag == "Wall") {
            Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider other) {
        // Debug.Log("OnTriggerStay");
    }

    void OnTriggerExit(Collider other) {
        // Debug.Log("OnTriggerExit");
    }

    void Update() {
        // 필요시 업데이트 로직 추가
    }
}

// Vector3의 축약된 표현
// Vector3 forward = new Vector3(0f, 0f, 1f);
// Vector3 back = new Vector3(0f, 0f, -1f);
// Vector3 right = new Vector3(1f, 0f, 0f);
// Vector3 left = new Vector3(-1f, 0f, 0f);
// Vector3 up = new Vector3(0f, 1f, 0f);
// Vector3 down = new Vector3(0f, -1f, 0f);