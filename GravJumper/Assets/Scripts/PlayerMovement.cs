using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSmoothTime;
    public static float GravityStrength;
    public float JumpStrength;
    public float WalkSpeed;
    public float RunSpeed;
    public float MaxFallSpeed; // Maximum fall speed before taking damage
    public float FallDamageMultiplier; // Multiplier for damage based on fall speed
    public PlayerInitialize player;
    private CharacterController Controller;
    private Vector3 CurrentMoveVelocity;
    private Vector3 MoveDampVelocity;

    private Vector3 CurrentForceVelocity;
    private float midairSlowdownFactor = 0.999f; // Factor to slow down movement in midair

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (player == null)
        {
            player = FindAnyObjectByType<PlayerInitialize>();
        }
        GravityStrength = Physics.gravity.y; // Use Physics.gravity for gravity strength
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GravityStrength = Physics.gravity.y; // Update gravity strength from Physics.gravity
        Vector3 PlayerInput = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = 0f,
            z = Input.GetAxisRaw("Vertical")
        };

        if (PlayerInput.magnitude > 1f)
        {
            PlayerInput.Normalize();
        } // Normalize the input vector to prevent faster diagonal movement

        Vector3 MoveVector = transform.TransformDirection(PlayerInput);
        float CurrentSpeed = Input.GetKey(KeyCode.LeftShift) ? RunSpeed : WalkSpeed;

        CurrentMoveVelocity = Vector3.SmoothDamp(
            CurrentMoveVelocity,
            MoveVector * CurrentSpeed,
            ref MoveDampVelocity,
            MoveSmoothTime
        );

        Controller.Move(CurrentMoveVelocity * Time.deltaTime); // this should move the player on the x and z axis

        Ray groundCheckRay = new Ray(transform.position, Vector3.down);
        bool isGrounded = Physics.Raycast(groundCheckRay, 1.25f);

        CurrentForceVelocity.y += Physics.gravity.y * Time.deltaTime; // Apply gravity
        if (isGrounded)
        {
            CurrentForceVelocity.y = -1f; // Small downward force to keep grounded

            if (Input.GetKey(KeyCode.Space))
            {
                CurrentForceVelocity.y = JumpStrength; // Jump
            }
        }
        else
        {
            if (GravityStrength == 0) // Only apply midair slowdown if gravity is zero
            {
                CurrentForceVelocity.y *= midairSlowdownFactor; // Slow down vertical movement
            }
        }

        Controller.Move(CurrentForceVelocity * Time.deltaTime); // this should move the player on the y axis
    }
}
