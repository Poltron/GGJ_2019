﻿using System.Collections;
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
    [SerializeField] private Button m_PlayButton;

    void Start ()
    {
        ResetScreen();

        m_PlayButton.onClick.AddListener(ShowHidePauseCanvas);
	}
	
	void Update ()
    {
		
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
}
