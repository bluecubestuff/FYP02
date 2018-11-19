using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private EnemyData data;

    private Vector3 target;
    private NavMeshAgent navAgent;

	// Use this for initialization
	void Start () {
        // set enemy target as player
        if (Player.Instance != null)
            target = Player.Instance.transform.position;
        else
            Debug.Log("Player does not exist"); //set to waypoint or something

        navAgent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {

        //if(Vector3.Distance(transform.position, target) < 1)
        //{
        //    Player.Instance.Health -= data.damage;
        //}

        target = Player.Instance.transform.position;
        navAgent.SetDestination(target);
    }
}
