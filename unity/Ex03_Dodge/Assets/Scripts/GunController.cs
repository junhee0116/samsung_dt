using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
    // 
    public Transform spawnPos;
    public GameObject bulletPrefab;
    private float timeAfterSpawn;
    public float spawnRateTime = 2.0f;

    void Start() {
        timeAfterSpawn = 0f;
    }

    // Update is called once per frame
    void Update() {
        timeAfterSpawn += Time.deltaTime;

        if(timeAfterSpawn > spawnRateTime) {
            if(Input.GetKey(KeyCode.R)) {
                GameObject bullet = Instantiate(bulletPrefab, spawnPos.position, transform.rotation);
                timeAfterSpawn = 0;
            }
        }
    }
}
