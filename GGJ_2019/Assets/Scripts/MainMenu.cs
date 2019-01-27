using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameMusic m_GameMusic;
	
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            m_GameMusic.SwitchToGameMusic();

            SceneManager.LoadScene("LD1Launch");
        }
	}
}
