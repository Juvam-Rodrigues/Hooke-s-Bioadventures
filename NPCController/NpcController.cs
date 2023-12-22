using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{

    [SerializeField]
    public Animator animator;
    [SerializeField]
    public bool BolhaParede;
    public bool conversando;
    public Dialogue dialogue;

  
    void Update()
    {
        this.conversando = dialogue.EstaFalando();

        if(conversando && BolhaParede){
            this.animator.SetBool("IsTalking", true);
        }
        else if(!conversando && BolhaParede){
            this.animator.SetBool("IsTalking", false);

        }else{
            this.animator.SetBool("isRunning", false);
        }
    }
    
}
