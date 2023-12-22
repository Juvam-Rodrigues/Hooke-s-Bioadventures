using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skip : MonoBehaviour
{
    public GameObject seta;
    public LevelLoader levelLoader;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Show", 5f);
    }

    void Show()
    {
        seta.SetActive(true);
    }

    public void NextScene()
    {
        levelLoader.LoadNextLevel();
    }
}
