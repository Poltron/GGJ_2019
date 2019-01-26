using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Controls
{
    Arrow,
    ZQSD
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Rigidbody _rigidBody;

    [SerializeField] private Controls controls;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void Start ()
    {
		
	}

    private void FixedUpdate()
    {
        Vector2 velocity = new Vector2();
        if (controls == Controls.ZQSD)
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
        }
        else if (controls == Controls.Arrow)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                velocity.y += 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                velocity.y -= 1;
            }
            else
            {
                velocity.y = 0;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                velocity.x += 1;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                velocity.x -= 1;
            }
            else
            {
                velocity.x = 0;
            }
        }

        velocity.Normalize();

        Vector3 movement = new Vector3(velocity.x, 0, velocity.y) * Speed * Time.deltaTime;

        _rigidBody.velocity = Vector3.zero;
        _rigidBody.AddForce(movement);
    }
}
