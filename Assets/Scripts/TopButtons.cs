using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class TopButtons : MenuScreen
{
    const string NextButton = "NextButton";
    const string BackButton = "BackButton";
    const string DirectButton = "DirectButton";
    const string AirButton = "AirButton";
    const string SNButton = "SNButton";

    const string ListenStartScreen = "ListenStartScreen";
    const string ListenScreen = "ListenScreen";
    const string ScreenListen = "ScreenListen";

    const string ToStartButton = "HomeButton";

    Button m_NextButton;
    Button m_BackButton;
    Button m_DirectButton;
    Button m_AirButton;
    Button m_SNButton;

    Button m_ToStartButton;
    VisualElement m_ListenStartScreen;
    VisualElement m_ListenScreen;
    VisualElement m_ScreenListen;

    List<VisualElement> m_Tscreens = new List<VisualElement>();
    List<VisualElement> m_Sscreens = new List<VisualElement>();
    List<VisualElement> m_Pscreens = new List<VisualElement>();
    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        m_BackButton = m_Root.Q<Button>(BackButton);
        m_NextButton = m_Root.Q<Button>(NextButton);
        m_DirectButton = m_Root.Q<Button>(DirectButton);
        m_AirButton = m_Root.Q<Button>(AirButton);
        m_SNButton = m_Root.Q<Button>(SNButton);

        m_ToStartButton = m_Root.Q<Button>(ToStartButton);

        m_Tscreens.Add(m_Root.Q("NoiseScreen0"));
        m_Tscreens.Add(m_Root.Q("NoiseScreen1"));

        m_Sscreens.Add(m_Root.Q("SNScreen"));
        m_Sscreens.Add(m_Root.Q("DecibelScreen"));

        m_Pscreens.Add(m_Root.Q("PreventionScreen0"));
        m_Pscreens.Add(m_Root.Q("PreventionScreen1"));
        m_Pscreens.Add(m_Root.Q("PreventionScreen2"));

        m_ListenStartScreen = m_Root.Q(ListenStartScreen);
        m_ListenScreen = m_Root.Q(ListenScreen);
        m_ScreenListen = m_Root.Q(ScreenListen);
    }
    protected override void RegisterButtonCallbacks()
    {
        m_ToStartButton?.RegisterCallback<ClickEvent>(ClickToStartButton);

        m_BackButton?.RegisterCallback<ClickEvent>(ClickBackButton);
        m_NextButton?.RegisterCallback<ClickEvent>(ClickNextButton);
        m_DirectButton?.RegisterCallback<ClickEvent>(ClickDirectButton);
        m_AirButton?.RegisterCallback<ClickEvent>(ClickAirButton);
        m_SNButton?.RegisterCallback<ClickEvent>(ClickSNButton);
    }
    private void ClickBackButton(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        if (m_ScreenListen.style.display == DisplayStyle.Flex)
        {
            if (m_ListenScreen.style.display == DisplayStyle.Flex)
            {
                AudioManager.StopSound();
                ShowVisualElement(m_ListenScreen, false);
                ShowVisualElement(m_ListenStartScreen, true);
                return;
            }
            switch (m_MainMenuUIManager.pre_menuindex)
            {
                case 0:
                    ShowPage(m_Tscreens[1], m_Tscreens);
                    setNextBt(1, 1);
                    m_MainMenuUIManager.ShowTypeofNoiseScreen();
                    m_MainMenuUIManager.currentPageIndex = 1;
                    break;
                case 1:
                    ShowPage(m_Sscreens[1], m_Sscreens);
                    setNextBt(1, 1);
                    m_MainMenuUIManager.ShowSoundNoiseScreen();
                    m_MainMenuUIManager.currentPageIndex = 1;
                    break;
                case 2:
                    ShowPage(m_Pscreens[2], m_Pscreens);
                    setNextBt(2, 2);
                    m_MainMenuUIManager.ShowPreventionNoise();
                    m_MainMenuUIManager.currentPageIndex = 2;
                    break;
                default:
                    break;
            }
            AudioManager.StopSound();
            ShowVisualElement(m_ListenScreen, false);
            ShowVisualElement(m_ListenStartScreen, true);
            return;
        }
        m_NextButton.style.display = DisplayStyle.Flex;
        m_MainMenuUIManager.currentPageIndex--;
        UpdatePageNavigation(m_MainMenuUIManager.menuindex, m_MainMenuUIManager.currentPageIndex);


        AudioManager.StopSound();
    }
    private void ClickNextButton(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_MainMenuUIManager.currentPageIndex++;
        UpdatePageNavigation(m_MainMenuUIManager.menuindex, m_MainMenuUIManager.currentPageIndex);
    }


    private void ClickSNButton(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_MainMenuUIManager.ShowSoundNoiseScreen();
        m_NextButton.style.display = DisplayStyle.Flex;
        UpdatePageNavigation(m_MainMenuUIManager.menuindex, m_MainMenuUIManager.currentPageIndex);
        ShowVisualElement(m_ListenScreen, false);
        ShowVisualElement(m_ListenStartScreen, true);
        AudioManager.StopSound();
    }
    private void ClickDirectButton(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_MainMenuUIManager.ShowPreventionNoise();
        m_NextButton.style.display = DisplayStyle.Flex;
        UpdatePageNavigation(m_MainMenuUIManager.menuindex, m_MainMenuUIManager.currentPageIndex);
        ShowVisualElement(m_ListenScreen, false);
        ShowVisualElement(m_ListenStartScreen, true);
        AudioManager.StopSound();

    }
    private void ClickAirButton(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_MainMenuUIManager.ShowTypeofNoiseScreen();
        m_NextButton.style.display = DisplayStyle.Flex;
        UpdatePageNavigation(m_MainMenuUIManager.menuindex, m_MainMenuUIManager.currentPageIndex);
        ShowVisualElement(m_ListenScreen, false);
        ShowVisualElement(m_ListenStartScreen, true);
        AudioManager.StopSound();
    }

    private void ClickToStartButton(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_MainMenuUIManager.ShowHomeScreen();
        m_MainMenuUIManager.menuindex = -1;
        m_NextButton.style.display = DisplayStyle.Flex;
        UpdatePageNavigation(0, m_MainMenuUIManager.currentPageIndex);
        UpdatePageNavigation(1, m_MainMenuUIManager.currentPageIndex);
        UpdatePageNavigation(2, m_MainMenuUIManager.currentPageIndex);
        ShowVisualElement(m_ListenScreen, false);
        ShowVisualElement(m_ListenStartScreen, true);
        m_MainMenuUIManager.HideTopbar();
        AudioManager.StopSound();
    }

    private void UpdatePageNavigation(int menuindex, int pageindex)
    {
        if (pageindex <0)
        {
            m_MainMenuUIManager.ShowtwoScreen();
            m_MainMenuUIManager.HideTopbar();
            return;
        }
        switch (menuindex)
        {
            case 0:
                ShowPage( m_Tscreens[pageindex],m_Tscreens);
                setNextBt(pageindex, 1);
                break;
            case 1:
                ShowPage(m_Sscreens[pageindex], m_Sscreens);
                setNextBt(pageindex, 1);
                break;
            case 2:
                ShowPage(m_Pscreens[pageindex], m_Pscreens);
                setNextBt(pageindex, 2);
                break;
            default:
                break;
        }
    }
    void setNextBt(int pageindex,int MaxPage)
    {
        if (pageindex > MaxPage-1)
            m_NextButton.style.display = DisplayStyle.None;
        else
            m_NextButton.style.display = DisplayStyle.Flex;
    }

    void ShowPage(VisualElement v, List<VisualElement> l)
    {
        foreach (VisualElement m in l)
        {
            if (m == v)
            {
                ShowVisualElement(m, true);
            }
            else
            {
                ShowVisualElement(m, false);
            }
        }
    }
}
