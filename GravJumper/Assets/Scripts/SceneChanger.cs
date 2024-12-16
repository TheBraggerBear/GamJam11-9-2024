using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // The name of the scene to load
    public string sceneToLoad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Removed the incorrect call to OnCollisionEnter
    }

    // Check for touch with the player
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Player"))
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject.CompareTag("Player"))
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
