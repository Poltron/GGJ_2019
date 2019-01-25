using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Speed;

    private Vector2 velocity;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		if (Input.GetKey(KeyCode.Z))
        {
            velocity.y += 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            velocity.y -= 1;
        }
        else
        {
            velocity.y = 0;
        }

        if (Input.GetKey(KeyCode.D))
        {
            velocity.x += 1;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            velocity.x -= 1;
        }
        else
        {
            velocity.x = 0;
        }

        velocity.Normalize();

        Vector3 movement = new Vector3(velocity.x, 0, velocity.y);

        transform.position += movement * Speed * Time.deltaTime;
	}
}
