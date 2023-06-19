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

    const string PlayButton = "PlayButton";
    const string Playing = "playing";
    const string PlayingText = "playingText";
    const string PlayingText2 = "playingText2";

    Button m_NextButton;
    Button m_BackButton;

    Button m_PrevButton;
    Button m_NoiseButton;
    Button m_LearnButton;
    Button m_ToStartButton;

    List<Button> m_dbGroup = new List<Button>();

    //헤드폰 스크린
    VisualElement m_ListenScreen;
    VisualElement m_ScreenListen;
    VisualElement m_Playing;
    VisualElement m_PlayingText;
    VisualElement m_PlayingText2;
    Button m_PlayButton;


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

        //�������� ü���ϱ�
        m_Tscreens.Add(m_Root.Q("DecibelScreen"));
        m_Tscreens.Add(m_Root.Q("NoiseScreen0"));
        m_Tscreens.Add(m_Root.Q("NoiseScreen1"));

        //�������� �˾ƺ���
        m_Sscreens.Add(m_Root.Q("iScreen0"));
        m_Sscreens.Add(m_Root.Q("iScreen1"));
        m_Sscreens.Add(m_Root.Q("iScreen2"));

        //����
        m_Pscreens.Add(m_Root.Q("PreventionScreen"));

        m_ListenScreen = m_Root.Q(ListenScreen);
        m_ScreenListen = m_Root.Q(ScreenListen);
        m_Playing = m_Root.Q(Playing);
        m_PlayingText = m_Root.Q(PlayingText);
        m_PlayingText2 = m_Root.Q(PlayingText2);
        m_PlayButton = m_Root.Q<Button>(PlayButton);

        m_topbuttons[0] = m_LearnButton;
        m_topbuttons[1] = m_NoiseButton;
        m_topbuttons[2] = m_PrevButton;

        for (int i = 0; i < 8; i++)
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
            initplay();
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
    private void ClicklearnButton(ClickEvent evt)//�������� ���� 1
    {
        AudioManager.PlayDefaultButtonSound();
        m_MainMenuUIManager.ShowSoundNoiseScreen(); setBtEnable(0);
        m_NextButton.style.display = DisplayStyle.Flex;
        UpdatePageNavigation(m_MainMenuUIManager.menuindex, m_MainMenuUIManager.currentPageIndex);
        AudioManager.StopSound();
    }

    private void ClickNoiseButton(ClickEvent evt)//�����Ҹ� ü�� 2
    {
        AudioManager.PlayDefaultButtonSound();
        m_MainMenuUIManager.ShowTypeofNoiseScreen(); setBtEnable(1);
        m_NextButton.style.display = DisplayStyle.Flex;
        UpdatePageNavigation(m_MainMenuUIManager.menuindex, m_MainMenuUIManager.currentPageIndex);
        AudioManager.StopSound();
    }
    private void ClickPrevButton(ClickEvent evt)//���� 3
    {
        AudioManager.PlayDefaultButtonSound();
        m_MainMenuUIManager.ShowPreventionNoise(); setBtEnable(2);
        m_NextButton.style.display = DisplayStyle.Flex;
        UpdatePageNavigation(m_MainMenuUIManager.menuindex, m_MainMenuUIManager.currentPageIndex);
        AudioManager.StopSound();
    }


    private void ClickToStartButton(ClickEvent evt)//ó������ ��ư
    {
        AudioManager.PlayDefaultButtonSound();
        m_MainMenuUIManager.ShowtwoScreen();
        initplay();
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

    void initplay()
    {
        m_PlayButton.AddToClassList("ButtonPlay--pause");
        m_Playing.RemoveFromClassList("playing--pause");
        m_PlayingText.RemoveFromClassList("playingText--fade");
        m_PlayingText2.RemoveFromClassList("playingText--fade");
    }
}
