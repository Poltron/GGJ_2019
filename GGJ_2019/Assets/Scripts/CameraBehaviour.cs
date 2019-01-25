using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform ToFollow;

	void Start ()
    {
	}
	
	void LateUpdate ()
    {
        transform.position = new Vector3(ToFollow.position.x, transform.position.y, ToFollow.position.z);
	}
}
