using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;


public class TwoMenuScreen : MenuScreen
{

    const string Typebt = "TypeButton01";
    const string Typebt2 = "TypeButton02";
    const string Typebt3 = "TypeButton03";
    const string NextButton = "NextButton";

    const string Touch = "Touch";
    // Start is called before the first frame update

    Button m_TypeButton;
    Button m_TypeButton02;
    Button m_TypeButton03;

    Button m_NextButton; // 다음버튼 유무 선택을 위해


    VisualElement m_touch;
    List<VisualElement> m_Gtouch = new List<VisualElement>();
    List<VisualElement> m_arrows = new List<VisualElement>();

    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        m_TypeButton = m_Root.Q<Button>(Typebt);
        m_TypeButton02 = m_Root.Q<Button>(Typebt2);
        m_TypeButton03 = m_Root.Q<Button>(Typebt3);
        m_NextButton = m_Root.Q<Button>(NextButton);

        for (int i = 0; i < 4; i++)
        {
            m_Gtouch.Add(m_Root.Q("g_touch" + $"{i}"));
        }
        for (int i = 0; i < 3; i++)
        {
            m_arrows.Add(m_Root.Q("arrow" + $"{i}"));
        }
        m_touch = m_Root.Q(Touch);
    }
    protected override void RegisterButtonCallbacks()
    {
        m_TypeButton?.RegisterCallback<ClickEvent>(ClickTypeButton);
        m_TypeButton02?.RegisterCallback<ClickEvent>(ClickTypeButton2);
        m_TypeButton03?.RegisterCallback<ClickEvent>(ClickTypeButton3);
    }
    private void ClickTypeButton(ClickEvent evt)
    {
        AnimationStart();
        AudioManager.PlayDefaultButtonSound();
        m_MainMenuUIManager.ShowSoundNoiseScreen();
        m_NextButton.style.display = DisplayStyle.Flex;

        m_MainMenuUIManager.ShowTopbar();
    }
    private void ClickTypeButton2(ClickEvent evt)
    {
        AnimationStart();
        AudioManager.PlayDefaultButtonSound();
        m_MainMenuUIManager.ShowTypeofNoiseScreen();
        m_NextButton.style.display = DisplayStyle.Flex;
        m_MainMenuUIManager.ShowTopbar();
    }

    private void ClickTypeButton3(ClickEvent evt)
    {
        AnimationStart();
        AudioManager.PlayDefaultButtonSound();
        m_MainMenuUIManager.ShowPreventionNoise();
        m_NextButton.style.display = DisplayStyle.None;

        m_MainMenuUIManager.ShowTopbar();
    }
    void AnimationTouch()
    {
        m_touch.ToggleInClassList("Touch--up");
        m_touch.RegisterCallback<TransitionEndEvent>(
            evt => m_touch.ToggleInClassList("Touch--up")
            );
    }
    //void AnimationArrow()
    //{
    //    m_arrow.ToggleInClassList("arrow--up");
    //    m_arrow.RegisterCallback<TransitionEndEvent>(
    //        evt => m_arrow.ToggleInClassList("arrow--up")
    //        );
    //}
    void AnimationGArrow()
    {
        m_arrows[0].ToggleInClassList("arrow--up");
        m_arrows[0].RegisterCallback<TransitionEndEvent>(
            evt => m_arrows[0].ToggleInClassList("arrow--up")
            );
        m_arrows[1].ToggleInClassList("arrow--up");
        m_arrows[1].RegisterCallback<TransitionEndEvent>(
            evt => m_arrows[1].ToggleInClassList("arrow--up")
            );
        m_arrows[2].ToggleInClassList("arrow--up");
        m_arrows[2].RegisterCallback<TransitionEndEvent>(
            evt => m_arrows[2].ToggleInClassList("arrow--up")
            );

    }
    void AnimationGTouch()
    {
        m_Gtouch[0].ToggleInClassList("Touch--up");
        m_Gtouch[0].RegisterCallback<TransitionEndEvent>(
            evt => m_Gtouch[0].ToggleInClassList("Touch--up")
            );
        m_Gtouch[1].ToggleInClassList("Touch--up");
        m_Gtouch[1].RegisterCallback<TransitionEndEvent>(
            evt => m_Gtouch[1].ToggleInClassList("Touch--up")
            );
        m_Gtouch[2].ToggleInClassList("Touch--up");
        m_Gtouch[2].RegisterCallback<TransitionEndEvent>(
            evt => m_Gtouch[2].ToggleInClassList("Touch--up")
            );
        m_Gtouch[3].ToggleInClassList("Touch--up");
        m_Gtouch[3].RegisterCallback<TransitionEndEvent>(
            evt => m_Gtouch[3].ToggleInClassList("Touch--up")
            );
    }
    void AnimationStart()
    {
        AnimationTouch();
        AnimationGTouch();
        AnimationGArrow();
    }
}
