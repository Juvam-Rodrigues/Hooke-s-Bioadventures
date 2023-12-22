using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Speech
{
    public const int HOOKE = 1;
    public const int NPC = 2;
    public int emissor;
    public string message;
}

public class Dialogue : MonoBehaviour
{
    public Sprite npc;
    private Sprite hooke;
    public Speech[] speechs;
    public string actorName;
    public float radious;
    private GameObject botaoDialogo, joystickTiro;
    private CircleCollider2D circleCollider2D;
    private DialogueControl dc;
    public bool falando = false;

    private void Start()
    {
        dc = FindObjectOfType<DialogueControl>();
        botaoDialogo = transform.Find("/Canvas/UIPanel/BotaoDialogo").gameObject;
        joystickTiro = transform.Find("/Canvas/UIPanel/JoystickTiro").gameObject;
        hooke = Resources.Load<Sprite>("Sprites/UI/CaixaDeTexto/HOOKE");
        circleCollider2D = gameObject.AddComponent<CircleCollider2D>();
        circleCollider2D.radius = 1 / transform.lossyScale.x * radious;
        circleCollider2D.isTrigger = true;
    }
    public void StartDialogue()
    {
        DialogueCallBack dialogueCall = GetComponent<DialogueCallBack>();
        if (dialogueCall != null)
        {
            dc.StartSpeech(speechs, actorName, npc, hooke, transform.Find("/Hooke - Player").gameObject, dialogueCall);
        }
        else
        {
            dc.StartSpeech(speechs, actorName, npc, hooke, transform.Find("/Hooke - Player").gameObject);
        }
        falando = true;
    }
    private void Action()
    {
        if (!dc.isSpeeching())
        {
            StartDialogue();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            botaoDialogo.GetComponent<Button>().onClick.AddListener(Action);
            botaoDialogo.SetActive(true);
            joystickTiro.SetActive(false);
            joystickTiro.GetComponent<Joystick>().OnPointerUp(null);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            falando = false;
            botaoDialogo.GetComponent<Button>().onClick.RemoveAllListeners();
            botaoDialogo.SetActive(false);
            joystickTiro.SetActive(true);
        }
    }
    private void OnDestroy()
    {
        if (botaoDialogo != null && joystickTiro != null)
        {
            botaoDialogo.SetActive(false);
            joystickTiro.SetActive(true);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radious);
    }
    public bool EstaFalando()
    {
        return falando;
    }
}
