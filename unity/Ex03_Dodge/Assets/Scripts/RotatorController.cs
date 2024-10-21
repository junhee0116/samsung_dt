using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorController : MonoBehaviour {
    public float rotationSpeed = 60f;

    void Update() {
        // Method Overloading (메소드 이름을 동일하게 사용하고, 매개변수의 개수와 타입을 다르게함)
        // Method OverRiding (부모클래스의 메소드를 자식클래스에서 재정의함)
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);        
    }
}
