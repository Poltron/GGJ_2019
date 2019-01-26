using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    public void Spawn()
    {
        Debug.Log(gameObject.name + " spawn.");
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
