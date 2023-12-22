using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using TMPro;

[Serializable]
public class Hooke 
{
    private static Hooke instance;
    /* Atributos do personagem */
    public int vidaMaxima, dano;
    public float escudoMaximo, velocidadeCarregamnentoEscudo, municaoMaxima, velocidadeCarregamnentoMunicao;     

    /* Coletáveis */
    public int atp, moedas;
    public int pecas;

    /* Coisas do diário */
    public List<int> personagens, bestiario, conquistas;

    /* Fases */
    public int faseAtual;

    private Hooke()
    {
        vidaMaxima = 6;
        escudoMaximo = 6f;
        velocidadeCarregamnentoEscudo = 0.06f;
        municaoMaxima = 5;
        velocidadeCarregamnentoMunicao = 0.6f;
        dano = 1;

        atp = moedas = 0;
        pecas = 0;
        personagens = new List<int>();
        bestiario = new List<int>();
        conquistas = new List<int>();
        faseAtual = 0;
    }

    public static Hooke getInstance()
    {
        if (Hooke.instance != null)
        {
            return Hooke.instance;
        }
        return new Hooke();
    }

    public void AddBestiario(int codigo, GameObject texto) {
        bool achou = false;
        for (int i = 0; i < bestiario.Count; i++)
        {
            if (bestiario[i] == codigo) {
                achou = true;
                break;
            }
        }
        if (!achou) {
            bestiario.Add(codigo);
            texto.GetComponent<TextMeshProUGUI>().text = "Inimigo desbloqueado! Consulte o diário.";
            texto.SetActive(true);
        }
    }

    public void AddNPC(int codigo, GameObject texto)
    {
        bool achou = false;
        for (int i = 0; i < personagens.Count; i++)
        {
            if (personagens[i] == codigo) {
                achou = true;
                break;
            }
        }
        if (!achou) {
            personagens.Add(codigo);
            texto.GetComponent<TextMeshProUGUI>().text = "Personagem desbloqueado! Consulte o diário.";
            texto.SetActive(true);
        }
    }

    public void AddConquista(int codigo, GameObject texto)
    {
        bool achou = false;
        for (int i = 0; i < conquistas.Count; i++)
        {
            if (conquistas[i] == codigo) {
                achou = true;
                break;
            }
        }
        if (!achou) {
            conquistas.Add(codigo);
            texto.GetComponent<TextMeshProUGUI>().text = "Conquista desbloqueada! Consulte o diário.";
            texto.SetActive(true);
        }
    }

    public int GetMundo() {
        return (int) faseAtual / 5 + 1; //São cinco fases por mundo.
    }

    public int GetFase() {
        return faseAtual % 5 + 1;
    }

    public bool SaveGameExists()
    {
        return File.Exists(Application.persistentDataPath + "/save.game");
    }

    public void SaveData()
    {
        Hooke instance = Hooke.getInstance();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Create(Application.persistentDataPath + "/save.game");
        bf.Serialize(fs, instance);
        fs.Close();
    }

    public void LoadData()
    {
        if(!SaveGameExists()){
            return;
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Open(Application.persistentDataPath + "/save.game", FileMode.Open);
        instance = (Hooke) bf.Deserialize(fs);
        fs.Close();
    }

    public void DeleteData(){
        if(SaveGameExists()){
            BinaryFormatter bf = new BinaryFormatter();
            File.Delete(Application.persistentDataPath + "/save.game");
            instance = new Hooke();
        }
    }

}