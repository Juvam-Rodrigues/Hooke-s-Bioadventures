using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameController : MonoBehaviour
{
    public static GameController gc;
    public TextMeshProUGUI moedaTxt, pecasTxt, atpTxt;
    
    public TextMeshProUGUI maxVida;
    public TextMeshProUGUI atualVida;
    public TextMeshProUGUI maxEscudo;
    public TextMeshProUGUI atualEscudo;
    public TextMeshProUGUI velocidadeCarregamentoMunicao;
    
    public int moedas, pecas, atp;
   
    void Awake() {
        if(gc == null){
            gc = this;
        }
        else if(gc != this){
            Destroy(gameObject);
        }
    }    
}
