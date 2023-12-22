using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCallBack : DialogueCallBack
{
    public GameObject texto, nextTutorial;
    public bool primeiroTutorial, nextDialogue;
    public override void CallBack()
    {
        if (primeiroTutorial)
        {
            Hooke.getInstance().AddNPC(8, texto);
        }
        gameObject.SetActive(false);
        transform.parent.gameObject.SetActive(false);
        if (nextDialogue)
        {
            nextTutorial.SetActive(true);
            nextTutorial.transform.parent.gameObject.SetActive(true);
            nextTutorial.GetComponent<Dialogue>().Invoke("StartDialogue", 0.2f);
        }
    }
}
