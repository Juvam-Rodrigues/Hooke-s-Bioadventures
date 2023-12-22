using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PtialinaCallBack : DialogueCallBack
{
    public GameObject bolhaoSala3, ptialina, texto;
    public Fase fase;
    override public void CallBack()
    {
        if (!fase.GetMissao(4).ativada)
        {
            Hooke.getInstance().AddNPC(4, texto);
            bolhaoSala3.SetActive(false);
            fase.GetMissao(3).cumprida = true;
            fase.GetMissao(3).ativada = false;
            fase.GetMissao(4).ativada = true;
            fase.UpdateMissao();
            ptialina.transform.Find("d1").gameObject.SetActive(false);
            ptialina.transform.Find("d2").gameObject.SetActive(true);
        }
    }
}
