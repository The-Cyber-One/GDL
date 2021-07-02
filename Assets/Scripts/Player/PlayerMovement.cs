using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private CharacterController characterController;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 movement = new Vector3();
        movement += Input.GetAxis("Horizontal") * transform.right;
        movement += Input.GetAxis("Vertical") * transform.forward;

        characterController.Move(movement.normalized * speed * Time.deltaTime);

        characterController.Move(Physics.gravity * Time.deltaTime);
    }
}
