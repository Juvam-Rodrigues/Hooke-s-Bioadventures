using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VendaScript : MonoBehaviour
{
    public int custoMoedas;
    public TextMeshProUGUI vida, escudo, municao;
    public Button vidaBtn, escudoBtn, municaoBtn;
    public Player player;
    public AudioSource musicBackground, musicTelaVendas;


    void OnEnable()
    {
        vida.text = escudo.text = municao.text = custoMoedas.ToString();
        LoadButtons();
        musicBackground.Pause();
        musicTelaVendas.Play();
    }
    void OnDisable(){
        musicBackground.Play();
        musicTelaVendas.Stop();
    }
    public void Melhorar(string tipoMelhoria)
    {
        if (Hooke.getInstance().moedas >= custoMoedas)
        {
            switch (tipoMelhoria)
            {
                case "Escudo":
                    Hooke.getInstance().escudoMaximo += 2;
                    break;
                case "Vida":
                    Hooke.getInstance().vidaMaxima += 2;
                    break;
                case "Municao":
                    Hooke.getInstance().velocidadeCarregamnentoMunicao += 0.1f;
                    break;
            }
            Hooke.getInstance().moedas -= custoMoedas;
            player.LoadSkills();
            //Tocar aúdio de confirmação
        }
        else
        {
            //Tocar aúdio de negação
        }
        LoadButtons();
    }

    private void LoadButtons()
    {
        if (Hooke.getInstance().moedas >= custoMoedas)
        {
            vidaBtn.interactable = true;
            escudoBtn.interactable = true;
            municaoBtn.interactable = true;
        }
        else
        {
            vidaBtn.interactable = false;
            escudoBtn.interactable = false;
            municaoBtn.interactable = false;
        }
    }
}
