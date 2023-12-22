using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolhaCallBackSala2 : BolhaCallBack
{
    public Fase fase;
    public GameObject texto;
    public override void CallBack()
    {
        if (!fase.GetMissao(3).ativada)
        {
            Hooke.getInstance().AddNPC(2, texto);
            fase.GetMissao(2).cumprida = true;
            fase.GetMissao(2).ativada = false;
            fase.GetMissao(3).ativada = true;
            fase.UpdateMissao();
            base.CallBack();
        }
    }
}
