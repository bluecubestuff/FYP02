using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float moveSpeed = 10f;

    private Vector3 forward = new Vector3(0, 1, 0);
    private Vector3 right = new Vector3(1, 0, 0);

    private Transform cameraTransform;
    private Rigidbody rigidBody;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            //rigidBody.AddForce(Vector3.up * moveSpeed);
        transform.position += forward * moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
            //rigidBody.AddForce(-Vector3.right * moveSpeed);
        transform.position -= right * moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            //rigidBody.AddForce(-Vector3.up * moveSpeed);
        transform.position -= forward * moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            //rigidBody.AddForce(Vector3.right * moveSpeed);
        transform.position += right * moveSpeed * Time.deltaTime;

        rigidBody.MovePosition(transform.position);
    }

    // Update is called once per frame
    void Update ()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        cameraTransform.position = new Vector3(transform.position.x, transform.position.y - 1f, cameraTransform.position.z);
    }
}
