using System.Collections;
using UnityEngine;

public class EggSpawnerController : MonoBehaviour {
    public GameObject EggPrefab;  // 생성할 달걀의 원본 Prefab
    public float spawnRateMin = 0.5f;  // 최소 생성주기
    public float spawnRateMax = 3.0f;  // 최대 생성주기
    public float bulletSpeed = 20.0f;  // 총알 속도
    public float spawnOffset = 1.0f;  // 총알 생성 위치 오프셋

    private Transform target;  // 발사할 대상
    private float spawnRate;  // 생성주기
    private float timeAfterSpawn;  // 최근 생성 시점에서 지난 시간

    void Start() {
        timeAfterSpawn = 0;  // 최근 생성 이후의 시간을 0으로 초기화
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);  // 생성시간을 랜덤으로 설정
        target = GameObject.Find("Player").transform;  // 플레이어 찾기
    }

    void Update() {
        timeAfterSpawn += Time.deltaTime;  // 한 프레임마다 시간 누적

        if(timeAfterSpawn > spawnRate) {
            timeAfterSpawn = 0;  // 누적된 시간을 리셋

            // 스포너의 y값을 사용하여 탄알 생성
            Vector3 spawnPosition = transform.position + transform.forward * spawnOffset;
            GameObject bullet = Instantiate(EggPrefab, spawnPosition, transform.rotation);

            // 타겟을 향해 바라보도록 회전 설정
            bullet.transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));

            // Rigidbody 추가 및 중력 비활성화
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            if(bulletRb == null) {
                bulletRb = bullet.AddComponent<Rigidbody>();
            }
            bulletRb.useGravity = false;

            // 타겟 방향으로 속도 적용
            Vector3 direction = (target.position - bullet.transform.position).normalized;
            bulletRb.velocity = direction * bulletSpeed;

            // 다음 탄알 생성 시간 랜덤 설정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
