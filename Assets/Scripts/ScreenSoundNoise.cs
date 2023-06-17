using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class ScreenSoundNoise : MenuScreen
{
    const string PlayingText2 = "playingText2";

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

    }
    protected override void RegisterButtonCallbacks()
    {

    }


}
