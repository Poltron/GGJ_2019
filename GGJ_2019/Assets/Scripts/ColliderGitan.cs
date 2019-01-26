using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderGitan : MonoBehaviour
{
	void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 10.0f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (other.tag == "Item")
        {
            Destroy(other.gameObject);
        }
    }
}
