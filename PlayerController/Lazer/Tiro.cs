using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(Rigidbody2D))]
public class Tiro : MonoBehaviour
{
    [SerializeField]
    private float velocidade;

    [SerializeField]
    private float tempoDeVida;

    private int dano;
    public float multiplicadorDanoCritico = 2f; // Quantas vezes de dano iremos dar.
    public float chanceCritica = 0.2f; // Chance de 20% de um acerto crítico.
    private bool critou = false;

    [SerializeField]
    public GameObject explosaoDoTiro;

    [SerializeField]
    public TextMeshProUGUI danoTXT;

    [SerializeField]
    public GameObject danoCritico;

    void Start()
    {
        dano = Hooke.getInstance().dano;
        Destroy(gameObject, tempoDeVida);
    }

    private void FixedUpdate()
    {
        transform.Translate(transform.right * velocidade * Time.fixedDeltaTime, Space.World); //Move as balas.

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            var inimigoObj = collision.GetComponent<Inimigo>();
            GameObject explosao = Instantiate(explosaoDoTiro, inimigoObj.transform.position, inimigoObj.transform.rotation);
            Destruir(explosao, 0.5f);
            int danoTomado = calcularDano();
            inimigoObj.tomarDano(danoTomado, this.critou); //Aqui está dando dano no inimigo          

            TextMeshProUGUI danoTexto = Instantiate(danoTXT, inimigoObj.transform.position, inimigoObj.transform.rotation);
            danoTexto.text = "-" + danoTomado; // Define o texto do dano
            if (critou)
            {
                GameObject critico = Instantiate(danoCritico, inimigoObj.transform.position, inimigoObj.transform.rotation);
                Destruir(critico, 2f);
                Destruir(danoTexto.gameObject, 2.8f);
            }
            else
            {
                Destruir(danoTexto.gameObject, 1f);
            }
        }
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Zona" &&
        collision.gameObject.tag != "Zona" && collision.gameObject.tag != "Moeda" &&
        collision.gameObject.tag != "Peca" && collision.gameObject.tag != "ATP" && collision.gameObject.tag != "ItemDropavel")
        {
            Destroy(gameObject);
        }
    }

    private int calcularDano()
    {
        var inimigoObj = GetComponent<Inimigo>();
        float valorAleatorio = Random.value; // Gera um número aleatório entre 0 e 1
        if (valorAleatorio <= chanceCritica) // Verifica se o valorAleatorio é menor ou igual à chanceCritica
        {
            this.critou = true;
            return (Mathf.RoundToInt(dano * multiplicadorDanoCritico)); // Aplica o dano crítico, arredondando para o número inteiro mais próximo
        }
        this.critou = false;
        return dano;
    }

    private void Destruir(GameObject gb, float ft)
    {
        Destroy(gb, ft);
    }
    public bool Critou()
    {
        return this.critou;
    }
}


