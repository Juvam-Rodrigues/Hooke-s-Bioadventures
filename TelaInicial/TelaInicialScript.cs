using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TelaInicialScript : MonoBehaviour
{
    public TextMeshProUGUI btnJogar;
    public GameObject pnAperte, pnMenu, pnSaves;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((int) Time.time % 2 == 0)
        {
            btnJogar.color = new Color(255, 255, 255, 255);
        }
        else
        {
            btnJogar.color = new Color(255, 255, 255, 0);
        }
    }

    public void Jogar()
    {
        // Debug.Log("Iniciar o jogo!");
        // SceneManager.LoadScene("");
        pnAperte.SetActive(false);
        pnMenu.SetActive(true);
    }

    public void IniciarJogo()
    {
        pnSaves.SetActive(true);
        pnMenu.SetActive(false);
    }
    public void CriarJogo()
    {
        SceneManager.LoadScene("SelecaoFases");
    }
}
