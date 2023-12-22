using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GerenciamentoMissoes : MonoBehaviour
{
    public GameObject botaoMissoes, retanguloMissoes;
    public TextMeshProUGUI missaoTxt; 
    private bool botao;
    void Start()
    {
        botao = false;
    }
    public void trocarBotoes(){
        if (botao)
        {
            botaoMissoes.SetActive(false);
            retanguloMissoes.SetActive(true);
            botao = false;
        }
        else
        {
            botaoMissoes.SetActive(true);
            retanguloMissoes.SetActive(false);
            botao = true;
        }
    }
    public void LoadMission(Missao missao)
    {
        if(missao != null){
            missaoTxt.text = missao.descricao;
        }
        else{
            missaoTxt.text = "Não há missões no momento.";
        }
    }
}
