using UnityEngine;

public class FireSystem : MonoBehaviour
{
    [SerializeField] private Weapon[] pfWeapons;
    [SerializeField] private Transform launchPosition;

    private Weapon currentWeapon;
    private int ammo;

    private void Start()
    {
        ammo = 100;
        currentWeapon = pfWeapons[0];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ammo > 0) Fire(currentWeapon);
            //else Debug.Log($"Not enough ammo for {currentWeapon.WeaponSObject.weaponName}");
        }
    }

    private void Fire(Weapon currentWeapon)
    {
        Instantiate(currentWeapon, launchPosition.position, Quaternion.identity);
    }
}
