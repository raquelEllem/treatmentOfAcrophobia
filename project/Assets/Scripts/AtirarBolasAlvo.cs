using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

[Serializable]
public class LaserOuMira
{
    public bool ativarLaser = false;
    public Color corLaser = Color.red;
    public bool AtivarMiraComum = true;
}

[Serializable]
public class Arma
{

    [HideInInspector]
    public int bolasExtra, bolas, acerto;
    public int danoPorTiro = 40;
    [Range(65, 500)]
    public int numeroDeBolas = 40;
    [Range(1, 50)]
    public int quantidadeDeBolas = 40;
    [Space(10)]
    public LaserOuMira Miras;
    [Space(10)]
    public GameObject objetoArma;
    public GameObject bola;
    public GameObject lugarBola;

    public AudioClip somTiro;

    public float tempoPorTiro = 0.01f;
}
[RequireComponent(typeof(AudioSource))]


public class AtirarBolasAlvo : MonoBehaviour {

    
    public int armaInicial = 0;
    public string TagInimigo = "inimigo";
    public Text Acertos, Tiros;
    public Material MaterialLasers;
    public Arma[] armas;
    //
    int armaAtual;
    AudioSource emissorSom;
    bool atirando;
    LineRenderer linhaDoLaser;
    GameObject luzColisao;
    public GameObject Bola;

    Collision colisao;

    public string nomeDaCenaAtual;
    
    void Start()
    {
        nomeDaCenaAtual = SceneManager.GetActiveScene().name;

        //laser das armas
        luzColisao = new GameObject();
        luzColisao.AddComponent<Light>();
        luzColisao.GetComponent<Light>().intensity = 8;
        luzColisao.GetComponent<Light>().bounceIntensity = 8;
        luzColisao.GetComponent<Light>().range = 0.2f;
        luzColisao.GetComponent<Light>().color = Color.red;
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = MaterialLasers;
        lineRenderer.SetColors(Color.white, Color.white);
        lineRenderer.SetWidth(0.015f, 0.05f);
        lineRenderer.SetVertexCount(2);
        linhaDoLaser = GetComponent<LineRenderer>();
        //
        for (int x = 0; x < armas.Length; x++)
        {
            armas[x].objetoArma.SetActive(false);
            armas[x].lugarBola.SetActive(false);
            armas[x].bolasExtra = armas[x].numeroDeBolas - armas[x].quantidadeDeBolas;
            //armas[x].bolas = armas[x].quantidadeDeBolas;
            armas[x].bolas = 0;
            armas[x].acerto = 0;
            armas[x].Miras.corLaser.a = 1;
        }
        if (armaInicial > armas.Length - 1)
        {
            armaInicial = armas.Length - 1;
        }
        armas[armaInicial].objetoArma.SetActive(true);
        armas[armaInicial].lugarBola.SetActive(true);
        armaAtual = armaInicial;
        emissorSom = GetComponent<AudioSource>();
        atirando = false;
    }

    void FixedUpdate()
    {
        //UI dmostra quantas vezes o usuário atirou
        Tiros.text = "Tiros: " + armas[armaAtual].bolas;
        Acertos.text = "Acertos: " + armas[armaAtual].acerto;
        //troca de armas
        if (Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")) > 0 && atirando == false)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                armaAtual++;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                armaAtual--;
            }
            if (armaAtual < 0)
            {
                armaAtual = armas.Length - 1;
            }
            if (armaAtual > armas.Length - 1)
            {
                armaAtual = 0;
            }
            AtivarArmaAtual();
        }
        //atirar
        //if (Input.GetKeyDown("b") && armas[armaAtual].bolas >= 0 && atirando == false)
        if (OVRInput.Get(OVRInput.Button.One) && armas[armaAtual].bolas >= 0 && atirando == false)
        {
            atirando = true;
            StartCoroutine(TempoTiro(armas[armaAtual].tempoPorTiro));
            emissorSom.clip = armas[armaAtual].somTiro;
            emissorSom.PlayOneShot(emissorSom.clip);
            armas[armaAtual].bolas++;
            Bola = Instantiate(armas[armaAtual].bola, armas[armaAtual].lugarBola.transform.position, transform.rotation) as GameObject;
            //destroi bolas depos de 10 segundos
            Destroy(Bola, 10);
            //
            RaycastHit pontoDeColisao;
            if (Physics.Raycast(transform.position, transform.forward, out pontoDeColisao))
            {
                if (pontoDeColisao.transform.gameObject.tag == TagInimigo)
                {
                    armas[armaAtual].acerto++;
                    //UI dmostra quantas vezes o usuário acertou o alvo
                    Acertos.text = "Acertos: " + armas[armaAtual].acerto;
                    Bola.GetComponent<Renderer>().materials[0].color = Color.blue;
                    if (armas[armaAtual].acerto == 3)
                    {
                        if (nomeDaCenaAtual == "fase2 - Oficial")
                        {
                            //espera 2 segundos para mudar para a fase 3
                            Invoke("MudarParaFase3", 2);
                        }

                        if (nomeDaCenaAtual == "fase3- Oficial")
                        {
                            //espera 2 segundos para mudar para a fase do Fim
                            Invoke("MudarParaFaseFim", 2);
                        }

                    }
                }
            }
        }
        
