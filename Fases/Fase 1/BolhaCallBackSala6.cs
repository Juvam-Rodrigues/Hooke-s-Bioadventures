using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolhaCallBackSala6 : BolhaCallBack
{
    public Fase fase;
    public GameObject ptialina;
    override public void CallBack()
    {
        if (!fase.GetMissao(12).ativada)
        {
            fase.GetMissao(11).cumprida = true;
            fase.GetMissao(11).ativada = false;
            ptialina.transform.Find("d2").gameObject.SetActive(false);
            ptialina.transform.Find("d3").gameObject.SetActive(true); 
            fase.GetMissao(12).ativada = true;
            fase.UpdateMissao();
            base.CallBack();
        }
    }
}
