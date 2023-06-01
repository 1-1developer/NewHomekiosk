using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class ScreenTypeofNoise : MenuScreen
{
    const string NoiseScreen = "NoiseScreen";

    const string NoiseButton = "noiseButton";
    const string fNoiseButton = "fnoiseButton";

    const string NextButton = "NextButton";
    const string PlayingText2 = "playingText2";


    [SerializeField]
    Texture2D[] m_texts;

    Button m_NextButton;
    VisualElement m_NoiseScreen;
    VisualElement m_NoiseScreen2;
    VisualElement m_PlayingText2;

    Button[] m_NoiseButtons = new Button[4];
    Button[] m_fNoiseButtons = new Button[6];

    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        m_NoiseScreen = m_Root.Q(NoiseScreen+"0");
        m_NoiseScreen2 = m_Root.Q(NoiseScreen+"1");
        m_PlayingText2 = m_Root.Q(PlayingText2);

        for (int i = 0; i < m_NoiseButtons.Length; i++)
        {
            m_NoiseButtons[i] = m_Root.Q<Button>(NoiseButton + $"{i}");
        }
        for (int i = 0; i < m_fNoiseButtons.Length; i++)
        {
            m_fNoiseButtons[i] = m_Root.Q<Button>(fNoiseButton + $"{i}");
        }
        m_NextButton = m_Root.Q<Button>(NextButton);
    }
    protected override void RegisterButtonCallbacks()
    {
        m_NoiseButtons[0]?.RegisterCallback<ClickEvent>(evt => playNoisesound(8));
        m_NoiseButtons[1]?.RegisterCallback<ClickEvent>(evt => playNoisesound(9));
        m_NoiseButtons[2]?.RegisterCallback<ClickEvent>(evt => playNoisesound(10));
        m_NoiseButtons[3]?.RegisterCallback<ClickEvent>(evt => playNoisesound(11));

        m_fNoiseButtons[0]?.RegisterCallback<ClickEvent>(evt => playNoisesound(12));
        m_fNoiseButtons[1]?.RegisterCallback<ClickEvent>(evt => playNoisesound(13));
        m_fNoiseButtons[2]?.RegisterCallback<ClickEvent>(evt => playNoisesound(14));
        m_fNoiseButtons[3]?.RegisterCallback<ClickEvent>(evt => playNoisesound(15));
        m_fNoiseButtons[4]?.RegisterCallback<ClickEvent>(evt => playNoisesound(16));
        m_fNoiseButtons[5]?.RegisterCallback<ClickEvent>(evt => playNoisesound(17));
    }


   
    private void playNoisesound(int index)
    {
        m_NextButton.style.display = DisplayStyle.None;
        m_PlayingText2.style.backgroundImage = m_texts[index-8];
        AudioManager.PlayDefaultButtonSound();
        AudioManager.SetNoiseButtonSound(index);
        m_MainMenuUIManager.ShowListenScreen();
    }
}
