using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class ScreenSoundNoise : MenuScreen
{

    const string SNScreen = "SNScreen";
    const string DecibelScreen = "DecibelScreen";
    const string NoiseScreen = "NoiseScreen";
    const string AirGroup = "AirGroup";
    const string DirectGroup = "DirectGroup";

    const string NextButton = "NextButton";
    const string BackButton = "BackButton";
    const string DirectButton = "DirectButton";
    const string AirButton = "AirButton";
    const string SNButton = "SNButton";

    const string DBButton = "dBButton";
    const string NoiseButton = "NoiseButton";

    VisualElement m_SNScreen;
    VisualElement m_DecibelScreen;
    VisualElement m_NoiseScreen;
    VisualElement m_AirGroup;
    VisualElement m_DirectGroup;

    Button m_NextButton;
    Button m_BackButton;
    Button m_DirectButton;
    Button m_AirButton;
    Button m_SNButton;

    Button[] m_dBButtons = new Button[8];
    Button[] m_NoiseButtons = new Button[4];

    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_BackButton = m_Root.Q<Button>(BackButton);
        m_NextButton = m_Root.Q<Button>(NextButton);
        m_DirectButton = m_Root.Q<Button>(DirectButton);
        m_AirButton = m_Root.Q<Button>(AirButton);
        m_SNButton = m_Root.Q<Button>(SNButton);

        m_SNScreen = m_Root.Q(SNScreen);
        m_DecibelScreen = m_Root.Q(DecibelScreen);
        m_NoiseScreen = m_Root.Q(NoiseScreen);

        m_AirGroup = m_Root.Q(AirGroup);
        m_DirectGroup = m_Root.Q(DirectGroup);


        for (int i = 0; i < m_dBButtons.Length; i++)
        {
            m_dBButtons[i] = m_Root.Q<Button>(DBButton+$"{i}");
        }
        for (int i = 0; i < m_NoiseButtons.Length; i++)
        {
            m_NoiseButtons[i] = m_Root.Q<Button>(NoiseButton + $"{i}");
        }
    }
    protected override void RegisterButtonCallbacks()
    {
        m_BackButton?.RegisterCallback<ClickEvent>(ClickBackButton);
        m_NextButton?.RegisterCallback<ClickEvent>(ClickNextButton);
        m_DirectButton?.RegisterCallback<ClickEvent>(ClickDirectButton);
        m_AirButton?.RegisterCallback<ClickEvent>(ClickAirButton);
        m_SNButton?.RegisterCallback<ClickEvent>(ClickSNButton);

        m_dBButtons[0]?.RegisterCallback<ClickEvent>(evt =>playNoisesound(0));
        m_dBButtons[1]?.RegisterCallback<ClickEvent>(evt =>playNoisesound(1));
        m_dBButtons[2]?.RegisterCallback<ClickEvent>(evt =>playNoisesound(2));
        m_dBButtons[3]?.RegisterCallback<ClickEvent>(evt =>playNoisesound(3));
        m_dBButtons[4]?.RegisterCallback<ClickEvent>(evt =>playNoisesound(4));
        m_dBButtons[5]?.RegisterCallback<ClickEvent>(evt =>playNoisesound(5));
        m_dBButtons[6]?.RegisterCallback<ClickEvent>(evt =>playNoisesound(6));
        m_dBButtons[7]?.RegisterCallback<ClickEvent>(evt =>playNoisesound(7));

        m_NoiseButtons[0]?.RegisterCallback<ClickEvent>(evt => playNoisesound(8));
        m_NoiseButtons[1]?.RegisterCallback<ClickEvent>(evt => playNoisesound(9));
        m_NoiseButtons[2]?.RegisterCallback<ClickEvent>(evt => playNoisesound(10));
        m_NoiseButtons[3]?.RegisterCallback<ClickEvent>(evt => playNoisesound(11));
    }

    private void ClickBackButton(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();

        if(m_DecibelScreen.style.display == DisplayStyle.Flex)
        {
            m_AirButton.RemoveFromClassList("ButtonAir--hold");
            m_AirButton.style.display = DisplayStyle.Flex;
            m_DecibelScreen.style.display = DisplayStyle.None;
            m_SNButton.style.display = DisplayStyle.None;
        }
        else
        {
            m_MainMenuUIManager.ShowtwoScreen();
            m_SNButton.style.display = DisplayStyle.None;
            m_AirButton.RemoveFromClassList("ButtonAir--hold");
            m_AirButton.style.display = DisplayStyle.Flex;
            m_DirectButton.style.display = DisplayStyle.Flex;
        }

    }
    private void ClickNextButton(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_DecibelScreen.style.display = DisplayStyle.Flex;
    }
    private void ClickSNButton(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_NoiseScreen.style.display = DisplayStyle.None;
        m_SNButton.style.display = DisplayStyle.None;
        m_DecibelScreen.style.display = DisplayStyle.None;
        m_SNScreen.style.display = DisplayStyle.Flex;
        m_AirButton.RemoveFromClassList("ButtonAir--hold");
        m_AirButton.style.display = DisplayStyle.Flex;
        m_DirectButton.style.display = DisplayStyle.Flex;
    }
    private void ClickDirectButton(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_SNButton.style.display = DisplayStyle.Flex;
        m_AirGroup.style.display = DisplayStyle.None;
        m_DecibelScreen.style.display = DisplayStyle.None;
        m_DirectGroup.style.display = DisplayStyle.Flex;
        m_AirButton.style.display = DisplayStyle.Flex;
        m_AirButton.AddToClassList("ButtonAir--hold");
        m_DirectButton.style.display = DisplayStyle.None;
        m_NoiseScreen.style.display = DisplayStyle.Flex;
    }
    private void ClickAirButton(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_SNButton.style.display = DisplayStyle.Flex;
        m_DirectGroup.style.display = DisplayStyle.None;
        m_DecibelScreen.style.display = DisplayStyle.None;
        m_AirGroup.style.display = DisplayStyle.Flex;
        m_DirectButton.style.display = DisplayStyle.Flex;
        m_AirButton.style.display = DisplayStyle.None;
        m_NoiseScreen.style.display = DisplayStyle.Flex;
    }
    private void playNoisesound(int index)
    {
        AudioManager.PlayDefaultButtonSound();
        AudioManager.PlayNoiseButtonSound(index);
        m_MainMenuUIManager.ShowListenScreen();
    }
}
