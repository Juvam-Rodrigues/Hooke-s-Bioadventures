using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase : MonoBehaviour
{
    public List<Missao> missoes;
    public GerenciamentoMissoes gm;
    public int contInimigosDerrotados;
  
    public Missao GetMissao(int codigo){
        foreach(Missao m in missoes){
            if(m.codigo == codigo){
                return m;
            }
        }
        return null;
    }
    public Missao GetMissaoAtiva(){
        foreach(Missao m in missoes){
            if(m.ativada){
                return m;
            }
        }
        return null;
    }
    public void UpdateMissao(){
        gm.LoadMission(GetMissaoAtiva());
    }

}
