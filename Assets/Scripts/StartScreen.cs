using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;



public class StartScreen : MenuScreen
{
    const string StartSc= "Start";
    const string StartSc2 = "Start_2";

    const string Startbt = "StartButton01";
    const string Startbt2 = "StartButton02";
    // Start is called before the first frame update
    VisualElement StartScreen01;
    VisualElement StartScreen02;

    Button m_StartButton;
    Button m_StartButton02;

    [SerializeField]
    InitTimer initTimer;
    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_StartButton = m_Root.Q<Button>(Startbt);
        m_StartButton02 = m_Root.Q <Button>(Startbt2);

        StartScreen01 = m_Root.Q(StartSc);
        StartScreen02 = m_Root.Q(StartSc2);
    }
    protected override void RegisterButtonCallbacks()
    {
        m_StartButton?.RegisterCallback<ClickEvent>(ClickStartButton);
        m_StartButton02?.RegisterCallback<ClickEvent>(ClickStartButton2);
    }

    private void ClickStartButton(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        StartScreen01.style.display = DisplayStyle.None;
        StartScreen02.style.display = DisplayStyle.Flex;
        initTimer.isStart = true;
        initTimer.timer = 0;
    }
    private void ClickStartButton2(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_MainMenuUIManager.ShowtwoScreen();
        StartScreen01.style.display = DisplayStyle.Flex;
        StartScreen02.style.display = DisplayStyle.None;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
