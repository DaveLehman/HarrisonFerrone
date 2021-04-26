using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorPhysics : MonoBehaviour
{
    /* There are two options when it comes to applying force:
     * 1. You can do it directly by using RigidBody class methods such as AddForce and AddTorque to move an rotate an object. This approach has
     * its drawbacks and often requires additional code to compensate for unexpected physics behavior.
     * 2. You can use other RigidBody class methods such as MovePosition and MoveRotation, whcih still usee applied force but take care of
     * edge cases behind the scenes. This is the approach we use here.
     */
    // Start is called before the first frame update
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;

    private float vInput;
    private float hInput;

    // new for physics
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        //this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        //this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);


    }
    // new for physics
    private void FixedUpdate()
    {
        // FixedUpdate is frame rate independent and is used for all physics code
        Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

    }
}
