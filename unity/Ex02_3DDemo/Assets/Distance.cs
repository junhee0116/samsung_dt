using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 두 점 사이의 거리 구하기
        float distance = GetDistance(2, 2, 5, 5);
        Debug.Log(distance);

    }
    float GetDistance(float x1, float y1, float x2, float y2) {
        float distance = Mathf.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));

        return distance;
    }
}
