using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]

public class Entity
{
    [Header("Dados Básicos")]
    public int codigo;
    public string nome;
    [Header("Vida")]
    public int vidaAtual;
    public int vidaMaxima;
     [Header("Escudo")]
    public float escudoAtual;
    public float escudoMaximo;
    public float velocidadeCarregamnentoEscudo;

     [Header("Municao")]
    public float municaoAtual;
    public float municaoMaxima;
    public float velocidadeCarregamnentoMunicao;

    [Header("Dano")]
    public int dano;     

    [Header("Combate")]
    public float attackTimer = 1;
    public float cooldown = 2f;
    public bool inCombat = false;
    public bool combatCourotine = false;
    public bool dead = false;

}
