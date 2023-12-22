using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{
    private Entity entity;
    [Header("PlayerUI")]
    public Slider vida;
    public Slider escudo;
    public Slider municao;

    private GameController gcPlayer;
    public Item item;
    public RespawnManager respawn;
    private float contadorColor = 0f;
    public GameObject hudMoeda, hudPeca, hudATP, texto;
    public AudioSource collect, hit;

    void Start()
    {
        entity = new Entity();
        entity.codigo = 0;
        entity.nome = "Hooke";
        LoadSkills();
    }

    public void LoadSkills()
    {
        entity.vidaAtual = entity.vidaMaxima = Hooke.getInstance().vidaMaxima;
        entity.escudoAtual = entity.escudoMaximo = Hooke.getInstance().escudoMaximo;
        entity.velocidadeCarregamnentoEscudo = Hooke.getInstance().velocidadeCarregamnentoEscudo;
        entity.municaoAtual = entity.municaoMaxima = Hooke.getInstance().municaoMaxima;
        entity.velocidadeCarregamnentoMunicao = Hooke.getInstance().velocidadeCarregamnentoMunicao;

        gcPlayer = GameController.gc;
        gcPlayer.velocidadeCarregamentoMunicao.text = string.Format("{0:0.00}", 1 / entity.velocidadeCarregamnentoMunicao) + " s";

        gcPlayer.moedas = Hooke.getInstance().moedas;
        gcPlayer.moedaTxt.text = gcPlayer.moedas.ToString(); //Fazendo com o que o valor do texto se altere conforme pegue as moedas.
        gcPlayer.pecas = Hooke.getInstance().pecas;
        gcPlayer.pecasTxt.text = gcPlayer.pecas.ToString(); //Fazendo com o que o valor do texto se altere conforme pegue as moedas.
        gcPlayer.atp = Hooke.getInstance().atp;
        gcPlayer.atpTxt.text = gcPlayer.atp.ToString(); //Fazendo com o que o valor do texto se altere conforme pegue as moedas.

        vida.value = vida.maxValue = entity.vidaMaxima;
        gcPlayer.maxVida.text = vida.maxValue.ToString();

        escudo.value = escudo.maxValue = entity.escudoMaximo;
        gcPlayer.maxEscudo.text = escudo.maxValue.ToString();

        municao.maxValue = entity.municaoMaxima;
        municao.value = municao.maxValue;
    }
    private void Update()
    {
        vida.value = entity.vidaAtual;
        gcPlayer.atualVida.text = vida.value.ToString();
        escudo.value = entity.escudoAtual;
        gcPlayer.atualEscudo.text = ((int)escudo.value).ToString();
        municao.value = entity.municaoAtual;

        if (contadorColor > 0)
        {
            contadorColor += Time.deltaTime;
            if (contadorColor >= 0.2f)
            { //Determinando a velocidade de trocar de cor.
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                contadorColor = 0;
            }
        }

        if (entity.municaoAtual < entity.municaoMaxima)
        {
            entity.municaoAtual += Time.deltaTime * entity.velocidadeCarregamnentoMunicao;
        }
        if (entity.escudoAtual < entity.escudoMaximo)
        {
            entity.escudoAtual += Time.deltaTime * entity.velocidadeCarregamnentoEscudo;
        }
    }

    public Entity GetEntity()
    {
        return entity;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collect.time = 0.3f;
        if (collision.gameObject.tag.Equals("Moeda"))
        {
            hudMoeda.SetActive(true);
            collect.Play();
            Destroy(collision.gameObject);
            Hooke.getInstance().moedas++;
            gcPlayer.moedas++;
            gcPlayer.moedaTxt.text = gcPlayer.moedas.ToString(); //Fazendo com o que o valor do texto se altere conforme pegue as moedas.
            Hooke.getInstance().AddConquista(4, texto);
        }
        if (collision.gameObject.tag.Equals("Peca"))
        {
            hudPeca.SetActive(true);
            collect.Play();
            Destroy(collision.gameObject);
            Hooke.getInstance().pecas++;
            gcPlayer.pecas++;
            gcPlayer.pecasTxt.text = gcPlayer.pecas.ToString(); //Fazendo com o que o valor do texto se altere conforme pegue as moedas.
            Hooke.getInstance().AddConquista(3, texto);

        }
        if (collision.gameObject.tag.Equals("ATP"))
        {
            hudATP.SetActive(true);
            collect.Play();
            Destroy(collision.gameObject);
            Hooke.getInstance().atp++;
            gcPlayer.atp++;
            gcPlayer.atpTxt.text = gcPlayer.atp.ToString(); //Fazendo com o que o valor do texto se altere conforme pegue as moedas.
            Hooke.getInstance().AddConquista(2, texto);

        }

        if (collision.gameObject.tag.Equals("ItemDropavel"))
        {
            collect.Play();
            Destroy(collision.gameObject);
            Item item = collision.GetComponent<Item>(); // Tenta pegar o componente Item.
            if (item != null)
            {
                if (item.getPocaoCura() && entity.vidaAtual < entity.vidaMaxima)
                {
                    entity.vidaAtual = entity.vidaAtual + 1;
                }
                else if (item.getPocaoEscudo() && entity.escudoAtual < entity.escudoMaximo)
                {
                    entity.escudoAtual = entity.escudoAtual + 1;

                }
            }

        }

    }
    public void tomarDano(int dano)
    {
        hit.time = 1.1f;
        hit.Play();
        if (this.entity.escudoAtual > dano)
        {
            entity.escudoAtual = entity.escudoAtual - dano;
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            entity.vidaAtual = entity.vidaAtual - dano;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        contadorColor += Time.deltaTime;
        if (entity.vidaAtual == 0)
        {
            entity.dead = true;
            respawn.AbrirCanvasMorte();
        }
    }
    public bool estaMorto()
    {
        return entity.dead;
    }
}
