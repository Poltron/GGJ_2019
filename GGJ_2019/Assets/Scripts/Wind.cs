using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float TimeBeforeDestroy;

    private void Start()
    {
        foreach (ColliderGitan gitan in GetComponentsInChildren<ColliderGitan>())
        {
            gitan.Speed = Speed;
        }

        StartCoroutine(timeBeforeDestroy(TimeBeforeDestroy));
    }

    private IEnumerator timeBeforeDestroy(float t)
    {
        yield return new WaitForSeconds(t);
        Destroy(gameObject);
    }
}
