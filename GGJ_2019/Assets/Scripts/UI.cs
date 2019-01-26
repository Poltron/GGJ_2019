using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject m_StartCanvas;
    [SerializeField] private GameObject m_GameCanvas;
    [SerializeField] private GameObject m_PauseCanvas;
    [SerializeField] private GameObject m_EndCanvas;

    [Space]
    [SerializeField] private Text m_PlayerWinner;

    void Start ()
    {
        ResetScreen();
	}

    public void ResetScreen()
    {
        m_GameCanvas.SetActive(false);
        m_PauseCanvas.SetActive(false);
        m_EndCanvas.SetActive(false);

        m_StartCanvas.SetActive(true);
    }

    public void DisplayGameCanvas()
    {
        m_StartCanvas.SetActive(false);

        m_GameCanvas.SetActive(true);
    }

    public void DisplayEndCanvas()
    {
        m_GameCanvas.SetActive(false);

        m_EndCanvas.SetActive(true);
    }

    public void ShowHidePauseCanvas()
    {
        m_PauseCanvas.SetActive(!m_PauseCanvas.activeSelf);
    }

    public void WinnerWinnerChickenDinner(string player, string color)
    {
        m_PlayerWinner.text = player + " (" + color + ") WON !";
    }
}
