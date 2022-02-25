using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
    PlayerHealth playerHealth;

    void Awake() 
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            playerHealth.SetIsDead(!playerHealth.GetIsDead());
        }
    }
}
