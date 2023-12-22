using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCallBackSala4e5 : DialogueCallBack
{
    public GameObject bolhao, texto;
    public Fase fase;
    public int missaoAtual, proximaMissao;
    public override void CallBack()
    {
        if (gameObject.name == "NPC - Solaire")
        {
            Hooke.getInstance().AddNPC(7, texto);
        }
        if (!fase.GetMissao(missaoAtual).cumprida && !bolhao.activeSelf)
        {

            bolhao.GetComponent<SpriteRenderer>().flipX = false;
            bolhao.SetActive(true);
            fase.GetMissao(missaoAtual).cumprida = true;
            fase.GetMissao(missaoAtual).ativada = false;
            fase.GetMissao(proximaMissao).ativada = true;
            fase.UpdateMissao();
            bolhao.transform.Find("d1").gameObject.SetActive(false);
            bolhao.transform.Find("d2").gameObject.SetActive(true);
        }


    }
}
