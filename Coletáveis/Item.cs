using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    public bool pocaoCura;
    public bool pocaoEscudo;
    public bool moeda;
    public bool atp;


    public bool getPocaoCura(){
        return pocaoCura;
    }
    public bool getPocaoEscudo(){
        return pocaoEscudo;
    }public bool getMoeda(){
        return moeda;
    }public bool getAttp(){
        return atp;
    }

}
