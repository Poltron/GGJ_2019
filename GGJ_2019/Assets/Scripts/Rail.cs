using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour
{
    [SerializeField] private Transform Bot;
    [SerializeField] private Transform Top;
    [SerializeField] private Transform Wall;

    private Vector3 initialPosition;

    private void Awake()
    {
        initialPosition = Wall.localPosition;
    }

    void Start()
    {
	}
	
	void Update()
    {
        Wall.localPosition = new Vector3(initialPosition.x, initialPosition.y, Wall.localPosition.z);
    }

    private void LateUpdate()
    {
        if (Wall.localPosition.z > Top.localPosition.z)
        {
            Wall.localPosition = new Vector3(initialPosition.x, initialPosition.y, Top.localPosition.z);
        }
        else if (Wall.localPosition.z < Bot.localPosition.z)
        {
            Wall.localPosition = new Vector3(initialPosition.x, initialPosition.y, Bot.localPosition.z);
        }
    }
}
