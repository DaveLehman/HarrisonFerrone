using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorPhysicsJumpNoMultiJump : MonoBehaviour
{


    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public float jumpVelocity = 5f;
    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;

    public GameObject bullet;
    public float bulletSpeed = 100f;

    private float vInput;
    private float hInput;
    private bool shooting = false;
    private bool jumping = true;

    private Rigidbody _rb;
    private CapsuleCollider _col;
    private GameBehavior _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
        if(_rb == null)
        {
            Debug.Log($"Failed to obtain "+ this.name+"'s Rigidbody component");
        }
        if (_col == null)
        {
            Debug.Log($"Failed to obtain " + this.name + "'s Capsule Collider component");
        }
        if (_col == null)
        {
            Debug.Log($"Failed to obtain Game Behavior's Game Manager component");
        }
    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            shooting = true;
        }
    }
    // new for physics
    private void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

        if (jumping)
        {
            //Debug.Log("Jump");
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            jumping = false;
        }

        if(shooting)
        {
            //Debug.Log("Bang");
            GameObject newBullet = Instantiate(bullet, this.transform.position + new Vector3(1, 0, 0), this.transform.rotation) as GameObject;
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * bulletSpeed;
            shooting = false;
        }
    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        //Debug.Log("CapsuleBottom is " + capsuleBottom.x + "," + capsuleBottom.y + "," + capsuleBottom.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);
        //Debug.Log("IsGrounded returns " + grounded.ToString());
        return grounded;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            _gameManager.PlayerHP -= 1;
        }
    }
}
