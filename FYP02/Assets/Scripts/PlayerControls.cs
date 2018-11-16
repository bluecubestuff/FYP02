using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public float moveSpeed = 10f;
    public Collider attackCollider;

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
        //do attack (temp)
        if (Input.GetMouseButtonDown(0))
            attackCollider.gameObject.SetActive(true);

         Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        cameraTransform.position = new Vector3(transform.position.x, transform.position.y - 1f, cameraTransform.position.z);
    }
}
