using UnityEngine;

public class WeaponsController : MonoBehaviour {
    public GameObject weaponPrefab; // 무기 프리팹
    public Transform attachPoint;  // 무기를 붙일 위치 (WeaponAttachPoint)
    public PlayerController player;
    private GameObject currentWeapon; // 현재 장착된 무기



    private void Update() {
        if(Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    void Shoot() {
        player.Damage();
    }

    public void EquipWeapon() {
        if(currentWeapon != null) {
            Destroy(currentWeapon); // 기존 무기 제거
        }

        // 무기 생성 및 장착
        currentWeapon = Instantiate(weaponPrefab, attachPoint.position, attachPoint.rotation);
        currentWeapon.transform.SetParent(attachPoint); // 부모 설정
    }

    void LateUpdate() {
        // 무기의 위치와 회전을 손 위치에 동기화
        if(currentWeapon != null) {
            currentWeapon.transform.position = attachPoint.position;
            currentWeapon.transform.rotation = attachPoint.rotation;
        }
    }
}
