using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] private float Speed;

    private void Start()
    {
        foreach (ColliderGitan gitan in GetComponentsInChildren<ColliderGitan>())
        {
            gitan.Speed = Speed;
        }
    }
}
