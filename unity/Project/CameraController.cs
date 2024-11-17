using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float rotateSpeed = 2f;   // ī�޶� ȸ�� �ӵ�
    private float xRotation = 0f;    // X�� ȸ�� �� (����)
    private float yRotation = 0f;    // Y�� ȸ�� �� (�¿�)

    public Transform playerBody;     // �÷��̾� ��ü (ī�޶� ���� ȸ���� �÷��̾�)

    // Start is called before the first frame update
    void Start() {
        // ���콺 Ŀ���� ȭ�� �߾ӿ� �����ϰ� ����
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {
        // ���콺 X, Y �̵����� �޾ƿ�
        float mouseMoveX = Input.GetAxis("Mouse X") * rotateSpeed; // ���콺 X�� (�¿�)
        float mouseMoveY = Input.GetAxis("Mouse Y") * rotateSpeed; // ���콺 Y�� (����)

        // ���콺 Y������ ���� ȸ�� (xRotation)
        xRotation -= mouseMoveY; // ���콺 Y �̵� ������ ���� ȸ�� ����
        xRotation = Mathf.Clamp(xRotation, -30f, 30f); // -30�� ~ 30�� ����

        // ���콺 X������ �¿� ȸ�� (yRotation)
        yRotation += mouseMoveX; // ���콺 X �̵� ������ �¿� ȸ�� ����

        // ȸ�� ���� �����Ǹ� ��� �������� �ʵ��� ��
        yRotation = Mathf.Repeat(yRotation, 360f); // 360���� ���� �ʵ��� ����

        // ī�޶� ȸ�� ���� (���� ȸ���� ī�޶� ��ü)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // ���� ȸ�� (ī�޶�)

        // �÷��̾� ��ü ȸ�� (�¿� ȸ��)
        playerBody.rotation = Quaternion.Euler(0f, yRotation, 0f); // �¿� ȸ�� (�÷��̾� ��ü)
    }
}
