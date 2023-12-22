using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class Inimigo : MonoBehaviour
{
    [Header("Controller")]
    public Entity entity;
    private float contador = 0f;
    private float contadorTiro = 0f;

    public GameObject tiroDoInimigo;
    public Transform localDoDisparo;

    [SerializeField]
    private float velocidadeMovimento;

    [SerializeField]
    private float distanciaMinima;

    [SerializeField]
    private SpriteRenderer sprite;

    [SerializeField]
    private Rigidbody2D rb2D;

    [Header("Respawn")]
    public GameObject prefab;
    public bool respawn = true;
    public float timeRespawn = 10f;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    public Player player;

    private float tempoAtualDosTiros;

    [SerializeField]
    public bool atirador;

    [SerializeField]
    private UIInimigo barraVida;

    [System.Serializable]
    public class DropItem
    {
        public GameObject itemPrefab;
        public float dropChance = 0.2f; //Chance de dropar
    }
    public DropItem[] dropItems;
    private float contadorColor = 0f;
    public SpawnerInimigo spawner;
    private static int qtdInimigosDerrotados = 0;
    [Header("Texto de Desbloqueio do Bestiário")]
    public GameObject texto;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<Player>();

        entity.vidaAtual = entity.vidaMaxima;
        entity.municaoAtual = entity.municaoMaxima;
        entity.escudoAtual = entity.escudoMaximo;

        this.barraVida.vidaMaxima = entity.vidaMaxima;
        this.barraVida.vida = entity.vidaAtual;

    }
    void Update()
    {
        Vector2 posicaoAlvo = player.transform.position;
        Vector2 posicaoAtual = this.transform.position;
        contador += Time.deltaTime;
        contadorTiro += Time.deltaTime;

        if (contadorColor > 0)
        {
            contadorColor += Time.deltaTime;
            if (contadorColor >= 0.4f)
            { //Determinando a velocidade de trocar de cor.
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                contadorColor = 0;
            }
        }

        float distancia = Vector2.Distance(posicaoAtual, posicaoAlvo);
        Vector2 direcao = posicaoAlvo - posicaoAtual;
        direcao = direcao.normalized; //valor entre menos 1 e mais 1;

        if (distancia >= this.distanciaMinima)
        {
            this.rb2D.velocity = (this.velocidadeMovimento * direcao);
            Correr();
        }
        else
        {
            if (distancia < this.distanciaMinima - 0.1f && atirador)
            { // rever depois
                this.rb2D.velocity = (this.velocidadeMovimento * -direcao);
                Correr();
            }
            else
            {
                Virar(direcao);
                this.rb2D.velocity = Vector2.zero;
                this.animator.SetBool("isRunning", false);
            }
            if (contador >= entity.cooldown && !player.GetEntity().dead)
            {
                this.animator.SetBool("attack", true);

                if (atirador)
                {
                    Atirar();
                }
                else
                {
                    Morder();
                }
            }
        }
    }
    public void tomarDano(int dano, bool critico)
    {
        if (critico)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        entity.vidaAtual -= dano;
        this.barraVida.vida = entity.vidaAtual;
        contadorColor += Time.deltaTime;
        if (entity.vidaAtual <= 0)
        {
            Hooke.getInstance().AddBestiario(entity.codigo, texto);
            Morrer();
        }
    }
    public void darDano(int dano)
    {
        player.GetEntity().vidaAtual -= dano;
    }
    private void Morrer()
    {
        foreach (DropItem dropItem in dropItems)
        {
            // Verifica se a probabilidade de drop foi alcançada.
            if (Random.value <= dropItem.dropChance)
            {
                // Cria uma instância do item no mesmo local do inimigo.
                Instantiate(dropItem.itemPrefab, transform.position, Quaternion.identity);
            }
        }
        spawner.InimigoDerrotado();
        qtdInimigosDerrotados++;
        Destroy(gameObject);
    }

    private void Correr()
    {
        if (this.rb2D.velocity.x > 0)
        {
            this.sprite.flipX = true; //direita
        }
        else if (this.rb2D.velocity.x < 0)
        {
            this.sprite.flipX = false; //esquerda
        }
        this.animator.SetBool("isRunning", true);
    }

    private void Virar(Vector2 direcao)
    {
        if (direcao.x > 0)
        {
            this.sprite.flipX = true; //direita
        }
        else if (direcao.x < 0)
        {
            this.sprite.flipX = false; //esquerda
        }
    }

    private void Morder()
    {
        player.tomarDano(this.entity.dano);
        contador = 0;
    }
    private void Atirar()
    {
        if (contadorTiro >= entity.cooldown)
        {
            Vector2 direcao = player.transform.position - transform.position;
            float angle = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
            localDoDisparo.rotation = Quaternion.Euler(0, 0, angle);
            Instantiate(tiroDoInimigo, localDoDisparo.position, localDoDisparo.rotation);
            contadorTiro = 0;
        }
        contador = 0;
    }
    public int GetQtdInimigosDerrotados(){
        return qtdInimigosDerrotados;
    }
    public void SetQtdInimigosDerrotados(int qtd){
        qtdInimigosDerrotados = qtd;
    }
    
    
}