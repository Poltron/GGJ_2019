using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormSounds : MonoBehaviour
{
    [SerializeField] private GameObject m_LigthSwitchSFXPrefab;

    [SerializeField] private List<AudioClip> m_LightSwitchAudioClips;

	public void PlayLightSwitchSound()
    {
        if (m_LigthSwitchSFXPrefab)
        {
            GameObject sfx = Instantiate(m_LigthSwitchSFXPrefab);
            sfx.GetComponent<SFX>().PlaySound(m_LightSwitchAudioClips[Random.Range(0, m_LightSwitchAudioClips.Count)]);
        }
    }
}
