using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime;

    public void LoadSpecificLevel(int index)
    {
        StartCoroutine(LoadLevel(index));
    }
    public void LoadBackLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void ReloadLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }
    IEnumerator LoadLevel(int levelIndex)
    {

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex, LoadSceneMode.Single);
    }

}
