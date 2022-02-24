using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObjectSpawner : MonoBehaviour
{
    [Tooltip("This prefab will only be spawned once and persisted between " +
    "scenes.")]
    [SerializeField] List<GameObject> persistentObjectsPrefab = null;

    static bool hasSpawned = false;

    private void Awake()
    {
        if (hasSpawned) return;

        SpawnPersistentObjects();

        hasSpawned = true;
    }

    private void SpawnPersistentObjects()
    {
        foreach(GameObject obj in persistentObjectsPrefab)
        {
            GameObject persistentObject = Instantiate(obj);
            DontDestroyOnLoad(persistentObject);
        }
    }
}
