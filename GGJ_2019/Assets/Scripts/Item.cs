using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private PlayerController owner;

    [SerializeField] private List<AudioClip> m_AudioClips;

    [SerializeField] private GameObject m_ItemSFXPrefab;
    [SerializeField] private Animator m_LightAnimator;
    [SerializeField] private Light m_LightFX;
    [SerializeField] private ParticleSystem m_LifeFX;
    [SerializeField] private ParticleSystem m_EndFX;

    private bool m_IsAlive = true;

	void Start ()
    {
        owner.AddItem(this);
	}
	
    public void SetLastItem()
    {
        m_LightAnimator.SetTrigger("LastItem");
    }

    public void Destroyed()
    {
        if (!m_IsAlive)
            return;

        m_IsAlive = false;

        if (m_ItemSFXPrefab)
        {
            GameObject sfx = Instantiate(m_ItemSFXPrefab);
            sfx.GetComponent<SFX>().PlaySound(m_AudioClips[Random.Range(0, m_AudioClips.Count)]);
        }

        m_LightFX.enabled = false;
        m_LifeFX.Stop();
        Instantiate(m_EndFX, transform.position, transform.rotation);

        owner.RemoveItem(this);
    }
}
