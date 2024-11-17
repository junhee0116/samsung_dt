using UnityEngine;

public class FpsController : MonoBehaviour {
    public GameObject bulletPrefab;       // �Ѿ� ������
    public Transform gunBarrel;          // �ѱ� ��ġ
    public float bulletSpeed = 20f;      // �Ѿ� �ӵ�
    public GameObject aimUI;             // ���� UI (���ڼ�)

    public PlayerController player;
    private Camera fpsCamera;            // FPS ī�޶�

    void Start() {
        // Main Camera ����
        fpsCamera = Camera.main;

        // ���� UI�� ȭ�� ���߾ӿ� ����
        if(aimUI != null) {
            RectTransform rectTransform = aimUI.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = Vector2.zero; // ȭ�� �߾�

            player = FindObjectOfType<PlayerController>();
        }
    }

    void Update() {
        // ���콺 ���� Ŭ������ �Ѿ� �߻�
        if(Input.GetMouseButtonDown(0)) {
            Shoot();
            Debug.Log("Shoot");
        }
    }

    void Shoot() {
        player.Damage();
        // ī�޶� �߽ɿ��� �߻� ���� ���
        Ray ray = fpsCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Vector3 shootDirection = ray.direction;

        // �Ѿ� ���� �� �߻�
        GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, Quaternion.identity);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        if(bulletRigidbody != null) {
            bulletRigidbody.velocity = shootDirection * bulletSpeed;
        }

        // �Ѿ��� ���� �ð��� ������ ����
        Destroy(bullet, 3f);
    }
}
