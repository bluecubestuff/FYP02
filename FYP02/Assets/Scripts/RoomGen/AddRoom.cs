using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
	private RoomTemplates templates;
	void Start()
    {
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		templates.rooms.Add(this.gameObject);
       // gameObject.transform.Rotate(new Vector3(90, 0, 0));

    }
}
