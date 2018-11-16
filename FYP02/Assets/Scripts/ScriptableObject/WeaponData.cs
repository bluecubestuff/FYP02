using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapon_Data")]
public class WeaponData : MonoBehaviour
{
    public int cost;
    public float damage;
    public GlobalEnum.WeaponEffects weaponEffects;
    public GlobalEnum.ClassType classType;
}