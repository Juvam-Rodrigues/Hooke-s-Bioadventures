using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NanoPlasticoCallback : DialogueCallBack
{
    public GameObject texto;
    public override void CallBack()
    {
        Hooke.getInstance().AddConquista(1, texto);
    }
}
