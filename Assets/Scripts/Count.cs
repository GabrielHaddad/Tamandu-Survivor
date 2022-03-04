using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour
{

    void Update()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");
        int count = 0;
        foreach(GameObject obj in objects)
        {
            if (obj.activeInHierarchy)
            {
                count++;
            }
        }
        Debug.Log($"Enemies: {count}");
    }
}
