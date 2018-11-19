using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public float moveSpeed = 10f;
    public Collider attackCollider;
    public GameObject projectile;

    private Vector3 forward = new Vector3(0, 1, 0);
    private Vector3 right = new Vector3(1, 0, 0);

    private Transform cameraTransform;
    private Rigidbody rigidBody;
    private Vector3 lastMoveDir;
    private Vector3 slideDir;
    private float slideSpeed;
    private State state;
    private float DodgeCooldown = 0;

    //Attacking (might be changed)
    [SerializeField]
    private float attackDelay = 1f;
    private float attackTimer;
    private float attackDuration;

    private enum State
    {
        Normal,
        Dodge,
    }
    private void Awake()
    {
        state = State.Normal;
    }
    private void Start()
    {
        attackTimer = attackDelay;
        attackDuration = attackDelay * 0.5f;
        cameraTransform = Camera.main.transform;
        rigidBody = gameObject.GetComponent<Rigidbody>();
        
    }
    private void FixedUpdate()
    {
        DodgeCooldown -= Time.deltaTime;
        switch (state)
        {
            case State.Normal:
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
                    if(DodgeCooldown<0)
                    StartDodge();

                    break;
                }
            case State.Dodge:
                DoDodge();
                break;

        }
    }
    private void StartDodge()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DodgeCooldown = 0.6f;
            state = State.Dodge;
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            slideDir = (Input.mousePosition - pos).normalized;
            slideDir.z = 0;
            Debug.Log(slideDir);
            slideSpeed = 30f;
        }
    }
    private void DoDodge()
    {
        TryMove(slideDir, slideSpeed * Time.deltaTime);
        //transform.position += slideDir * slideSpeed * Time.deltaTime;
        slideSpeed -= slideSpeed * 4f * Time.deltaTime;
        if (slideSpeed < 10f)
        {
            state = State.Normal;
        }
        rigidBody.MovePosition(transform.position);
    }
    private bool CanMove(Vector3 dir, float distance)
    {
        Debug.Log(Physics2D.Raycast(transform.position, dir, distance).collider == null);
        return Physics2D.Raycast(transform.position, dir, distance).collider == null;
    }

    private bool TryMove(Vector3 baseMoveDir, float distance)
    {
        Vector3 moveDir = baseMoveDir;
        bool canMove = CanMove(moveDir, distance);
        if (!canMove)
        {
            // Cannot move diagonally
            moveDir = new Vector3(baseMoveDir.x, 0f).normalized;
            canMove = moveDir.x != 0f && CanMove(moveDir, distance);
            if (!canMove)
            {
                // Cannot move horizontally
                moveDir = new Vector3(0f, baseMoveDir.y).normalized;
                canMove = moveDir.y != 0f && CanMove(moveDir, distance);
            }
        }

        if (canMove)
        {
            lastMoveDir = moveDir;
            transform.position += moveDir * distance;
            return true;
        }
        else
        {
            return false;
        }
    }
    // Update is called once per frame
    void Update ()
    {
        if (attackTimer < attackDelay)
            attackTimer += Time.deltaTime;
        if (attackTimer >= attackDuration && attackCollider.gameObject.activeSelf)
            attackCollider.gameObject.SetActive(false);

        //do attack (temp)
        if (Input.GetMouseButtonDown(0))
            Attack();
        if (Input.GetMouseButtonDown(1))
            RangeAttack();

        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        cameraTransform.position = new Vector3(transform.position.x, transform.position.y - 1f, cameraTransform.position.z);
    }

    void Attack()
    {
        //Debug.Log("attack timer: " + attackTimer.ToString());
        if(attackTimer >= attackDelay)
        {
            attackCollider.gameObject.SetActive(true);
            attackTimer = 0;
        }
    }

    void RangeAttack()
    {
        Instantiate(projectile, attackCollider.transform.position, gameObject.transform.rotation);
    }
}
