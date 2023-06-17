using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class ScreenListen : MenuScreen
{
    const string ListenScreen = "ListenScreen";

    const string PlayButton = "PlayButton";
    const string Playing = "playing";
    const string PlayingText = "playingText";
    const string PlayingText2 = "playingText2";

    VisualElement m_Playing;
    VisualElement m_PlayingText;
    VisualElement m_PlayingText2;
    VisualElement m_ListenScreen;

    bool isPlaying =true;

    Button m_PlayButton;
    Button m_StartListenButton;
    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_Playing = m_Root.Q(Playing);
        m_PlayingText = m_Root.Q(PlayingText);
        m_PlayingText2 = m_Root.Q(PlayingText2);

 
        m_ListenScreen = m_Root.Q(ListenScreen);
        m_PlayButton = m_Root.Q<Button>(PlayButton);
    }
    protected override void RegisterButtonCallbacks()
    {
        m_PlayButton?.RegisterCallback<ClickEvent>(ClickPlayButton);

    }
    private void ClickPlayButton(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        if (isPlaying)
        {
            m_PlayButton.RemoveFromClassList("ButtonPlay--pause");
            m_Playing.AddToClassList("playing--pause");
            m_PlayingText.AddToClassList("playingText--fade");
            m_PlayingText2.AddToClassList("playingText--fade");
            AudioManager.PauseSound();
            isPlaying = false;
        }
        else
        {
            m_PlayButton.AddToClassList("ButtonPlay--pause");
            m_Playing.RemoveFromClassList("playing--pause");
            m_PlayingText.RemoveFromClassList("playingText--fade");
            m_PlayingText2.RemoveFromClassList("playingText--fade");
            AudioManager.PlaySound();
            isPlaying = true;
        }
    }
}
