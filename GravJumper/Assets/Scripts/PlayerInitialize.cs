using System.Collections;
using UnityEngine;

public class PlayerInitialize : MonoBehaviour
{
    public int playerHealth = 100;

    void Start()
    {
        //StartCoroutine(DecreaseHealthOverTime());
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
}
