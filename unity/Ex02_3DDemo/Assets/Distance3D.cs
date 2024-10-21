using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance3D : MonoBehaviour {
    // public으로 초기화하면 공개, private으로 초기화하면 비공개
    public GameObject object1;  // 첫번째 게임 오브젝트
    private GameObject object2;  // 두번째 게임 오브젝트

    void Start() {
        // 씬에서 게임오브젝트 이름으로 게임오브젝트 찾기
        object1 = GameObject.Find("Cube1");
        object2 = GameObject.Find("Cube2");
    }

    void Update() {
        if(object1 != null && object2 != null) {
            // GameObject1 Position: (0.00, 4.00, 0.00)
            Debug.Log("GameObject1 Position: " + object1.transform.position);       // position: Vector3 Type
            Debug.Log("GameObject2 Position: " + object2.transform.position);
        } else {
            Debug.Log("null 입니다");
        }

        // GameObject Distance
        Vector3 pos1 = object1.transform.position;
        Vector3 pos2 = object2.transform.position;
        Vector3 delta1 = pos1 - pos2;
        float distance = delta1.magnitude;
        Debug.Log("두 게임오브젝트 간의 거리: " + distance);

        float distance2 = Vector3.Distance(pos1, pos2);
        Debug.Log("두 게임오브젝트 간의 거리: " + distance2);

        // 두 벡터 사이의 방향과 이동거리 구하기
        Vector3 currentPos = new Vector3(1, 0, 1);
        Vector3 destPos = new Vector3(5, 3, 5);
        // 방향벡터
        Vector3 direction = (destPos - currentPos).normalized;                      // 정규벡터(길이 1) 방향성
        // 목적지를 향해 10만큼 현재 위치에서 이동하기
        Vector3 newPos = currentPos + direction * 10;
    }
}
