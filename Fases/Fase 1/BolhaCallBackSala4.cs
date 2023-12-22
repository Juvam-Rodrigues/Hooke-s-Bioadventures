using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolhaCallBackSala4 : BolhaCallBack
{
    public GameObject bolhaoSala5;
    public Fase fase;
    override public void CallBack()
    {
        if (!fase.GetMissao(8).ativada)
        {
            bolhaoSala5.SetActive(false);
            fase.GetMissao(7).cumprida = true;
            fase.GetMissao(7).ativada = false;
            fase.GetMissao(8).ativada = true;
            fase.UpdateMissao();
            base.CallBack();
        }
    }
}
