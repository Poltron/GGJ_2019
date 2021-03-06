﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderGitan : MonoBehaviour
{
    [HideInInspector]
    public float Speed;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("player ded " + other.name);
            other.gameObject.transform.parent.GetComponent<PlayerController>().PlayerDied();
        }
        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (other.tag == "Item")
        {
            other.GetComponent<Item>().Destroyed();
        }
    }
}
