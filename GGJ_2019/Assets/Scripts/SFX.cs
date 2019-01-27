using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;

    public void PlaySound(AudioClip clip)
    {
        if (clip != null)
            m_AudioSource.clip = clip;

        StartCoroutine(PlayAndDestroy(clip.length));
    }
	
	private IEnumerator PlayAndDestroy(float duration)
    {
        m_AudioSource.Play();

        yield return new WaitForSeconds(duration);

        Destroy(gameObject);
    }

    public void PlayRainLoop(AudioClip clip, float buildupDuration)
    {
        m_AudioSource.clip = clip;

        m_AudioSource.volume = 0;

        StartCoroutine(StartRainLoop(buildupDuration));
    }

    private IEnumerator StartRainLoop(float buildupDuration)
    {
        for (float timer = 0; timer <= buildupDuration; timer += Time.deltaTime)
        {
            m_AudioSource.volume = Mathf.Lerp(0, 1, timer);

            yield return null;
        }
    }
}
