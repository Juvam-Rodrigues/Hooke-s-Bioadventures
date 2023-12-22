using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnerInimigo : MonoBehaviour
{
    public GameObject[] prefabsInimigos; // O prefab do inimigo que você deseja criar.
    public Transform pontoDeSpawn;  // O ponto de spawn dos inimigos.
    public bool jogadorEntrouCollider = false;
    public float tempoEntreOndas = 5f;
    public int inimigosPorOnda = 5;
    public int numeroMaximoOndas = 3; // Defina o número máximo de ondas aqui.
    private int ondaAtual = 0;
    public TextMeshProUGUI ondaAtualTxt;
    public GameObject bolhao, texto;
    public bool flipBolhao;
    private int inimigosRestantesNaOnda; // Variável para rastrear o número de inimigos restantes na onda atual.
    private Coroutine spawn = null;

    private void Update()
    {
        if (jogadorEntrouCollider && ondaAtual < numeroMaximoOndas && inimigosRestantesNaOnda == 0 && spawn == null)
        {
            spawn = StartCoroutine(SpawnOndas());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && bolhao != null && !bolhao.transform.Find("d2").gameObject.activeSelf
                && bolhao.transform.Find("d1").gameObject.activeSelf)
        {
            jogadorEntrouCollider = true;
            bolhao.GetComponent<SpriteRenderer>().flipX = flipBolhao;
            bolhao.SetActive(true);
            bolhao.transform.Find("d1").gameObject.SetActive(false);
            bolhao.transform.Find("d2").gameObject.SetActive(true);
        }
    }

    IEnumerator SpawnOndas()
    {
        yield return new WaitForSeconds(tempoEntreOndas);
        MostrarTxtOnda();

        // Defina o número de inimigos restantes para a quantidade total na onda.
        inimigosRestantesNaOnda = inimigosPorOnda;

        for (int i = 0; i < inimigosPorOnda; i++)
        {
            SpawnInimigo();
            yield return new WaitForSeconds(1f);
        }

        ondaAtual++;
    }

    void SpawnInimigo()
    {
        float numAleatorio = Random.value;
        int inimigoEscolhido = (int)((numAleatorio == 1f ? 0.99f : numAleatorio) * prefabsInimigos.Length); //Spawn aleatório de inimigo.
        GameObject enemy = Instantiate(prefabsInimigos[inimigoEscolhido], pontoDeSpawn.position, Quaternion.identity);
        enemy.GetComponent<Inimigo>().spawner = this;//Atribuição do spawner na classe Inimigo
        enemy.GetComponent<Inimigo>().texto = texto;//Atribuição do spawner na classe Inimigo
    }

    // No script do inimigo, chame este método quando o inimigo for derrotado.
    public void InimigoDerrotado()
    {
        // Diminua o número de inimigos restantes na onda atual.
        inimigosRestantesNaOnda--;
        if (inimigosRestantesNaOnda == 0)
        {
            spawn = null;
            if (ondaAtual == numeroMaximoOndas)
            {
                MostrarTxtOnda("Ondas derrotadas!");
                bolhao.transform.Find("d2").gameObject.SetActive(false);
                bolhao.transform.Find("d3").gameObject.SetActive(true);
            }
        }

    }

    public int getOndaAtual()
    {
        return ondaAtual;
    }

    private void MostrarTxtOnda()
    {
        ondaAtualTxt.text = "Onda atual: " + (getOndaAtual() + 1);
        ondaAtualTxt.gameObject.SetActive(true);
    }

    private void MostrarTxtOnda(string texto)
    {
        ondaAtualTxt.text = texto;
        ondaAtualTxt.gameObject.SetActive(true);
    }
}