using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public struct ItemDiario
{
    public int codigo;
    public Sprite img;
    public string nome;
    public string descricao;
    public bool bloqueado;
}

public class Diario : MonoBehaviour
{
    public ItemDiario[] personagens; 
    public ItemDiario[] conquistas; 
    public ItemDiario[] bestiario;
    public GameObject pnConquistaSolo;
    
    //Painel de Status
    public TextMeshProUGUI atpAtualTxt, moedaAtualTxt, pecasAtualTxt, pecasMaximaTxt,
    vidaAtualTxt, vidaMaximaTxt, escudoAtualTxt, escudoMaximoTxt, velocidadeRecarregamentoMunicaoTxt;  
    public Player player; 
    public void OnEnable(){
        LoadPanel("NPCPanel", personagens, Hooke.getInstance().personagens, true);
        LoadPanel("InimigosPanel", bestiario, Hooke.getInstance().bestiario, true);
        LoadPanel("ConquistasPanel", conquistas, Hooke.getInstance().conquistas, false);
        // Painel status
        atpAtualTxt.text = Hooke.getInstance().atp + "";
        moedaAtualTxt.text = Hooke.getInstance().moedas + "";
        pecasAtualTxt.text = Hooke.getInstance().pecas + "";
        pecasMaximaTxt.text = 5.ToString();
        vidaAtualTxt.text = (int)(player.GetEntity().vidaAtual) + "";
        vidaMaximaTxt.text = Hooke.getInstance().vidaMaxima + "";
        escudoAtualTxt.text = (int)(player.GetEntity().escudoAtual) + "";
        escudoMaximoTxt.text = Hooke.getInstance().escudoMaximo + "";
        velocidadeRecarregamentoMunicaoTxt.text = string.Format("{0:0.00}", 1 / Hooke.getInstance().velocidadeCarregamnentoMunicao);         
    }
    private void LoadPanel(string panelDescription, ItemDiario[] lista, List<int> listaSave, bool autoGrow) {
        Sprite locked = Resources.Load<Sprite>("Sprites/UI/Cadeado");
        GameObject panel = transform.Find(panelDescription + "/Scroll View/Viewport/Content").gameObject;
        foreach(Transform child in panel.transform)
        {
            Destroy(child.gameObject);
        }
        float width = 0f;
        foreach (ItemDiario p in lista) {
            GameObject button = Instantiate(Resources.Load<GameObject>("Prefabs/UI/ButtonScrollView"), panel.transform);
            if (autoGrow)
            {
                width += button.GetComponent<RectTransform>().sizeDelta.x + 25;
                panel.GetComponent<RectTransform>().sizeDelta = new Vector2(width, 68f);
            }
            bool achou = false;
            foreach(int codigo in listaSave)
            {
                if (codigo == p.codigo)
                {
                    achou = true;
                    break;
                }
            }
            if (achou)
            {
                button.transform.Find("Image").GetComponent<Image>().sprite = p.img;
                button.GetComponent<Button>().onClick.AddListener(() => {
                    GameObject image = transform.Find(panelDescription + "/Foto/Image").gameObject; //Acessando esse caminho a partir do transform do objeto que está atrelado o script
                    image.GetComponent<Image>().sprite = p.img;
                    image.GetComponent<Image>().color = Color.white;
                    transform.Find(panelDescription + "/Foto/Descrição/Nome").gameObject.GetComponent<TextMeshProUGUI>().text = p.nome;
                    transform.Find(panelDescription + "/Sobre/Texto").gameObject.GetComponent<TextMeshProUGUI>().text = p.descricao;
                });
            }
            else
            {
                button.transform.Find("Image").GetComponent<Image>().sprite = locked;
                button.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0.5f);
            }
        }
    }
    public void trocarPanel(string nomePanel){
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("PaneisDiairio")){
            g.SetActive(false);
        }
        transform.Find(nomePanel).gameObject.SetActive(true);
    }
    public void ativarPanelConquistaSolo(string nomeConquista){
        pnConquistaSolo.SetActive(true);
    }
}
