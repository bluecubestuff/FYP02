using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy_Data")]
public class EnemyData : ScriptableObject
{
    public string name;
    public float health;
    public float damage;
    public float attackDelay;
}

