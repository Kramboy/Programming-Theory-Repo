using System;
using System.Collections;
using System.Collections.Generic;
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
    }

    private void HandleMovement()
    {
        float horizontalInput = 0f;
        float verticalInput = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -1;
        }

        Vector3 movementDirection = new(horizontalInput, 0f, verticalInput);
        movementDirection.Normalize();
        controller.Move(movementSpeed * Time.deltaTime * movementDirection);
        if(movementDirection != Vector3.zero)
        {
            controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation, Quaternion.LookRotation(movementDirection), Time.deltaTime * rotationSpeed);
        }
    }
}
