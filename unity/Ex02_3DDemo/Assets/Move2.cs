using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour {
    public GameObject cube2;

    void Start() {
        // 자신의 각도를 Y축 방향 45도 설정
        // rotation는 퀀터니언(4차원)으로 되어있으므로 Quaternion 사용
        transform.rotation = Quaternion.Euler(new Vector3(0, 45, 0));

    }

    void Update() {
        // 글로벌 좌표계로 이동
        // transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime, Space.World);

        // 로컬 좌표계로 이동
        // transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime, Space.Self);

        //cube2.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime, Space.Self);
        cube2.transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime, Space.Self);
    }
}
