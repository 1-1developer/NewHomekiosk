using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class TopButtons : MenuScreen
{
    const string NextButton = "NextButton";
    const string BackButton = "BackButton";
    const string learnButton = "topmuButton0";
    const string noiseButton = "topmuButton1";
    const string prevButton = "topmuButton2";

    const string ListenScreen = "ListenScreen";
    const string ScreenListen = "ScreenListen";

    const string ToStartButton = "HomeButton";

    Button m_NextButton;
    Button m_BackButton;

    Button m_PrevButton;
    Button m_NoiseButton;
    Button m_LearnButton;
    Button m_ToStartButton;

    List<Button> m_dbGroup = new List<Button>();

    VisualElement m_ListenScreen;
    VisualElement m_ScreenListen;

    List<VisualElement> m_Tscreens = new List<VisualElement>();
    List<VisualElement> m_Sscreens = new List<VisualElement>();
    List<VisualElement> m_Pscreens = new List<VisualElement>();

    Button[] m_topbuttons = new Button[3];

    int tpageIndex;
    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        m_BackButton = m_Root.Q<Button>(BackButton);
        m_NextButton = m_Root.Q<Button>(NextButton);
        m_PrevButton = m_Root.Q<Button>(prevButton);
        m_NoiseButton = m_Root.Q<Button>(noiseButton);
        m_LearnButton = m_Root.Q<Button>(learnButton);

        m_ToStartButton = m_Root.Q<Button>(ToStartButton);

        //층간소음 체험하기
        m_Tscreens.Add(m_Root.Q("DecibelScreen"));
        m_Tscreens.Add(m_Root.Q("NoiseScreen0"));
        m_Tscreens.Add(m_Root.Q("NoiseScreen1"));

        //층간소음 알아보기
        m_Sscreens.Add(m_Root.Q("iScreen0"));
        m_Sscreens.Add(m_Root.Q("iScreen1"));
        m_Sscreens.Add(m_Root.Q("iScreen2"));

        //비디오
        m_Pscreens.Add(m_Root.Q("PreventionScreen"));

        m_ListenScreen = m_Root.Q(ListenScreen);
        m_ScreenListen = m_Root.Q(ScreenListen);

        m_topbuttons[0] = m_LearnButton;
        m_topbuttons[1] = m_NoiseButton;
        m_topbuttons[2] = m_PrevButton;

        for (int i = 0; i < 7; i++)
        {
            m_dbGroup.Add(m_Root.Q<Button>($"dBButton{i}"));
        }
    }
    protected override void RegisterButtonCallbacks()
    {
        m_ToStartButton?.RegisterCallback<ClickEvent>(ClickToStartButton);

        m_BackButton?.RegisterCallback<ClickEvent>(ClickBackButton);
        m_NextButton?.RegisterCallback<ClickEvent>(ClickNextButton);
        m_LearnButton?.RegisterCallback<ClickEvent>(ClicklearnButton);
        m_NoiseButton?.RegisterCallback<ClickEvent>(ClickNoiseButton);
        m_PrevButton?.RegisterCallback<ClickEvent>(ClickPrevButton);
    }
    private void ClickBackButton(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        if (m_ScreenListen.style.display == DisplayStyle.Flex)
        {
            AudioManager.StopSound();
            ShowPage(m_Tscreens[tpageIndex], m_Tscreens);
            setNextBt(tpageIndex, 2);
            m_MainMenuUIManager.ShowTypeofNoiseScreen();
            m_MainMenuUIManager.currentPageIndex = tpageIndex;
            return;
        }
        m_NextButton.style.display = DisplayStyle.Flex;
        m_MainMenuUIManager.currentPageIndex--;
        UpdatePageNavigation(m_MainMenuUIManager.menuindex, m_MainMenuUIManager.currentPageIndex);
        AudioManager.StopSound();
        initDB();
    }
    private void ClickNextButton(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_MainMenuUIManager.currentPageIndex++;
        UpdatePageNavigation(m_MainMenuUIManager.menuindex, m_MainMenuUIManager.currentPageIndex);
        AudioManager.StopSound();
        initDB();
    }
    private void ClicklearnButton(ClickEvent evt)//층간소음 배우기 1
    {
        AudioManager.PlayDefaultButtonSound();
        m_MainMenuUIManager.ShowSoundNoiseScreen(); setBtEnable(0);
        m_NextButton.style.display = DisplayStyle.Flex;
        UpdatePageNavigation(m_MainMenuUIManager.menuindex, m_MainMenuUIManager.currentPageIndex);
        AudioManager.StopSound();
    }

    private void ClickNoiseButton(ClickEvent evt)//소음소리 체험 2
    {
        AudioManager.PlayDefaultButtonSound();
        m_MainMenuUIManager.ShowTypeofNoiseScreen(); setBtEnable(1);
        m_NextButton.style.display = DisplayStyle.Flex;
        UpdatePageNavigation(m_MainMenuUIManager.menuindex, m_MainMenuUIManager.currentPageIndex);
        AudioManager.StopSound();
    }
    private void ClickPrevButton(ClickEvent evt)//예방 3
    {
        AudioManager.PlayDefaultButtonSound();
        m_MainMenuUIManager.ShowPreventionNoise(); setBtEnable(2);
        m_NextButton.style.display = DisplayStyle.Flex;
        UpdatePageNavigation(m_MainMenuUIManager.menuindex, m_MainMenuUIManager.currentPageIndex);
        AudioManager.StopSound();
    }


    private void ClickToStartButton(ClickEvent evt)//처음으로 버튼
    {
        AudioManager.PlayDefaultButtonSound();
        m_MainMenuUIManager.ShowHomeScreen();
        m_MainMenuUIManager.menuindex = -1;
        UpdatePageNavigation(0, 0);
        UpdatePageNavigation(1, 0);
        UpdatePageNavigation(2, 0);
        m_MainMenuUIManager.HideTopbar();
        setBtall();
        AudioManager.StopSound();
        initDB();
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
                ShowPage(m_Sscreens[pageindex], m_Sscreens);
                setNextBt(pageindex, 2);
                break;
            case 1:
                ShowPage( m_Tscreens[pageindex],m_Tscreens);
                setNextBt(pageindex, 2);
                tpageIndex = pageindex;
                break;
            case 2:
                ShowPage(m_Pscreens[pageindex], m_Pscreens);
                setNextBt(pageindex, 0);
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

    public void setBtEnable(int i)
    {
        Button b = m_topbuttons[i];
        foreach (Button bb in m_topbuttons)
        {
            if (b==bb)
            {
                bb.SetEnabled(false);
                Debug.Log($"{b.name} fade");
            }
            else
            {
                bb.SetEnabled(true);
            }
        }
    }
    public void setBtall()
    {
        for (int i = 0; i < m_topbuttons.Length; i++)
        {
            m_topbuttons[i]?.SetEnabled(true);
        }
    }
    void initDB()
    {
        for (int i = 0; i < m_dbGroup.Count; i++)
        {
            m_dbGroup[i].RemoveFromClassList("dBButton--playing");
        }
    }
}
