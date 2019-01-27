using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotSFX : MonoBehaviour
{
    private AudioSource m_AudioSource;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        m_AudioSource = GetComponent<AudioSource>();

        StartCoroutine(DestroyAfterPlay());
    }

	IEnumerator DestroyAfterPlay()
    {
        yield return new WaitForSeconds(m_AudioSource.clip.length);

        Destroy(gameObject);
    }
}
