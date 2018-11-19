using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotateobj : MonoBehaviour {

    public float speed = 2f;
    float originalY;
    float amplitude = 0.1f;
    private void Start()
    {
        originalY = transform.position.z;
    }
   
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y,originalY + amplitude * Mathf.Sin(speed * Time.time));
        
    }
}
