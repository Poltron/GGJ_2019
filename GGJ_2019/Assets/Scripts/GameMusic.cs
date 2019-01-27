using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    [SerializeField] private AudioSource m_MenuAudioSource;
    [SerializeField] private AudioSource m_GameAudioSource;

    [SerializeField] private float m_FadeDuration;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SwitchToGameMusic()
    {
        StartCoroutine("FadeToGame");
    }

    private IEnumerator FadeToGame()
    {
        StartCoroutine(FadeOut());

        yield return new WaitForSeconds(m_FadeDuration / 3);

        if (!m_GameAudioSource.isPlaying)
            m_GameAudioSource.Play();

        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeOut()
    {
        for (float timer = 0; timer < m_FadeDuration; timer += Time.deltaTime)
        {
            m_MenuAudioSource.volume = Mathf.Lerp(1, 0, timer / m_FadeDuration);

            yield return null;
        }
    }

    private IEnumerator FadeIn()
    {
        for (float timer = 0; timer < m_FadeDuration; timer += Time.deltaTime)
        {
            m_GameAudioSource.volume = Mathf.Lerp(0, 1, timer / m_FadeDuration);

            yield return null;
        }
    }
}
