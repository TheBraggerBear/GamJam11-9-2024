using System.Collections;
using UnityEngine;

public class PlayerInitialize : MonoBehaviour
{
    GameObject player;
    public float playerHealth = 100f;
    public float gravityStrength;

    void Start()
    {
        player = GameObject.Find("Player");
        //gravityStrength = 9.81f;
        //StartCoroutine(DecreaseHealthOverTime());
        Physics.gravity = new Vector3(0, -gravityStrength, 0); // Set global gravity
    }

    /*IEnumerator DecreaseHealthOverTime()
    {
        while (playerHealth > 0)
        {
            yield return new WaitForSeconds(1);
            playerHealth -= 1;
            Debug.Log("Player Health: " + playerHealth);
        }
    }*/

    public void TakeDamage(float i)
    {
        playerHealth -= i;
        Debug.Log("Player took " + i + " damage");
    }

    private float lastClickTime = 0f;
    private const float doubleClickTime = 0.3f; // Time window for double click
    private const float standardGravity = 9.81f; // Standard Earth gravity

    private void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f && gravityStrength < 100) // Mouse scrolled up
        {
            gravityStrength += 1f; // Increase gravity
            Debug.Log("Gravity Increased: " + gravityStrength);
        }
        else if (scroll < 0f && gravityStrength > -100) // Mouse scrolled down
        {
            gravityStrength -= 1f; // Decrease gravity
            Debug.Log("Gravity Decreased: " + gravityStrength);
        }
        else if (Input.GetMouseButtonDown(2)) // Mouse button pressed down
        {
            float currentTime = Time.time;
            if (currentTime - lastClickTime < doubleClickTime) // Check for double click
            {
                gravityStrength = standardGravity; // Set gravity to standard
                Debug.Log("Gravity Set to Standard: " + gravityStrength);
            }
            else
            {
                gravityStrength = 0f; // Set gravity to zero
                Debug.Log("Gravity Set to Zero: " + gravityStrength);
            }
            lastClickTime = currentTime; // Update last click time
        }

        Physics.gravity = new Vector3(0, -gravityStrength, 0); // Update global gravity
    }
}
