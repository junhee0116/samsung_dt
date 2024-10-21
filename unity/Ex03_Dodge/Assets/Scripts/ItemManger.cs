using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManger : MonoBehaviour {
    public float timeItemSpawn = 10f; // 10�ʷ� ����
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
        // 0���� 3���� ���� �ε��� ����
        int index = Random.Range(0, 3);
        Vector3 pos = itemSpawnPos[index].transform.position;

        // prefab ���κ��� �������� ����
        GameObject item = Instantiate(itemPrefab, pos, transform.rotation);
    }
}
