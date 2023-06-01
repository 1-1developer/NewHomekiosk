using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class StartScreen : MenuScreen
{
    const string StartSc= "Start";

    const string Startbt = "StartButton01";
    // Start is called before the first frame update

    Button m_StartButton;

    [SerializeField]
    InitTimer initTimer;
    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_StartButton = m_Root.Q<Button>(Startbt);
    }
    protected override void RegisterButtonCallbacks()
    {
        m_StartButton?.RegisterCallback<ClickEvent>(ClickStartButton);
    }

    private void ClickStartButton(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_MainMenuUIManager.ShowtwoScreen();
        initTimer.isStart = true;
        initTimer.timer = 0;
    }

}
