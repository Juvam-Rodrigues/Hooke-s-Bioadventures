using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolhaCallBack : DialogueCallBack
{
    public GameObject peca, bolhao;
    public Animator animator;
    override public void CallBack(){
        Instantiate(peca, transform.position, Quaternion.identity);
        animator.SetBool("IsDead", true);
        Destroy(bolhao, 2f);
    }
}
