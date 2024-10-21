using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManger : MonoBehaviour {
    public float timeItemSpawn = 10f; // 10초로 설정
    public GameObject itemPrefab;     // prefab link

    public GameObject[] itemSpawnPos;

    void Update() {
        timeItemSpawn -= Time.deltaTime;
        if(timeItemSpawn < 0) {
            timeItemSpawn = 10f;

            spawnItem();
        }
    }

    void spawnItem() {
        // 0부터 3까지 랜덤 인덱스 생성
        int index = Random.Range(0, 3);
        Vector3 pos = itemSpawnPos[index].transform.position;

        // prefab 으로부터 아이템을 생성
        GameObject item = Instantiate(itemPrefab, pos, transform.rotation);
    }
}
