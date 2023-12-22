using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoEnded : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public LevelLoader levelLoader;
    void Start()
    {
        videoPlayer.Play();
        videoPlayer.loopPointReached += NextScene;
    }

    // Update is called once per frame
    void NextScene(VideoPlayer vp)
    {
        levelLoader.LoadNextLevel();
    }
}
