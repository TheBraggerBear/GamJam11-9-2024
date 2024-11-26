using UnityEngine;
using UnityEngine.UIElements;

public class HealthBar : MonoBehaviour
{
    public VisualElement healthProgressBar;
    public PlayerInitialize player;
    private ProgressBar progressBar;

    void Start()
    {
        // Get the root VisualElement of the UI Document
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Get the ProgressBar element by name (make sure the name matches your UI element)
        healthProgressBar = root.Q<ProgressBar>("HealthProgressBar");

        // Initialize the progress bar values
        progressBar = healthProgressBar.Q<ProgressBar>();
        progressBar.highValue = player.playerHealth;
        progressBar.value = player.playerHealth;
    }

    void Update()
    {
        // Update the progress bar value to match the player's health
        progressBar.value = player.playerHealth;
    }
}
