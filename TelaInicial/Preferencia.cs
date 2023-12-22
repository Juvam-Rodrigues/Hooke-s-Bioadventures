using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preferencia
{    
    
    public static int GetQualidade(){
        return  PlayerPrefs.HasKey("qualidade") ? PlayerPrefs.GetInt("qualidade") : 1;;
    }
    public static int GetMusica(){
        return PlayerPrefs.HasKey("musica") ? PlayerPrefs.GetInt("musica") : 1;;
    }
    public static int GetEfeitos(){
        return  PlayerPrefs.HasKey("efeitos") ? PlayerPrefs.GetInt("efeitos") : 1;;
    }
    public static void SetQualidade(int qualidade){
        PlayerPrefs.SetInt("qualidade", qualidade);
    }
    public static void SetMusica(int musica){
        PlayerPrefs.SetInt("musica", musica);
    }
    public static void SetEfeitos(int efeitos){
        PlayerPrefs.SetInt("efeitos", efeitos);
    }

    public static void CarregarPreferencias(){
        QualitySettings.SetQualityLevel(GetQualidade());
        if (QualitySettings.GetQualityLevel() != GetQualidade())
        {
            SetQualidade(QualitySettings.GetQualityLevel());
        }

        GameObject[] musicas = GameObject.FindGameObjectsWithTag("TagMusica");
        foreach (var musica in musicas)
        {
            musica.GetComponent<AudioSource>().volume = GetMusica();
        }
        GameObject[] efeitosSonoros = GameObject.FindGameObjectsWithTag("TagFX");
        foreach (var efeitosSonoro in efeitosSonoros)
        {
            efeitosSonoro.GetComponent<AudioSource>().volume = GetEfeitos();
        }
    }
}
