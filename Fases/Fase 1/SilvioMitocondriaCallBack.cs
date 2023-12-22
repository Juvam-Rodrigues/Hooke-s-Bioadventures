using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilvioMitocondriaCallBack : DialogueCallBack
{
    public GameObject universitario1, universitario2, universitario3, bolhao, texto;
    public Fase fase;
    public int missaoAtual, proximaMissao;
    public override void CallBack()
    {
        Hooke.getInstance().AddNPC(5, texto);
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
        universitario1.transform.Find("d1").gameObject.SetActive(false);
        universitario1.transform.Find("d2").gameObject.SetActive(true);
        universitario2.transform.Find("d1").gameObject.SetActive(false);
        universitario2.transform.Find("d2").gameObject.SetActive(true);
        universitario3.transform.Find("d1").gameObject.SetActive(false);
        universitario3.transform.Find("d2").gameObject.SetActive(true);
    }
}
