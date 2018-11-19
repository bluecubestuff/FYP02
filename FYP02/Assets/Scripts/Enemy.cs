using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private EnemyData data;

    private Vector3 target;
    private NavMeshAgent navAgent;

    private float timer;

    private float health;
    private float dist;

	// Use this for initialization
	void Start () {
        // set enemy target as player
        if (Player.Instance != null)
            target = Player.Instance.transform.position;
        else
            Debug.Log("Player does not exist"); //set to waypoint or something

        navAgent = GetComponent<NavMeshAgent>();
        health = data.health;
    }
	
	// Update is called once per frame
	void Update () {

        target = Player.Instance.transform.position;
        dist = Vector3.Distance(transform.position, target);

        if (dist > 4f)
            return;

        if (timer < data.attackDelay)
            timer += Time.deltaTime;

        if (dist < 1.3f)
        {
            if(timer > data.attackDelay)
            {
                Player.Instance.UpdateHealth(-data.damage);
                timer = 0;
            }
            return;
        }

        navAgent.SetDestination(target);
    }

    public void UpdateHealth(float _hp)
    {
        health += _hp;
        if (health <= 0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

}
