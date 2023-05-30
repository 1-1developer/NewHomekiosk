using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class ScreenListen : MenuScreen
{
    const string NextButtonBig = "NextButtonBig";
    const string BackButtonBig = "BackButtonBig";
    const string PlayButton = "PlayButton";
    const string Playing = "playing";

    VisualElement m_Playing;

    bool isPlaying =true;

    Button m_NextButtonBig;
    Button m_BackButtonBig;
    Button m_PlayButton;
    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_Playing = m_Root.Q(Playing);
        m_NextButtonBig = m_Root.Q<Button>(NextButtonBig);
        m_BackButtonBig = m_Root.Q<Button>(BackButtonBig);
        m_PlayButton = m_Root.Q<Button>(PlayButton);
    }
    protected override void RegisterButtonCallbacks()
    {
        m_NextButtonBig?.RegisterCallback<ClickEvent>(ClickNextButtonBig);
        m_BackButtonBig?.RegisterCallback<ClickEvent>(ClickBackButtonBig);
        m_PlayButton?.RegisterCallback<ClickEvent>(ClickPlayButton);
    }
    private void ClickNextButtonBig(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_PlayButton.AddToClassList("ButtonPlay--pause");
        m_Playing.RemoveFromClassList("playing--pause");
        AudioManager.StopSound();
        m_MainMenuUIManager.ShowVideoScreen();
        isPlaying = true;
    }
    private void ClickBackButtonBig(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_PlayButton.AddToClassList("ButtonPlay--pause");
        m_Playing.RemoveFromClassList("playing--pause");
        AudioManager.StopSound();
        m_MainMenuUIManager.ShowSoundNoiseScreen();
        isPlaying = true;
    }

    private void ClickPlayButton(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        if (isPlaying)
        {
            m_PlayButton.RemoveFromClassList("ButtonPlay--pause");
            m_Playing.AddToClassList("playing--pause");
            AudioManager.PauseSound();
            isPlaying = false;
        }
        else
        {
            m_PlayButton.AddToClassList("ButtonPlay--pause");
            m_Playing.RemoveFromClassList("playing--pause");
            AudioManager.PlaySound();
            isPlaying = true;
        }
    }
}
