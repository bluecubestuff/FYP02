using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public List<Enemy> enemyList;
    public int numOfEnemy;

    public void SpawnEnemy()
    {
        foreach (Enemy enemy in enemyList)
        {
            int rand = Random.Range(0, enemyList.Count);
            Instantiate(enemy.gameObject, gameObject.transform.position, enemy.transform.rotation);
        }
    }
}
