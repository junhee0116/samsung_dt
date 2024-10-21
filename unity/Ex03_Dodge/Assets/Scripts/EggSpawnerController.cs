using System.Collections;
using UnityEngine;

public class EggSpawnerController : MonoBehaviour {
    public GameObject EggPrefab;  // ������ �ް��� ���� Prefab
    public float spawnRateMin = 0.5f;  // �ּ� �����ֱ�
    public float spawnRateMax = 3.0f;  // �ִ� �����ֱ�
    public float bulletSpeed = 20.0f;  // �Ѿ� �ӵ�
    public float spawnOffset = 1.0f;  // �Ѿ� ���� ��ġ ������

    private Transform target;  // �߻��� ���
    private float spawnRate;  // �����ֱ�
    private float timeAfterSpawn;  // �ֱ� ���� �������� ���� �ð�

    void Start() {
        timeAfterSpawn = 0;  // �ֱ� ���� ������ �ð��� 0���� �ʱ�ȭ
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);  // �����ð��� �������� ����
        target = GameObject.Find("Player").transform;  // �÷��̾� ã��
    }

    void Update() {
        timeAfterSpawn += Time.deltaTime;  // �� �����Ӹ��� �ð� ����

        if(timeAfterSpawn > spawnRate) {
            timeAfterSpawn = 0;  // ������ �ð��� ����

            // �������� y���� ����Ͽ� ź�� ����
            Vector3 spawnPosition = transform.position + transform.forward * spawnOffset;
            GameObject bullet = Instantiate(EggPrefab, spawnPosition, transform.rotation);

            // Ÿ���� ���� �ٶ󺸵��� ȸ�� ����
            bullet.transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));

            // Rigidbody �߰� �� �߷� ��Ȱ��ȭ
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            if(bulletRb == null) {
                bulletRb = bullet.AddComponent<Rigidbody>();
            }
            bulletRb.useGravity = false;

            // Ÿ�� �������� �ӵ� ����
            Vector3 direction = (target.position - bullet.transform.position).normalized;
            bulletRb.velocity = direction * bulletSpeed;

            // ���� ź�� ���� �ð� ���� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
