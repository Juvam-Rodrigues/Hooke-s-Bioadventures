using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavaleiroEnzimaCallback : DialogueCallBack
{
    public GameObject texto;
    public override void CallBack()
    {
        Hooke.getInstance().AddNPC(3, texto);
    }
}
