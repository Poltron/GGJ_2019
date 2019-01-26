using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private PlayerController owner;

    [SerializeField] private List<AudioClip> m_AudioClips;

    [SerializeField] private GameObject m_SFXPrefab;

	void Start ()
    {
        owner.AddItem(this);
	}
	
    public void Destroyed()
    {
        GameObject sfx = Instantiate(m_SFXPrefab);
        sfx.GetComponent<SFX>().PlaySound(m_AudioClips[Random.Range(0, m_AudioClips.Count)]);

        owner.RemoveItem(this);
    }
}
