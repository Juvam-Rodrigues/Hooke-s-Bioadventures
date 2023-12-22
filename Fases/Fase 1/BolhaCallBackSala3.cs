using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolhaCallBackSala3 : BolhaCallBack
{
    public GameObject bolhaoSala4;
    public Fase fase;
    override public void CallBack()
    {
        if (!fase.GetMissao(5).ativada)
        {
            bolhaoSala4.SetActive(false);
            fase.GetMissao(4).cumprida = true;
            fase.GetMissao(4).ativada = false;
            fase.GetMissao(5).ativada = true;
            fase.UpdateMissao();
            base.CallBack();
        }
    }
}
