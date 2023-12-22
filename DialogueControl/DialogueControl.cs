using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueControl : MonoBehaviour
{
    [Header("Componentes")]
    public GameObject dialogueObj;
    public Image profile;
    public TextMeshProUGUI speechText;
    public TextMeshProUGUI actorNameText;

    [Header("Settings")]
    public float typingSpeed; //Velocidade do texto aparecer.
    private Speech[] speechs;
    private Sprite npc, hooke;
    private GameObject hookeObject;
    private string actorName;
    private int index = 0;
    private bool speeching = false;
    private Coroutine c;
    private DialogueCallBack dialogueCallBack;

    public void StartSpeech(Speech[] speechs, string actorName, Sprite npc, Sprite hooke, GameObject hookeObject){
        dialogueObj.SetActive(true);
        this.speeching = true;
        this.speechs = speechs;
        this.actorName = actorName;
        this.npc = npc;
        this.hooke = hooke;
        this.hookeObject = hookeObject;
        this.hookeObject.GetComponent<PlayerController>().isTalking = true;
        c = StartCoroutine(TypeSentence());
    }
    public void StartSpeech(Speech[] speechs, string actorName, Sprite npc, Sprite hooke, GameObject hookeObject, DialogueCallBack dialogueCallBack){
        dialogueObj.SetActive(true);
        this.speeching = true;
        this.speechs = speechs;
        this.actorName = actorName;
        this.npc = npc;
        this.hooke = hooke;
        this.hookeObject = hookeObject;
        this.hookeObject.GetComponent<PlayerController>().isTalking = true;

        this.dialogueCallBack = dialogueCallBack;
        c = StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence(){
        if (speechs[index].emissor == Speech.HOOKE){
            profile.sprite = hooke;
            actorNameText.text = "Hooke";
        }else{
            profile.sprite = npc;
            actorNameText.text = actorName;
        }
        foreach(char letter in speechs[index].message.ToCharArray()){
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence(){
        if(speechText.text == speechs[index].message){
            if(index < speechs.Length - 1){ //Verificando se ainda há texto no array.
                speechText.text = "";
                index++;
                c = StartCoroutine(TypeSentence()); //Chamando o próximo texto.
            } else{ //Acabou textos.
                Exit();
            }
        }
    }

    public void Exit()
    {
        speechText.text = "";
        index = 0;
        dialogueObj.SetActive(false);
        speeching = false;
        if(dialogueCallBack != null){
            dialogueCallBack.CallBack();
            dialogueCallBack = null;
        }
        this.hookeObject.GetComponent<PlayerController>().isTalking = false;
        StopCoroutine(c);
    }

    public bool isSpeeching(){
        return speeching;
    }
}
