using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // �̵��� ����� RigidBody Component
    private Rigidbody playerRigidbody;
    // �̵� �ӷ�
    public float speed = 8f;
    // ȸ�� �ӵ�
    float rotationSpeed = 100f;

    void Start() {
        playerRigidbody = GetComponent<Rigidbody>();
    }
    
    void Update() {
        // ������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");     // -1.0 ~ 1.0
        float zInput = Input.GetAxis("Vertical");       // -1.0 ~ 1.0
        // Debug.Log("X input: " + xInput + " " + "Z input: " + zInput);

        // ���� �̵��ӵ��� �Է°��� �̵� �ӵ��� ����� ����
        float xSpeed = xInput * speed;      // -8f ~ 8f
        float zSpeed = zInput * speed;      // -8f ~ 8f

        // Vector3 �ӵ��� (xSpeed, 0, zSpeed)�� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);
        // Rigidbody�� �ӵ��� ����
        playerRigidbody.velocity = newVelocity; // �ӵ� = �Ÿ� / �ð�

        if(Input.GetKey(KeyCode.Q)) {
            // Vector3(0, 1, 0) up
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.E)) {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // ȭ��ǥ �� Ű
        // if(Input.GetKey(KeyCode.UpArrow)) {
        //     playerRigidbody.AddForce(0f, 0f, speed);    // Z+ ������ �̵�
        // }

        // ȭ��ǥ �Ʒ� Ű
        // if(Input.GetKey(KeyCode.DownArrow)) {
        //     playerRigidbody.AddForce(0f, 0f, -speed);   // Z- ������ �̵�
        // }

        // ȭ��ǥ ���� Ű
        // if(Input.GetKey(KeyCode.LeftArrow)) {
        //     playerRigidbody.AddForce(-speed, 0f, 0f);   // X- ������ �̵�
        // }

        // ȭ��ǥ ������ Ű
        // if(Input.GetKey(KeyCode.RightArrow)) {
        //     playerRigidbody.AddForce(speed, 0f, 0f);    // X+ ������ �̵�
        // }
    }

    // �浹�� ����Ǵ� �ڵ�
    public void Die() {
        // FindObjectOfType: ���� �����ϴ� GameManger Ÿ���� ������Ʈ�� ã�ƿ���
        GameManger gameManger = FindObjectOfType<GameManger>();
        if(gameManger != null) {
            if(gameManger.lifeCount == 1) {
                // GameObject ��Ȱ��ȭ
                gameObject.SetActive(false);
                gameManger.EndGame();
            } else {
                gameManger.lifeCount -= 1;
            }
        }

        // gameObject: �����, �ڱ� GameObject
        // transform: �����, �ڱ� Transform Component
        // ������ Component���� ��� �� public link�� GetComponent�� ���� �����´�
        // playerRigidbody = gameObject.GetComponent<Rigidbody>();
        // CapsuleCollider colider = gameObject.GetComponent<CapsuleCollider>();
        // PlayerController script = gameObject.GetComponent<PlayerController>();
    }
}
