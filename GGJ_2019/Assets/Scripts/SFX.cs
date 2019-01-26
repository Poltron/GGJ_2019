using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;

    public void PlaySound(AudioClip clip)
    {
        m_AudioSource.clip = clip;

        StartCoroutine(PlayAndDestroy(clip.length));
    }
	
	private IEnumerator PlayAndDestroy(float duration)
    {
        m_AudioSource.Play();

        yield return new WaitForSeconds(duration);

        Destroy(gameObject);
    }
}
