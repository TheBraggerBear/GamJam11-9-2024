using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables for movement speed and rigidbody
    public float moveSpeed = 5f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        // Get input from the player
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Create a Vector3 movement direction
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Apply movement to the Rigidbody
        rb.MovePosition(transform.position + move * moveSpeed * Time.deltaTime);
    }
}
