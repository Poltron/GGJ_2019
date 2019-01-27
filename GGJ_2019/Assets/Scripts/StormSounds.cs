using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormSounds : MonoBehaviour
{
    [SerializeField] private GameObject m_LigthSwitchSFXPrefab;
    [SerializeField] private GameObject m_ThunderSFXPrefab;
    [SerializeField] private GameObject m_RainSFXPrefab;


    [SerializeField] private List<AudioClip> m_LightSwitchAudioClips;
    [SerializeField] private List<AudioClip> m_ThunderAudioClips;

    [SerializeField] private AudioClip m_RainAudioClip;

    [SerializeField] private float m_RainBuildupDuration = 1;

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

    public void PlayRainSound()
    {
        if (m_RainSFXPrefab)
        {
            GameObject sfx = Instantiate(m_RainSFXPrefab);
            sfx.GetComponent<SFX>().PlayRainLoop(m_RainAudioClip, m_RainBuildupDuration);
        }
    }
}
