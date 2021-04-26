using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorTransform : MonoBehaviour
{
    /*
     * One approach to moving a player is adjusting transforms directly, ignoring the physics.
     * Advantage - it's easy
     * Disadvantage - it doesn't use physics
     */
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;

    private float vInput;
    private float hInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
    }
}
