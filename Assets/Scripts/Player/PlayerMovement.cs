using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 1f;
    public float gravity = -9.81f;

    [Header("Ground detection")]
    public float groundDistance = 0.1f;
    public bool isGrounded;
    public Transform groundTransform;
    public LayerMask groundMask;

    [HideInInspector]
    public bool canMove = true;

    private CharacterController controller;
    private Vector3 velocity = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundTransform.position, groundDistance, groundMask);

        if (canMove)
        {
            Vector3 movement = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
            if (movement.magnitude > 1) movement.Normalize();
            controller.Move(movement * speed * Time.deltaTime);
        }

        if (isGrounded && velocity.y <= 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded && canMove)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
