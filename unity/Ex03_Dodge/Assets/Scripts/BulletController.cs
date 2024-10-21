using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    public float speed = 4f;
    private Rigidbody bulletRigidbody;

    void Start() {
        bulletRigidbody = GetComponent<Rigidbody>();
        // Rigidbody 속도 설정: 앞쪽 방향(Z+)으로 이동
        bulletRigidbody.velocity = transform.forward * speed;
    }


    // 트리거 충돌 처리
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Wall") {
            Destroy(gameObject);
        }
        if(other.tag == "Enemy") {
            //EnemyController enemyController = other.GetComponent<EnemyController>();

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
