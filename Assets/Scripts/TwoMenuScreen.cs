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
    // Start is called before the first frame update
    VisualElement TwoSc;

    Button m_TypeButton;
    Button m_TypeButton02;
    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        TwoSc = m_Root.Q(twoSc);

        m_TypeButton = m_Root.Q<Button>(Typebt);
        m_TypeButton02 = m_Root.Q<Button>(Typebt2);
    }
    protected override void RegisterButtonCallbacks()
    {
        m_TypeButton?.RegisterCallback<ClickEvent>(ClickTypeButton);
        m_TypeButton02?.RegisterCallback<ClickEvent>(ClickStartButton2);
    }

    private void ClickTypeButton(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
    }
    private void ClickStartButton2(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
    }
}
