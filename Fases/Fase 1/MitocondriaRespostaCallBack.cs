using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MitocondriaRespostaCallBack : DialogueCallBack
{
    public GameObject bolhao;
    public Fase fase;
    public GameObject atpPrefab;
    public int quantidadeAtp;
    private bool pegou = false;
    public int missaoAtual, proximaMissao;
    public override void CallBack()
    {
        if (!fase.GetMissao(missaoAtual).cumprida)
        {
            fase.GetMissao(missaoAtual).cumprida = true;
            fase.GetMissao(missaoAtual).ativada = false;
            fase.GetMissao(proximaMissao).ativada = true;
            fase.UpdateMissao();
            bolhao.transform.Find("d1").gameObject.SetActive(false);
            bolhao.transform.Find("d2").gameObject.SetActive(false);
            bolhao.transform.Find("d3").gameObject.SetActive(true);
        }
        if (!pegou && quantidadeAtp != 0)
        {
            for (int cont = 0; cont < quantidadeAtp; cont++)
            {
                Instantiate(atpPrefab, transform.position + new Vector3(-2, 0), Quaternion.identity);
                pegou = true;
            }
        }

    }
}
