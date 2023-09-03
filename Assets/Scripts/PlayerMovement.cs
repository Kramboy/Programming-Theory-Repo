using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        HandleMovement();
        CheckGround();
    }

    private void CheckGround()
    {
        if(transform.position.y > 0f)
        {
            transform.position = new(transform.position.x, 0f, transform.position.z);
        }
    }


    // ABSTRACTION
    private void HandleMovement()
    {
        float horizontalInput = 0f;
        float verticalInput = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            verticalInput = 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            verticalInput = -1;
        }

        Vector3 movementDirection = new(horizontalInput, 0f, verticalInput);
        movementDirection.Normalize();
        controller.Move(movementSpeed * Time.deltaTime * movementDirection);
        /* Handle Rotation
         * 
         * if(movementDirection != Vector3.zero)
         * {
         *     controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation, Quaternion.LookRotation(movementDirection), Time.deltaTime * rotationSpeed);
         * }
         * 
         */
    }
}
