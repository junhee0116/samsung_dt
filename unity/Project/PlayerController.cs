using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 5f;  // �÷��̾� �̵� �ӵ�
    public float jumpForce = 3f;  // ���� ��

    private Rigidbody rb;         // �÷��̾��� Rigidbody ������Ʈ
    private float moveDirectionX; // X ���� (����)
    private float moveDirectionZ; // Z ���� (����)

    private bool isGrounded;      // �ٴڿ� �ִ��� Ȯ��

    private Animator animator;    // Animator ������Ʈ ����
    private readonly int hashIsWalking = Animator.StringToHash("IsWalking");
    private readonly int hashWalk = Animator.StringToHash("IsWalking");

    private float hp = 100.0f;
    private TMP_Text hpBar;



    void Start() {
        rb = GetComponent<Rigidbody>();  // Rigidbody ������Ʈ ���
        animator = GetComponent<Animator>(); // Animator ������Ʈ ���

        hpBar = GameObject.FindGameObjectWithTag("HPBAR")?.GetComponent<TMP_Text>();

        UpdateHP();
    }

    void Update() {
        // �̵� �Է�
        moveDirectionX = Input.GetAxis("Horizontal");  // A, D Ű (�¿� �̵�)
        moveDirectionZ = Input.GetAxis("Vertical");    // W, S Ű (�յ� �̵�)

        // ����
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            Jump();
        }

        // �̵� ó��
        MovePlayer();

        // �ִϸ��̼� ���� ������Ʈ
        UpdateAnimationState();
    }

    void MovePlayer() {
        Vector3 moveDirection = transform.TransformDirection(moveDirectionX, 0, moveDirectionZ);
        moveDirection.Normalize(); // ����ȭ

        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
    }

    void Jump() {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void UpdateAnimationState() {
        // �������� �ִ��� Ȯ��
        if(moveDirectionX != 0 || moveDirectionZ != 0) {
            // Animator�� �� ����
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

    // �ٴ� üũ
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
