using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private PlayerController owner;

    [SerializeField] private List<AudioClip> m_AudioClips;

    private AudioSource m_AudioSource;

	void Start ()
    {
        m_AudioSource = gameObject.GetComponent<AudioSource>();

        owner.AddItem(this);
	}
	
    public void Destroyed()
    {
        m_AudioSource.clip = m_AudioClips[Random.Range(0, m_AudioClips.Count)];
        m_AudioSource.Play();

        owner.RemoveItem(this);
    }
}
