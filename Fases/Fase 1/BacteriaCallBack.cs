using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaCallBack : DialogueCallBack
{
    public Fase fase;
    public GameObject bolhao, texto;
    public override void CallBack()
    {
        if (!fase.GetMissao(1).cumprida) 
        {
            Hooke.getInstance().AddNPC(1, texto);
            fase.GetMissao(1).cumprida = true;
            fase.GetMissao(1).ativada = false;
            bolhao.transform.Find("d1").gameObject.SetActive(false);
            bolhao.transform.Find("d2").gameObject.SetActive(true); 
            fase.GetMissao(2).ativada = true;  
            fase.UpdateMissao();
        }
    }
}
