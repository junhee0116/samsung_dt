using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 5f;  // 플레이어 이동 속도
    public float jumpForce = 3f;  // 점프 힘

    private Rigidbody rb;         // 플레이어의 Rigidbody 컴포넌트
    private float moveDirectionX; // X 방향 (수평)
    private float moveDirectionZ; // Z 방향 (수직)

    private bool isGrounded;      // 바닥에 있는지 확인

    private Animator animator;    // Animator 컴포넌트 참조
    private readonly int hashIsWalking = Animator.StringToHash("IsWalking");
    private readonly int hashWalk = Animator.StringToHash("IsWalking");

    private float hp = 100.0f;
    private TMP_Text hpBar;



    void Start() {
        rb = GetComponent<Rigidbody>();  // Rigidbody 컴포넌트 얻기
        animator = GetComponent<Animator>(); // Animator 컴포넌트 얻기

        hpBar = GameObject.FindGameObjectWithTag("HPBAR")?.GetComponent<TMP_Text>();

        UpdateHP();
    }

    void Update() {
        // 이동 입력
        moveDirectionX = Input.GetAxis("Horizontal");  // A, D 키 (좌우 이동)
        moveDirectionZ = Input.GetAxis("Vertical");    // W, S 키 (앞뒤 이동)

        // 점프
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            Jump();
        }

        // 이동 처리
        MovePlayer();

        // 애니메이션 상태 업데이트
        UpdateAnimationState();
    }

    void MovePlayer() {
        Vector3 moveDirection = transform.TransformDirection(moveDirectionX, 0, moveDirectionZ);
        moveDirection.Normalize(); // 정규화

        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
    }

    void Jump() {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void UpdateAnimationState() {
        // 움직임이 있는지 확인
        if(moveDirectionX != 0 || moveDirectionZ != 0) {
            // Animator에 값 전달
            animator.SetBool(hashIsWalking, true);
        } else {
            animator.SetBool(hashIsWalking, false);
        }
    }

    public void Damage() {
        hp -= 10;
        if(hp == 0) {
            Die();
        }
        UpdateHP();
    }


    private void UpdateHP() {
        hpBar.text = "HP:" + hp.ToString();
    }

    private void Die() {
        Debug.Log("Player has died!");
    }

    // 바닥 체크
    private void OnCollisionStay(Collision collision) {
        if(collision.gameObject.CompareTag("GROUND")) {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision) {
        if(collision.gameObject.CompareTag("GROUND")) {
            isGrounded = false;
        }
    }
}
