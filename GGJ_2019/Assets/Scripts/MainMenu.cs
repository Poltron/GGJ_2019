using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameMusic m_GameMusic;

    [SerializeField]
    private GameObject m_LaunchSFX;

    void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            Instantiate(m_LaunchSFX);

            m_GameMusic.SwitchToGameMusic();

            SceneManager.LoadScene("LD1Launch");
        }
	}
}
