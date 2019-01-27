using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private GameObject m_PlayerDeathSFXPrefab;

    [SerializeField] private List<AudioClip> m_PlayerDeathAudioClips;

    public void PlayPlayerDeathSound()
    {
        if (m_PlayerDeathSFXPrefab)
        {
            GameObject sfx = Instantiate(m_PlayerDeathSFXPrefab);
            sfx.GetComponent<SFX>().PlaySound(m_PlayerDeathAudioClips[Random.Range(0, m_PlayerDeathAudioClips.Count)]);
        }
    }
}
