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
    [SerializeField] ScreenTypeofNoise m_ScreenTypeofNoise;
    [SerializeField] ScreenPrevention m_ScreenPreventionNoise;
    [SerializeField] ScreenListen m_ScreenListen;
    [SerializeField] TopButtons m_TopButtons;

    UIDocument m_MainMenuDocument;
    public UIDocument MainMenuDocument => m_MainMenuDocument;

    List<MenuScreen> m_AllModalScreens = new List<MenuScreen>();

    public int currentPageIndex = 0; // typeofnoise 그룹의 페이지 인덱스

    public int menuindex;
    public int pre_menuindex;
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
        if (m_ScreenTypeofNoise != null)
            m_AllModalScreens.Add(m_ScreenTypeofNoise);
        if (m_ScreenPreventionNoise != null)
            m_AllModalScreens.Add(m_ScreenPreventionNoise);
    }
    void ShowModalScreen(MenuScreen modalScreen)
    {
        resetIndex();
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
    void resetIndex()
    {
        currentPageIndex = 0;
    }
    void OnEnable()
    {
        m_MainMenuDocument = GetComponent<UIDocument>();
        SetupModalScreens();
        ShowHomeScreen();
        HideTopbar();
    }
    public void ShowHomeScreen()
    {
        ShowModalScreen(m_HomeModalScreen);
    }
    public void ShowtwoScreen()
    {
        ShowModalScreen(m_TwoModalScreen);
        setTop();
    }
    public void ShowSoundNoiseScreen()
    {
        menuindex = 0;
        m_TopButtons.setBtEnable(0);
        ShowModalScreen(m_ScreenSoundNoise);
    }
    public void ShowTypeofNoiseScreen()
    {
        menuindex = 1;
        m_TopButtons.setBtEnable(1);
        ShowModalScreen(m_ScreenTypeofNoise);
    }
    public void ShowPreventionNoise()
    {
        menuindex = 2;
        m_TopButtons.setBtEnable(2);
        ShowModalScreen(m_ScreenPreventionNoise);
    }
    public void ShowListenScreen()
    {
        pre_menuindex = menuindex;
        menuindex = 3;
        setTop();
        ShowModalScreen(m_ScreenListen);
    }
    public void ShowTopbar()
    {
        m_TopButtons.ShowScreen();
    }
    public void HideTopbar()
    {
        m_TopButtons.HideScreen();
    }
    public void setTop()
    {
        m_TopButtons.setBtall();
    }
}
