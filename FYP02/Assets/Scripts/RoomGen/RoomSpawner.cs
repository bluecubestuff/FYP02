﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoomSpawner : MonoBehaviour {

    public enum OpeningDirection
    {
        Bottom = 1,
        Top,
        Left,
        Right,
    }

    public OpeningDirection openDirection;

	//public int openingDirection;
	// 1 --> need bottom door
	// 2 --> need top door
	// 3 --> need left door
	// 4 --> need right door


	private RoomTemplates templates;
	private int rand;
	public bool spawned = false;

	public float waitTime = 4f;

	void Start(){
		Destroy(gameObject, waitTime);
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		Invoke("Spawn", 0.1f);
	}


	void Spawn(){
		if(spawned == false)
        {
            GameObject room = null;
            switch (openDirection)
            {
                case OpeningDirection.Bottom:
                    // Need to spawn a room with a BOTTOM door.
                    rand = Random.Range(0, templates.bottomRooms.Length);
                    room = Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                    break;
                case OpeningDirection.Top:
                    // Need to spawn a room with a TOP door.
                    rand = Random.Range(0, templates.topRooms.Length);
                    room = Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                    break;
                case OpeningDirection.Left:
                    // Need to spawn a room with a LEFT door.
                    rand = Random.Range(0, templates.leftRooms.Length);
                    room = Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                    break;
                case OpeningDirection.Right:
                    // Need to spawn a room with a RIGHT door.
                    rand = Random.Range(0, templates.rightRooms.Length);
                    room = Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                    break;
                default:
                    Debug.LogWarning("No opening direction!");
                    //Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                    break;
            }

            //determine the room type
            if (room != null)
            {
                rand = Random.Range(0, templates.typeRooms.Length);
                GameObject rTemp = Instantiate(templates.typeRooms[rand], room.transform.position, templates.typeRooms[rand].transform.rotation);
                templates.surfaces.Add(rTemp.GetComponent<NavMeshSurface>());
            }

            spawned = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
    {
		if(other.CompareTag("SpawnPoint"))
        {
			if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
				Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
				Destroy(gameObject);
			} 
			spawned = true;
		}
	}

}
