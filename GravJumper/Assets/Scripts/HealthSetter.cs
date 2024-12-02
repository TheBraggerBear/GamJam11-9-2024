using UnityEngine;
using UnityEngine.UIElements;

public class HealthSetter : MonoBehaviour
{
    public VisualElement display;
    public PlayerInitialize player;
    private ProgressBar progressBar;

    void Start()
    {
        // Get the root VisualElement of the UI Document
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Get the ProgressBar element by name (make sure the name matches your UI element)
        display = root.Q<ProgressBar>("HealthProgressBar");

        // Check if display is null to avoid NullReferenceException
        if (display == null)
        {
            Debug.LogError("HealthProgressBar not found in the UI Document.");
            return;
        }

        // Initialize the progress bar values
        progressBar = display.Q<ProgressBar>();
        if (progressBar == null)
        {
            Debug.LogError("ProgressBar component not found in the display.");
            return;
        }

        progressBar.highValue = 100;
        progressBar.lowValue = 0;

        // Check if player is assigned to avoid NullReferenceException
        if (player != null)
        {
            progressBar.value = player.playerHealth;
        }
        else
        {
            Debug.LogError("PlayerInitialize reference is not set.");
        }
    }

    void Update()
    {
        // Update the progress bar value to match the player's health
        if (player != null)
        {
            progressBar.value = player.playerHealth;
        }
    }
}
