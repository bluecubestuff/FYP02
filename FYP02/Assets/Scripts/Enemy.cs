using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private EnemyData data;

    private Vector3 target;    

	// Use this for initialization
	void Start () {
        // set enemy target as player
        if (Player.Instance != null)
            target = Player.Instance.transform.position;
        else
            Debug.Log("Player does not exist"); //set to waypoint or something
	}
	
	// Update is called once per frame
	void Update () {

	}
}
