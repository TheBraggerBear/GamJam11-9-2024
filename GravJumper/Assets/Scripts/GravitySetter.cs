using UnityEngine;
using UnityEngine.UIElements;

public class GravitySetter : MonoBehaviour
{
    public VisualElement gravityTracker;
    public PlayerInitialize player;
    private ProgressBar progressBar;

    void Start()
    {
        // Get the root VisualElement of the UI Document
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Get the ProgressBar element by name (make sure the name matches your UI element)
        gravityTracker = root.Q<ProgressBar>("GravityTracker");

        // Initialize the progress bar values
        progressBar = gravityTracker.Q<ProgressBar>("GravityTracker");
        if (player != null) // Check if player is not null
        {
            progressBar.value = player.gravityStrength; // Set progressBar to the value of GravityStrength from PlayerInitialize
        }
    }

    void Update()
    {
        if (player != null && progressBar != null) // Check if player and progressBar are not null
        {
            // Update the progress bar value to match the player's gravity
            progressBar.value = player.gravityStrength + 100;

            progressBar.transform.rotation = Quaternion.Euler(0, 0, player.gravityStrength); // Rotate the progressBar to match the gravity
        }
    }
}
