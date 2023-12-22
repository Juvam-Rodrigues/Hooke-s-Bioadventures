using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroAcido : MonoBehaviour
{
   [SerializeField]
    private float velocidade;

    [SerializeField]
    private float tempoDeVida;

    [SerializeField]
    public int dano;
    void Start()
    {
        Destroy(gameObject, tempoDeVida);
    }
    private void FixedUpdate() {
        transform.Translate(transform.right * velocidade * Time.fixedDeltaTime, Space.World); //Move as balas.

    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag.Equals("Player")){
            var playerObj = collision.GetComponent<Player>();
            playerObj.tomarDano(dano);
        }
        if(collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Zona" &&
        collision.gameObject.tag != "Moeda" && collision.gameObject.tag != "Peca" &&
        collision.gameObject.tag != "ATP" && collision.gameObject.tag != "ItemDropavel"){
            Destroy(gameObject);
        }
    }
}
