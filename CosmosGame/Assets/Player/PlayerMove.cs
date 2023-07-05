using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    public float mouseSensitivity = 100.0f;
    private Rigidbody rb;
    private CharacterController controller;

    private float verticalRotation = 0.0f;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        LockCamara();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerInputMove();
        CamaraMove();


    }

    private void FixedUpdate()
    {
        // PlayerMove();
    }



    void PlayerInputMove()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime; ;
        float verticalMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime; ;

        moveDirection = new Vector3(horizontalMovement, 0, verticalMovement);
        moveDirection = transform.TransformDirection(moveDirection);
        controller.Move(moveDirection);



    }


    //void PlayerMove()
    //{
    //  rb.MovePosition(transform.position + (moveDirection* speed * Time.fixedDeltaTime));
    //}

    void LockCamara()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void CamaraMove()
    {
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float verticalMouseMovement = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        verticalRotation -= verticalMouseMovement;
        verticalRotation = Mathf.Clamp(verticalRotation, -90.0f, 90.0f);

        transform.Rotate(0, horizontalRotation, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
}
