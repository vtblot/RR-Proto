using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public enum MovementType { Force, Torque }
    public float speed = 25f;
    public MovementType movementType = MovementType.Torque;
    private Vector3 forward = Vector3.zero;
    private Vector3 movement = Vector3.zero;
    private Rigidbody rb = null;
    public float maxSpeed = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        movement = (moveVertical * forward + moveHorizontal * Camera.main.transform.right).normalized;
        if (movementType == MovementType.Force) rb.AddForce(movement * speed);
        if (movementType == MovementType.Torque) rb.AddTorque(new Vector3(movement.z, 0, -movement.x) * speed);
    }

    void Update()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }
}
