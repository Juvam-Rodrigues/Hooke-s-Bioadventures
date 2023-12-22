using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerConfiguracoes : MonoBehaviour
{
    public GameObject btnMusica, btnEfeitos;
    // Start is called before the first frame update
    void Start()
    {
        Carregar();
    }
    public void Carregar(){
        btnMusica.GetComponent<Toggle>().isOn = Preferencia.GetMusica() == 1;
        btnEfeitos.GetComponent<Toggle>().isOn = Preferencia.GetEfeitos() == 1;
    }
    public void TrocarEstadoMusica(){
        Preferencia.SetMusica(btnMusica.GetComponent<Toggle>().isOn ? 1 : 0);
        Preferencia.CarregarPreferencias();
    }
    public void TrocarEstadoEfeitos(){
        Preferencia.SetEfeitos(btnEfeitos.GetComponent<Toggle>().isOn ? 1: 0);
        Preferencia.CarregarPreferencias();
    }
    public void RedifinirConfig(){
        Preferencia.SetQualidade(0);
        Preferencia.SetMusica(1);
        Preferencia.SetEfeitos(1);
        Preferencia.CarregarPreferencias();
        Carregar();
    }

}
