using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [Tooltip("The player's movement speed")]
    [SerializeField] Vector2 moveSpeed;
    Vector2 moveInput;
    Rigidbody myRigidBody;

    void Awake() 
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void FixedUpdate() 
    {
        Move();
    }

    void Move() 
    {
        float xMovement = moveInput.x * moveSpeed.x;
        float zMovement = moveInput.y * moveSpeed.y;

        Vector3 moveForce = new Vector3(xMovement, 0.0f, zMovement);
        myRigidBody.AddRelativeForce(moveForce);
    }

    void OnMove(InputValue value)
    {
        Debug.Log("move");
        moveInput = value.Get<Vector2>();
    }
}
