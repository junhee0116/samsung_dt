using UnityEngine;

public class FpsController : MonoBehaviour {
    public GameObject bulletPrefab;       // 총알 프리팹
    public Transform gunBarrel;          // 총구 위치
    public float bulletSpeed = 20f;      // 총알 속도
    public GameObject aimUI;             // 에임 UI (십자선)

    public PlayerController player;
    private Camera fpsCamera;            // FPS 카메라

    void Start() {
        // Main Camera 참조
        fpsCamera = Camera.main;

        // 에임 UI를 화면 정중앙에 고정
        if(aimUI != null) {
            RectTransform rectTransform = aimUI.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = Vector2.zero; // 화면 중앙

            player = FindObjectOfType<PlayerController>();
        }
    }

    void Update() {
        // 마우스 왼쪽 클릭으로 총알 발사
        if(Input.GetMouseButtonDown(0)) {
            Shoot();
            Debug.Log("Shoot");
        }
    }

    void Shoot() {
        player.Damage();
        // 카메라 중심에서 발사 방향 계산
        Ray ray = fpsCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Vector3 shootDirection = ray.direction;

        // 총알 생성 및 발사
        GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, Quaternion.identity);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        if(bulletRigidbody != null) {
            bulletRigidbody.velocity = shootDirection * bulletSpeed;
        }

        // 총알은 일정 시간이 지나면 제거
        Destroy(bullet, 3f);
    }
}
