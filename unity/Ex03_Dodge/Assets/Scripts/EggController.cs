using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour {
    public float speed = 8f;
    private Rigidbody eggRigidbody;

    void Start() {
        eggRigidbody = GetComponent<Rigidbody>();
        // Rigidbody �ӵ� ����: ���� ����(Z+)���� �̵�
        eggRigidbody.velocity = transform.forward * speed;
    }

    // �浹 ó�� �޼ҵ�
    // �Ϲ� ������ �浹
    void OnCollisionEnter(Collision collision) {
        // Debug.Log("OnCollisionEnter");
    }
    void OnCollisionStay(Collision collision) {
        // Debug.Log("OnCollisionStay");
    }
    void OnCollisionExit(Collision collision) {
        // Debug.Log("OnCollisionExit");
    }

    // Ʈ���� �浹 ó��
    void OnTriggerEnter(Collider other) {
        // �÷��̾�� �浹 ��
        if(other.tag == "Player") {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if(playerController != null) {
                playerController.Die();  // �÷��̾� ���� ó��
            }

            // �Ѿ� �Ҹ�
            Destroy(gameObject);
        }

        // ���� �浹 ��
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
        // �ʿ�� ������Ʈ ���� �߰�
    }
}

// Vector3�� ���� ǥ��
// Vector3 forward = new Vector3(0f, 0f, 1f);
// Vector3 back = new Vector3(0f, 0f, -1f);
// Vector3 right = new Vector3(1f, 0f, 0f);
// Vector3 left = new Vector3(-1f, 0f, 0f);
// Vector3 up = new Vector3(0f, 1f, 0f);
// Vector3 down = new Vector3(0f, -1f, 0f);