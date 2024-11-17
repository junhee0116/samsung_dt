using UnityEngine;

public class WeaponsController : MonoBehaviour {
    public GameObject weaponPrefab; // ���� ������
    public Transform attachPoint;  // ���⸦ ���� ��ġ (WeaponAttachPoint)
    public PlayerController player;
    private GameObject currentWeapon; // ���� ������ ����



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
            Destroy(currentWeapon); // ���� ���� ����
        }

        // ���� ���� �� ����
        currentWeapon = Instantiate(weaponPrefab, attachPoint.position, attachPoint.rotation);
        currentWeapon.transform.SetParent(attachPoint); // �θ� ����
    }

    void LateUpdate() {
        // ������ ��ġ�� ȸ���� �� ��ġ�� ����ȭ
        if(currentWeapon != null) {
            currentWeapon.transform.position = attachPoint.position;
            currentWeapon.transform.rotation = attachPoint.rotation;
        }
    }
}
