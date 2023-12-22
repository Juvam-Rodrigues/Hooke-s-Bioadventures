using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolhaCallBackSala5 : BolhaCallBack
{
    public GameObject bolhaoSala6;
    public Fase fase;
    override public void CallBack()
    {
        if (!fase.GetMissao(11).ativada)
        {
            bolhaoSala6.SetActive(false);
            fase.GetMissao(10).cumprida = true;
            fase.GetMissao(10).ativada = false;
            fase.GetMissao(11).ativada = true;
            fase.UpdateMissao();
            base.CallBack();
        }
    }
}
