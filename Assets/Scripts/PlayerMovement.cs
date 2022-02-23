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

    [Tooltip("The player's rotation speed")]
    [SerializeField] float rotationSpeed;
    Vector2 moveInput;
    Vector2 mouseInput;
    Vector3 mousePos;
    Rigidbody myRigidBody;

    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = false;
    }

    void Update()
    {
        RotatePlayerTowardsMouse();
    }

    private void RotatePlayerTowardsMouse()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hisDist = 0.0f;

        if (playerPlane.Raycast(ray, out hisDist))
        {
            Vector3 targetPoint = ray.GetPoint(hisDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            myRigidBody.rotation = Quaternion.Slerp(myRigidBody.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
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

        myRigidBody.AddForce(moveForce);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    // void OnLook(InputValue value)
    // {
    //     mouseInput = value.Get<Vector2>();
    //     //RotatePlayerToFollowMouse();
    // }
}