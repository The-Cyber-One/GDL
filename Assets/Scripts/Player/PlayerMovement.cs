using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 1f;
    public float gravity = -9.81f;
    public bool useGravity = true;

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
        Collider[] colliders = Physics.OverlapSphere(groundTransform.position, groundDistance);

        bool foundFloor = false;
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Floor"))
                foundFloor = true;
        }

        isGrounded = foundFloor;

        if (canMove)
        {
            Vector3 movement = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
            if (movement.magnitude > 1) movement.Normalize();
            controller.Move(movement * speed * Time.deltaTime);
        }

        if ((Physics.CheckSphere(groundTransform.position, groundDistance, LayerMask.NameToLayer("Player")) && velocity.y <= 0) || !useGravity)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded && canMove)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        if (useGravity)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        controller.Move(velocity * Time.deltaTime);
    }
}
