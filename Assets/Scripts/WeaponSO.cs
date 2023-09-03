using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Weapon")]
public class WeaponSO : ScriptableObject
{
    public string weaponName;
    public Transform prefab;
}
