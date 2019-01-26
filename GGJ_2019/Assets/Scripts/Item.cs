using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private PlayerController owner;

	void Start ()
    {
        owner.AddItem(this);
	}
	
    public void Destroyed()
    {
        owner.RemoveItem(this);
    }
}
