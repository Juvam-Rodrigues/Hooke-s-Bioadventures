using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject pnUI;
    private int contador = 0;


    public void Enter(GameObject go){
        go.SetActive(true);
        contador++;
        if(contador==1){
            pnUI.SetActive(false);
            Time.timeScale = 0;
        }
    }
     public void Exit(GameObject go){
        go.SetActive(false);
        contador--;
        if(contador == 0){
            pnUI.SetActive(true);
            Time.timeScale = 1;
        }
    }

  
}

