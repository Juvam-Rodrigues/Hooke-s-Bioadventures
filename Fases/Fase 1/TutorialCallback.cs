using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCallback : DialogueCallBack
{
    public GameObject tutorial;
    public Fase fase;
    public override void CallBack()
    {
        fase.GetMissao(1).ativada = true;
        fase.UpdateMissao();
        tutorial.SetActive(true);
        tutorial.transform.parent.gameObject.SetActive(true);
        tutorial.GetComponent<Dialogue>().Invoke("StartDialogue", 0.2f);
        Destroy(gameObject);
    }
}
