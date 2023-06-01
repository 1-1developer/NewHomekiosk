using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class ScreenSoundNoise : MenuScreen
{
    const string DBButton = "dBButton";
    const string PlayingText2 = "playingText2";

    Button[] m_dBButtons = new Button[8];
    const string NextButton = "NextButton";
    Button m_NextButton;
    VisualElement m_PlayingText2;
    [SerializeField]
    Texture2D[] m_texts;

    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_NextButton = m_Root.Q<Button>(NextButton);
        m_PlayingText2 = m_Root.Q(PlayingText2);
        for (int i = 0; i < m_dBButtons.Length; i++)
        {
            m_dBButtons[i] = m_Root.Q<Button>(DBButton+$"{i}");
        }
    }
    protected override void RegisterButtonCallbacks()
    {
        m_dBButtons[0]?.RegisterCallback<ClickEvent>(evt =>playNoisesound(0));
        m_dBButtons[1]?.RegisterCallback<ClickEvent>(evt =>playNoisesound(1));
        m_dBButtons[2]?.RegisterCallback<ClickEvent>(evt =>playNoisesound(2));
        m_dBButtons[3]?.RegisterCallback<ClickEvent>(evt =>playNoisesound(3));
        m_dBButtons[4]?.RegisterCallback<ClickEvent>(evt =>playNoisesound(4));
        m_dBButtons[5]?.RegisterCallback<ClickEvent>(evt =>playNoisesound(5));
        m_dBButtons[6]?.RegisterCallback<ClickEvent>(evt =>playNoisesound(6));
        m_dBButtons[7]?.RegisterCallback<ClickEvent>(evt =>playNoisesound(7));
    }

    private void playNoisesound(int index)
    {
        m_NextButton.style.display = DisplayStyle.None;
        m_PlayingText2.style.backgroundImage = new StyleBackground(m_texts[index]);
        AudioManager.PlayDefaultButtonSound();
        AudioManager.SetNoiseButtonSound(index);
        m_MainMenuUIManager.ShowListenScreen();
    }
}
