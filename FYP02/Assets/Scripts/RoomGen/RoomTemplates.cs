using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoomTemplates : MonoBehaviour {

	public GameObject[] bottomRooms;
	public GameObject[] topRooms;
	public GameObject[] leftRooms;
	public GameObject[] rightRooms;

    // type of room it is e.g(treasure,shop,garbage,...)
    public GameObject[] typeRooms;

    //nav mesh
    public List<NavMeshSurface> surfaces;

    public GameObject closedRoom;
	public GameObject boss;
	public float waitTime;

    // Store the rooms generated
	public List<GameObject> rooms;

	private bool spawnedBoss;

    private void Awake()
    {
        surfaces = new List<NavMeshSurface>();
    }

    void Update(){
        if (spawnedBoss)
            return;

        // might move this to start
		if(waitTime <= 0 && spawnedBoss == false)
        {
			for (int i = 0; i < rooms.Count; i++)
            {
				if(i == rooms.Count-1)
                {
					Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
					spawnedBoss = true;
                }
			}

            for (int j = 0; j < surfaces.Count; j++)
            {
                surfaces[j].BuildNavMesh();
            }

        }
        else
        {
			waitTime -= Time.deltaTime;
		}
	}
}
