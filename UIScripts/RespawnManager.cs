using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RespawnManager : MonoBehaviour
{
    public GameObject CanvasMorte; // Arraste o Canvas da seleção aqui
    public GameObject CanvasGame;
    public Player pl;
    public LevelLoader levelLoader;
    public void RespawnButton()
    {
        levelLoader.ReloadLevel();
    }

    public void NoRespawnButton()
    {
        Time.timeScale = 1;
        levelLoader.LoadSpecificLevel(0);
    }

    public void AbrirCanvasMorte()
    {
        if(pl.estaMorto()){
            CanvasMorte.SetActive(true);
            CanvasGame.SetActive(false);
        } 
    }
}
