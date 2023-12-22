using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MudarMundos : MonoBehaviour
{
    public GameObject pnMundo1, pnMundo2, pnMundo3, nomeMundo1, nomeMundo2, nomeMundo3;
    // public GameObject nomeMundo3;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TrocarParaMundo3(){
        DesativarPaineis(pnMundo1, nomeMundo1);
        DesativarPaineis(pnMundo2, nomeMundo2);
        AtivarPaineis(pnMundo3, nomeMundo3);
    }
    public void TrocarParaMundo2()
    {
        DesativarPaineis(pnMundo1, nomeMundo1);
        AtivarPaineis(pnMundo2, nomeMundo2);
        DesativarPaineis(pnMundo3, nomeMundo3);
    }
    public void TrocarParaMundo1()
    {
        AtivarPaineis(pnMundo1, nomeMundo1);
        DesativarPaineis(pnMundo2, nomeMundo2);
        DesativarPaineis(pnMundo3, nomeMundo3);
    }

    private void AtivarPaineis(params GameObject[] paineis) {
        foreach (var painel in paineis)
        {
            painel.SetActive(true);
        }
    }
    private void DesativarPaineis(params GameObject[] paineis) {
        foreach (var painel in paineis)
        {
            painel.SetActive(false);
        }
    }
}