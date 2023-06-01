using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class ScreenPrevention : MenuScreen
{

    const string VideoButton = "VideoButton";
    const string VideoScreen = "VideoScreen";
    const string BackButtonV = "BackButtonV";

    Button m_BackButtonV;
    Button[] m_VideoButtons = new Button[5];

    VisualElement m_videoScreen;
    [SerializeField]
    VideoManager videoManager;

    bool isprepared;
    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_videoScreen = m_Root.Q(VideoScreen);
        m_BackButtonV = m_Root.Q<Button>(BackButtonV);
        for (int i = 0; i < m_VideoButtons.Length; i++)
        {
            m_VideoButtons[i] = m_Root.Q<Button>(VideoButton + $"{i}");
        }

    }

    //private IEnumerator PlayVideoWhenReady()
    //{
    //    // 비디오 클립 준비 요청
    //    videoManager.PrepareClip(index);

    //    // 비디오 클립이 준비될 때까지 대기
    //    yield return new WaitUntil(() => videoManager.isPreparedClip());

    //    // 준비된 후 플레이
    //    videoManager.PlayVideo();
    //}

    protected override void RegisterButtonCallbacks()
    {
        m_BackButtonV?.RegisterCallback<ClickEvent>(ClickBackV);
        m_VideoButtons[0]?.RegisterCallback<ClickEvent>(evt => playVideo(0));
        m_VideoButtons[1]?.RegisterCallback<ClickEvent>(evt => playVideo(1));
        m_VideoButtons[2]?.RegisterCallback<ClickEvent>(evt => playVideo(2));
        m_VideoButtons[3]?.RegisterCallback<ClickEvent>(evt => playVideo(3));
        m_VideoButtons[4]?.RegisterCallback<ClickEvent>(evt => playVideo(4));
    }

    private void ClickBackV(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_videoScreen.style.display = DisplayStyle.None;
        videoManager.StopVideo();
        m_MainMenuUIManager.ShowTopbar();
    }
    private void playVideo(int index)
    {
        AudioManager.PlayDefaultButtonSound();
        videoManager.PrepareClip(index);
        videoManager.PlayVideo();
        m_MainMenuUIManager.HideTopbar();
        Invoke("onVideo", .1f);
    }
    private void onVideo()
    {
        m_videoScreen.style.display = DisplayStyle.Flex;
    }
}
