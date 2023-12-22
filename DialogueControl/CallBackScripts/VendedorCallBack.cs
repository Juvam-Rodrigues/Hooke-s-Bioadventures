using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendedorCallBack : DialogueCallBack
{
    public GameObject pnVenda, texto;
    public Menu menu;
    override public void CallBack(){
        Hooke.getInstance().AddNPC(6, texto);
        menu.Enter(pnVenda);
    }
}