        //laser da arma
        if (armas[armaAtual].Miras.ativarLaser == true)
        {
            linhaDoLaser.enabled = true;
            linhaDoLaser.material.SetColor("_TintColor", armas[armaAtual].Miras.corLaser);
            luzColisao.SetActive(true);
            Vector3 PontoFinalDoLaser = transform.position + (transform.forward * 500);
            RaycastHit hitDoLaser;
            if (Physics.Raycast(transform.position, transform.forward, out hitDoLaser, 500))
            {
                linhaDoLaser.SetPosition(0, armas[armaAtual].lugarBola.transform.position);
                linhaDoLaser.SetPosition(1, hitDoLaser.point);
                float distancia = Vector3.Distance(transform.position, hitDoLaser.point) - 0.03f;
                luzColisao.transform.position = transform.position + transform.forward * distancia;
            }
            else
            {
                linhaDoLaser.SetPosition(0, armas[armaAtual].lugarBola.transform.position);
                linhaDoLaser.SetPosition(1, PontoFinalDoLaser);
                luzColisao.transform.position = PontoFinalDoLaser;
            }
        }
        else
        {
            linhaDoLaser.enabled = false;
            luzColisao.SetActive(false);
        }
        //checar limites da municao
        if (armas[armaAtual].bolas > armas[armaAtual].quantidadeDeBolas)
        {
            armas[armaAtual].bolas = armas[armaAtual].quantidadeDeBolas;
        }
        else if (armas[armaAtual].bolas < 0)
        {
            armas[armaAtual].bolas = 0;
        }
        int numBolasExtra = armas[armaAtual].numeroDeBolas - armas[armaAtual].quantidadeDeBolas;
        if (armas[armaAtual].bolasExtra > numBolasExtra)
        {
            armas[armaAtual].bolasExtra = numBolasExtra;
        }
        else if (armas[armaAtual].bolasExtra < 0)
        {
            armas[armaAtual].bolasExtra = 0;
        }
    }

    IEnumerator TempoTiro(float tempoDoTiro)
    {
        yield return new WaitForSeconds(tempoDoTiro);
        atirando = false;
    }

    //Método para mudança de fase - só é necessário pq usa o Invoke. 
    //Esse método Invoke serve para fazer esperar um tempo determinado antes de carregar outro método
    void MudarParaFase3()
    {
        SceneManager.LoadScene("fase3- Oficial");
    }

    void MudarParaFaseFim()
    {
        SceneManager.LoadScene("fim- Oficial");
    }

    void AtivarArmaAtual()
    {
        for (int x = 0; x < armas.Length; x++)
        {
            armas[x].objetoArma.SetActive(false);
            armas[x].lugarBola.SetActive(false);
        }
        armas[armaAtual].objetoArma.SetActive(true);
        armas[armaAtual].lugarBola.SetActive(true);
        if (armas[armaAtual].Miras.ativarLaser == true)
        {
            linhaDoLaser.material.color = armas[armaAtual].Miras.corLaser;
            linhaDoLaser.enabled = true;
            luzColisao.SetActive(true);
            luzColisao.GetComponent<Light>().color = armas[armaAtual].Miras.corLaser;
        }
        else
        {
            linhaDoLaser.enabled = false;
            luzColisao.SetActive(false);
        }
    }

    void OnGUI()
    {
        if (armas[armaAtual].Miras.AtivarMiraComum == true)
        {
            GUIStyle stylez = new GUIStyle();
            stylez.alignment = TextAnchor.MiddleCenter;
            GUI.skin.label.fontSize = 20;
            GUI.Label(new Rect(Screen.width / 2 - 6, Screen.height / 2 - 12, 12, 22), "+");
        }
    }
}
