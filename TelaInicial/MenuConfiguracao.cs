using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuConfiguracao : MonoBehaviour
{
 
    public GameObject pnMenu, pnConfiguracoes,pnSaves;

    public void Menu(){
        pnMenu.SetActive(true);
        pnConfiguracoes.SetActive(false);
        pnSaves.SetActive(false);
    }
    public void Config() 
    {
        pnMenu.SetActive(false);
        pnConfiguracoes.SetActive(true);

    }
    public void Saves(){
        pnMenu.SetActive(true);
        pnSaves.SetActive(false);
    }
}
