using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorController : MonoBehaviour {
    public float rotationSpeed = 60f;

    void Update() {
        // Method Overloading (�޼ҵ� �̸��� �����ϰ� ����ϰ�, �Ű������� ������ Ÿ���� �ٸ�����)
        // Method OverRiding (�θ�Ŭ������ �޼ҵ带 �ڽ�Ŭ�������� ��������)
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);        
    }
}
