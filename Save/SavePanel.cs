using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SavePanel : MonoBehaviour
{
    public GameObject btnApagar, pnSaveVazio, pnSaveExiste;
    public TextMeshProUGUI text, textShadow;

    //Variáveis que aparecerão:
    public TextMeshProUGUI mundoAtual, faseAtual, qtdMoeda, qtdAtp, qtdPecas;

    void Start()
    {
        if (Hooke.getInstance().SaveGameExists()) {
            btnApagar.SetActive(true);
            textShadow.text = text.text = "CONTINUAR JOGO";
            pnSaveExiste.SetActive(true);
            pnSaveVazio.SetActive(false);
            
            //Variáveis que aparecerão:
            mundoAtual.text = (Hooke.getInstance().GetMundo()).ToString();
            faseAtual.text = (Hooke.getInstance().GetFase()).ToString();
            qtdMoeda.text = (Hooke.getInstance().moedas).ToString();
            qtdAtp.text = (Hooke.getInstance().atp).ToString();
            qtdPecas.text = (Hooke.getInstance().pecas).ToString();
        }
    }

    public void ApagarSave()
    {
        Hooke.getInstance().DeleteData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
