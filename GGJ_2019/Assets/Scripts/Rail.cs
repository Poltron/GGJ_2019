using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour
{
    [SerializeField] private Transform Bot;
    [SerializeField] private Transform Top;
    [SerializeField] private Transform Wall;

    void Start()
    {
		
	}
	
	void Update()
    {
        Wall.localPosition = new Vector3(0, 0, Wall.localPosition.z);
    }

    private void LateUpdate()
    {
        if (Wall.localPosition.z > Top.localPosition.z)
        {
            Wall.localPosition = new Vector3(0, 0, Top.localPosition.z);
        }
        else if (Wall.localPosition.z < Bot.localPosition.z)
        {
            Wall.localPosition = new Vector3(0, 0, Bot.localPosition.z);
        }
    }
}
