using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move1 : MonoBehaviour {
    void Start() {
        // transform: �ڽ��� transform ���۳�Ʈ
        // gameObject: �ڽ��� GameObject ��ü
        Debug.Log("transform: " + transform.position);      // (0, 4, 0)

        // transform.position = new Vector3(10, 4, 0);         // X ��ǥ 10���� �̵�
    }

    void Update() {
        // �������� �̵�
        // Time.deltaTime: FPS�� �� �������� �ð�
        //               : 30 fps�̸� 0.033ms
        //               : 60 fps�̸� 0.016ms
        // ���Ӹ��� Frame Rate�� �ٸ����� ������ ��ġ��ŭ ���� �� ���� �ִ�
        //transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime);         // direction * magnitude
        
        // eulers �� ȸ��: �ѹ��� �� �࿡ ���ؼ��� ȸ�� ���� 
        //transform.Rotate(new Vector3(10, 0, 0) * Time.deltaTime);
        // ���� ������ �Ͻÿ� ȸ���Ϸ��� Vector4�� ����ؾ��Ѵ�
        // ������ ���� �߻�

        // ���ʹϾ� �� ȸ��
        // Quaternion: ���Ϸ� ��(3����)�� ���ʹϾ� ��(4����)���� ��ȯ �Լ�
        //transform.rotation = Quaternion.Euler(45 * Time.deltaTime, 45 * Time.deltaTime, 0) * transform.rotation;

        // Ű���� �Է¿� ���� GameObject �̵�
        if(Input.GetKey(KeyCode.LeftArrow)) {
            transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.RightArrow)) {
            transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.UpArrow)) {
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime);
            // z�� �߽����� 1�ʿ� 180�� ȸ��
            transform.Rotate(new Vector3(0, 0, 180) * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.DownArrow)) {
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime);
        }
    }
}
