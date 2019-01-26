using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] private Transform[] walls;
    [SerializeField] private Vector2 direction;

	void Start()
    {
		
	}
	
	void Update()
    {
		foreach(Transform wall in walls)
        {
        }
	}
}
