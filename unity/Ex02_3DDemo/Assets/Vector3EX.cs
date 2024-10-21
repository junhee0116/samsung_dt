    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Vector3EX : MonoBehaviour {
        void Start() {
            // ����(Vector): ũ��� ������ ���� �������� ����
            // ����Ƽ���� �����ϴ� ���͵�

            Vector2 v2 = new Vector2(10, 20);           // x,y ��ǥ�� 2���� ����
            Vector3 v3 = new Vector3(10, 20, 30);       // x, y, z ��ǥ�� 3���� ����
            Vector4 v4 = new Vector4(10, 20, 30, 40);   // x, y, z, w ��ǥ�� 4���� ����

            // 1. ������ ��
            Vector3 a = new Vector3(3, 6, 9);
            a = a * 10;     // (30, 60, 90)
            Debug.Log("������ ��: " + a);

            // 2. ������ ������ ����
            Vector3 b = new Vector3(2, 4, 8);
            Vector3 c = new Vector3(3, 6, 9);
            Debug.Log("������ ����: " + (b + c));    // (5, 10, 17)
            Debug.Log("������ ����: " + (b - c));    // (-1, -2, -1)

            // 3. ������ ����ȭ (Normal Vector): ���̰� 1�� ����
            //    ���⼺�� ���� ���͸� ���� �� ���
            Vector3 d = new Vector3(3, 3, 3);
            Debug.Log("������ ����ȭ: " + d.normalized);

            // 4. ������ ũ��(����)
            Debug.Log("������ ũ��: " + d.magnitude);

            // 5. ������ ����: �� ���� ������ ������ ���� ��
            Vector3 a2 = new Vector3(0, 1, 0);
            Vector3 b2 = new Vector3(1, 0, 0);
            float c2 = Vector3.Dot(a2, b2);         // 0
            Debug.Log("������ ����: " + c2);

            // 6. ������ ����: ����� �������� �����ϴ� ���͸� ���� ��
            Vector3 d2 = Vector3.Cross(a2, b2);     // (0, 0, -1)
            Debug.Log("������ ����: " + d2);       
        }
    }


    // ����ü: Vector3�� ����ü�� �����������
    // ����ü�� �����θ� �����ǰ� Ŭ������ ���� + �Լ��� ������
    struct Vector3Sample {
        public float x;
        public float y;
        public float z;
    }
