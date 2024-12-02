using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameOver : MonoBehaviour
{
    public PlayerInitialize player;

    private void Update()
    {
        //player = GameObject.Find("Player")?.GetComponent<PlayerInitialize>();

        if (player != null && player.playerHealth <= 0)
        {
            Debug.Log("Game Over!");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(1);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
