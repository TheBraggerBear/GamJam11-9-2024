using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public float playerSpeed;
    public PlayerInitialize player;
    public float damageMultiplier = 100f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Crate"))
        {
            Rigidbody crateRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (crateRigidbody != null) // Check if the Rigidbody component exists
            {
                float crateSpeed = crateRigidbody.linearVelocity.magnitude; // Use velocity instead of linearVelocity
                float relativeSpeed = Mathf.Abs(playerSpeed - crateSpeed);

                if (player != null) // Check if player reference is not null
                {
                    float damage = CalculateDamage(relativeSpeed);
                    player.TakeDamage(damage*damageMultiplier);

                    Debug.Log($"Collision detected! Player takes {damage} damage. Remaining health: {player.playerHealth}");
                }
                else
                {
                    Debug.LogError("Player reference is null. Ensure the PlayerInitialize component is assigned.");
                }
            }
            else
            {
                Debug.LogWarning("No Rigidbody found on the crate.");
            }
        }
    }

    private float CalculateDamage(float relativeSpeed)
    {
        float damageThreshold = 5f; // Speed difference threshold for no damage
        return Mathf.Max(0, relativeSpeed - damageThreshold);
    }
}
