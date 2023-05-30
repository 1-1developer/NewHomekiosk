using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class UImanager : MonoBehaviour
{
    [Header("Modal Menu Screens")]
    [Tooltip("Only one modal interface can appear on-screen at a time.")]
    [SerializeField] StartScreen m_HomeModalScreen;
    [SerializeField] TwoMenuScreen m_TwoModalScreen;
    [SerializeField] ScreenSoundNoise m_ScreenSoundNoise;
    [SerializeField] ScreenListen m_ScreenListen;
    [SerializeField] ScreenVideoSelect m_ScreenVideoSelect;

    UIDocument m_MainMenuDocument;
    public UIDocument MainMenuDocument => m_MainMenuDocument;

    List<MenuScreen> m_AllModalScreens = new List<MenuScreen>();

    void SetupModalScreens()
    {
        if (m_HomeModalScreen != null)
            m_AllModalScreens.Add(m_HomeModalScreen);
        if (m_TwoModalScreen != null)
            m_AllModalScreens.Add(m_TwoModalScreen);
        if (m_ScreenSoundNoise != null)
            m_AllModalScreens.Add(m_ScreenSoundNoise);
        if (m_ScreenListen != null)
            m_AllModalScreens.Add(m_ScreenListen);
        if (m_ScreenVideoSelect != null)
            m_AllModalScreens.Add(m_ScreenVideoSelect);
    }
    void ShowModalScreen(MenuScreen modalScreen)
    {
        foreach (MenuScreen m in m_AllModalScreens)
        {
            if (m == modalScreen)
            {
                m?.ShowScreen();
            }
            else
            {
                m?.HideScreen();
            }
        }
    }
    void OnEnable()
    {
        m_MainMenuDocument = GetComponent<UIDocument>();
        SetupModalScreens();
        ShowHomeScreen();
    }
    public void ShowHomeScreen()
    {
        ShowModalScreen(m_HomeModalScreen);
    }
    public void ShowtwoScreen()
    {
        ShowModalScreen(m_TwoModalScreen);
    }
    public void ShowSoundNoiseScreen()
    {
        ShowModalScreen(m_ScreenSoundNoise);
    }
    public void ShowListenScreen()
    {
        ShowModalScreen(m_ScreenListen);
    }
    public void ShowVideoScreen()
    {
        ShowModalScreen(m_ScreenVideoSelect);
    }
}
