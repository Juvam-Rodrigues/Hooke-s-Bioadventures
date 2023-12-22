using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtiraScript : MonoBehaviour
{
    [SerializeField]
    private Transform pontoDeFogo;

    Vector2 joystickPosicao;
    Vector2 direcaoArma;

    [SerializeField]
    SpriteRenderer srGun;

    [SerializeField]
    float tempoEntreTiros;
    bool podeAtirar = true;
    float angle;
    public DialogueControl dc;

    [SerializeField]
    public GameObject tiro;

    [SerializeField]
    public Player player;
    public FixedJoystick joystickTiro;
    public AudioSource laser;

    void Update()
    {
        if (!player.GetEntity().dead)
        {
            joystickPosicao = new Vector2(joystickTiro.Horizontal, joystickTiro.Vertical); 
            if (!dc.isSpeeching())
            {
                if ((joystickTiro.Horizontal >= 0.6f || joystickTiro.Vertical >= 0.6f
                || joystickTiro.Horizontal <= -0.6f || joystickTiro.Vertical <= -0.6f)
                && podeAtirar && player.GetEntity().municaoAtual > 1)
                {
                    laser.Play();
                    podeAtirar = false;
                    Instantiate(tiro, pontoDeFogo.position, pontoDeFogo.rotation);
                    Invoke("CDTiro", tempoEntreTiros);
                    player.GetEntity().municaoAtual--;
                }
            }

        }

    }
    private void FixedUpdate()
    {
        angle = Mathf.Atan2(joystickPosicao.y, joystickPosicao.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle); //Rotaciona a arma para direcao do mouse.

        if (angle > -90 && angle < 90)
        {
            srGun.flipY = false;
        }
        else
        {
            srGun.flipY = true;
        }
    }
    void CDTiro()
    {
        podeAtirar = true;
    }
}
