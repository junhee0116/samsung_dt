using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // 이동에 사용할 RigidBody Component
    private Rigidbody playerRigidbody;
    // 이동 속력
    public float speed = 8f;
    // 회전 속도
    float rotationSpeed = 100f;

    void Start() {
        playerRigidbody = GetComponent<Rigidbody>();
    }
    
    void Update() {
        // 수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");     // -1.0 ~ 1.0
        float zInput = Input.GetAxis("Vertical");       // -1.0 ~ 1.0
        // Debug.Log("X input: " + xInput + " " + "Z input: " + zInput);

        // 실제 이동속도를 입력값과 이동 속도를 사용해 결정
        float xSpeed = xInput * speed;      // -8f ~ 8f
        float zSpeed = zInput * speed;      // -8f ~ 8f

        // Vector3 속도를 (xSpeed, 0, zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);
        // Rigidbody에 속도를 적용
        playerRigidbody.velocity = newVelocity; // 속도 = 거리 / 시간

        if(Input.GetKey(KeyCode.Q)) {
            // Vector3(0, 1, 0) up
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.E)) {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // 화살표 위 키
        // if(Input.GetKey(KeyCode.UpArrow)) {
        //     playerRigidbody.AddForce(0f, 0f, speed);    // Z+ 쪽으로 이동
        // }

        // 화살표 아래 키
        // if(Input.GetKey(KeyCode.DownArrow)) {
        //     playerRigidbody.AddForce(0f, 0f, -speed);   // Z- 쪽으로 이동
        // }

        // 화살표 왼쪽 키
        // if(Input.GetKey(KeyCode.LeftArrow)) {
        //     playerRigidbody.AddForce(-speed, 0f, 0f);   // X- 쪽으로 이동
        // }

        // 화살표 오른쪽 키
        // if(Input.GetKey(KeyCode.RightArrow)) {
        //     playerRigidbody.AddForce(speed, 0f, 0f);    // X+ 쪽으로 이동
        // }
    }

    // 충돌시 수행되는 코드
    public void Die() {
        // FindObjectOfType: 씬에 존재하는 GameManger 타입의 오브젝트를 찾아오기
        GameManger gameManger = FindObjectOfType<GameManger>();
        if(gameManger != null) {
            if(gameManger.lifeCount == 1) {
                // GameObject 비활성화
                gameObject.SetActive(false);
                gameManger.EndGame();
            } else {
                gameManger.lifeCount -= 1;
            }
        }

        // gameObject: 예약어, 자기 GameObject
        // transform: 예약어, 자기 Transform Component
        // 나머지 Component들은 모두 다 public link나 GetComponent을 통해 가져온다
        // playerRigidbody = gameObject.GetComponent<Rigidbody>();
        // CapsuleCollider colider = gameObject.GetComponent<CapsuleCollider>();
        // PlayerController script = gameObject.GetComponent<PlayerController>();
    }
}
