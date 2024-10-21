using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    public float speed = 4f;
    private Rigidbody bulletRigidbody;

    void Start() {
        bulletRigidbody = GetComponent<Rigidbody>();
        // Rigidbody �ӵ� ����: ���� ����(Z+)���� �̵�
        bulletRigidbody.velocity = transform.forward * speed;
    }


    // Ʈ���� �浹 ó��
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
        // �ʿ�� ������Ʈ ���� �߰�
    }
}
