using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PtialinaEndCallback : DialogueCallBack
{
    public VideoPlayer videoPlayer;
    public LevelLoader levelLoader;
    public AudioSource musica;
    public GameObject eventSystem;
    public override void CallBack()
    {
        eventSystem.SetActive(false);
        musica.Stop();
        videoPlayer.Play();
        videoPlayer.loopPointReached += BackToBegin;
    }

    void BackToBegin(VideoPlayer vp)
    {
        levelLoader.LoadSpecificLevel(0);
    }
}
