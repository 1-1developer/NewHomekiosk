using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;


public class TwoMenuScreen : MenuScreen
{
    const string twoSc = "Two";

    const string Typebt = "TypeButton01";
    const string Typebt2 = "TypeButton02";

    const string NoiseScreen = "NoiseScreen";

    const string DirectButton = "DirectButton";
    const string AirButton = "AirButton";
    const string SNButton = "SNButton";

    const string AirGroup = "AirGroup";
    const string DirectGroup = "DirectGroup";

    // Start is called before the first frame update
    VisualElement TwoSc;
    VisualElement m_NoiseScreen;

    Button m_TypeButton;
    Button m_TypeButton02;

    Button m_DirectButton;
    Button m_AirButton;
    Button m_SNButton;

    VisualElement m_AirGroup;
    VisualElement m_DirectGroup;
    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        TwoSc = m_Root.Q(twoSc);
        m_NoiseScreen = m_Root.Q(NoiseScreen);

        m_TypeButton = m_Root.Q<Button>(Typebt);
        m_TypeButton02 = m_Root.Q<Button>(Typebt2);

        m_DirectButton = m_Root.Q<Button>(DirectButton);
        m_AirButton = m_Root.Q<Button>(AirButton);
        m_SNButton = m_Root.Q<Button>(SNButton);

        m_AirGroup = m_Root.Q(AirGroup);
        m_DirectGroup = m_Root.Q(DirectGroup);
    }
    protected override void RegisterButtonCallbacks()
    {
        m_TypeButton?.RegisterCallback<ClickEvent>(ClickTypeButton);
        m_TypeButton02?.RegisterCallback<ClickEvent>(ClickTypeButton2);
    }

    private void ClickTypeButton(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_MainMenuUIManager.ShowSoundNoiseScreen();
        m_NoiseScreen.style.display = DisplayStyle.Flex;
        m_SNButton.style.display = DisplayStyle.Flex;
        m_AirGroup.style.display = DisplayStyle.None;
        m_DirectGroup.style.display = DisplayStyle.Flex;
        m_AirButton.style.display = DisplayStyle.Flex;
        m_AirButton.AddToClassList("ButtonAir--hold");
        m_DirectButton.style.display = DisplayStyle.None;
    }
    private void ClickTypeButton2(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_MainMenuUIManager.ShowSoundNoiseScreen();
        m_NoiseScreen.style.display = DisplayStyle.None;

    }
}
