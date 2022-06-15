using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Transform PlayerCamera;
    public CharacterController PlayerController;

    public float MouseSensitivity = 10;
    public float MovementSpeed = 5;
    public float Gravity = -9.81f;

    public Vector3 Velocity;
    public Vector3 PlayerMovementVector;
    public Vector2 PlayerMouseVector;
    public float CamXRotation;

    void Update()
    {
        PlayerMovementVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        PlayerMouseVector = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    
        Move();
        Look();
    }

    void Move()
    {
        Vector3 MoveVector = transform.forward * PlayerMovementVector.z + transform.right * PlayerMovementVector.x;

        if(PlayerController.isGrounded)
        {
            Velocity.y = -3f;
        }
        else
        {
            Velocity.y -= Gravity * -2f * Time.deltaTime;
        }

        PlayerController.Move(MoveVector * MovementSpeed * Time.deltaTime);
        PlayerController.Move(Velocity * Time.deltaTime);
    }

    void Look()
    {
        CamXRotation -= PlayerMouseVector.y * MouseSensitivity;

        transform.Rotate(0f, PlayerMouseVector.x, 0f);
        PlayerCamera.localRotation = Quaternion.Euler(CamXRotation, 0f, 0f);
    }
}
