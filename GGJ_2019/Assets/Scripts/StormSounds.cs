using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormSounds : MonoBehaviour
{
    [SerializeField] private GameObject m_LigthSwitchSFXPrefab;
    [SerializeField] private GameObject m_ThunderSFXPrefab;

    [SerializeField] private List<AudioClip> m_LightSwitchAudioClips;
    [SerializeField] private List<AudioClip> m_ThunderAudioClips;

    public void PlayLightSwitchSound()
    {
        if (m_LigthSwitchSFXPrefab)
        {
            GameObject sfx = Instantiate(m_LigthSwitchSFXPrefab);
            sfx.GetComponent<SFX>().PlaySound(m_LightSwitchAudioClips[Random.Range(0, m_LightSwitchAudioClips.Count)]);
        }
    }

    public void PlayThunderSound()
    {
        if (m_ThunderSFXPrefab)
        {
            GameObject sfx = Instantiate(m_ThunderSFXPrefab);
            sfx.GetComponent<SFX>().PlaySound(m_ThunderAudioClips[Random.Range(0, m_ThunderAudioClips.Count)]);
        }
    }
}
