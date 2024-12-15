using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GravityBootSetter : MonoBehaviour
{
    public VisualElement gravityTracker;
    public PlayerMovement player;
    private UnityEngine.UIElements.Toggle toggle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the root VisualElement of the UI Document
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Get the Toggle element by name (make sure the name matches your UI element)
        toggle = root.Q<UnityEngine.UIElements.Toggle>("GravBoots");

        // Check if toggle is not null before accessing its properties
        if (toggle != null && player != null) // Check if player is not null
        {
            toggle.value = player.gravityBoots; // Set toggle to the value of gravityBoots from PlayerMovement
        }
        else
        {
            Debug.LogError("Toggle or PlayerMovement is not assigned in GravityBootSetter.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && toggle != null) // Check if player and toggle are not null
        {
            toggle.value = player.gravityBoots; // Update the toggle value to match the player's gravity
        }
    }
}
