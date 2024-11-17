using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float rotateSpeed = 2f;   // 카메라 회전 속도
    private float xRotation = 0f;    // X축 회전 값 (상하)
    private float yRotation = 0f;    // Y축 회전 값 (좌우)

    public Transform playerBody;     // 플레이어 몸체 (카메라가 따라 회전할 플레이어)

    // Start is called before the first frame update
    void Start() {
        // 마우스 커서를 화면 중앙에 고정하고 숨김
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {
        // 마우스 X, Y 이동값을 받아옴
        float mouseMoveX = Input.GetAxis("Mouse X") * rotateSpeed; // 마우스 X축 (좌우)
        float mouseMoveY = Input.GetAxis("Mouse Y") * rotateSpeed; // 마우스 Y축 (상하)

        // 마우스 Y축으로 상하 회전 (xRotation)
        xRotation -= mouseMoveY; // 마우스 Y 이동 값으로 상하 회전 적용
        xRotation = Mathf.Clamp(xRotation, -30f, 30f); // -30도 ~ 30도 제한

        // 마우스 X축으로 좌우 회전 (yRotation)
        yRotation += mouseMoveX; // 마우스 X 이동 값으로 좌우 회전 적용

        // 회전 값이 누적되며 계속 증가하지 않도록 함
        yRotation = Mathf.Repeat(yRotation, 360f); // 360도를 넘지 않도록 제한

        // 카메라 회전 적용 (상하 회전은 카메라 자체)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // 상하 회전 (카메라)

        // 플레이어 몸체 회전 (좌우 회전)
        playerBody.rotation = Quaternion.Euler(0f, yRotation, 0f); // 좌우 회전 (플레이어 몸체)
    }
}
