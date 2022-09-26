using UnityEngine;
using System.Collections;

public class BolaFase3 : MonoBehaviour {


    dadosBola DadosBola;

    Collision colisao;
    public bool colBola;
    public float dist;

    float posX; // posição do texto
    float posY; // posição do texto

    float alturaTexto; // altura do botão
    float larguraTexto; // largura do botão

    public Rigidbody rB;
    public int aux;
    public bool check;


    // Use this for initialization
    void Start()
    {

        alturaTexto = 30;
        larguraTexto = 100;

        posX = Screen.width - (larguraTexto) - 5; // Screen.width = largura do monitor
        posY = Screen.height / 2 - Screen.height / 2 + alturaTexto / 2; // Screen.height = altura do monitor

        DadosBola = GetComponent<dadosBola>();

        colBola = false;


        aux = 0;

        rB = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //acelera a 9 m/s para frente
        rB.velocity = transform.forward * 9;

        //destroi bolas que não colidem com nada depois de 2 segundos
        Destroy(gameObject, 5);

        //se tiver qualquer coisa a 1 metro a frente do centro da bola (raycast)
        // a bola é destruida
        //if (Physics.Raycast(transform.position, transform.forward, 1))
        //{
        //    Destroy(gameObject);
        //}

        //if (colBola == true && Vector3.Distance(transform.position, colisao.gameObject.transform.position) <= 1)
        //{
        //    DadosBola.acertos++;
        //}
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.ToString());

        //destroi bolas que colidem com alguma coisa
        //Destroy(gameObject);

        if (col.gameObject.tag == "alvo")
        {
            colBola = true;
            colisao = col;
            //Destroy(gameObject);
            gameObject.GetComponent<Renderer>().materials[0].color = Color.blue;
            DadosBola.acertos++;

            if (DadosBola.acertos >= 3)
            {
             //   UnityEngine.SceneManagement.SceneManager.LoadScene("fim- Oficial");
            }

            //check = true;
            //aux = aux + 1; 

            ////se acertar 3 bolinhas no alvo chama a próxima cena
            //if (aux == 3)
            //{
            //    UnityEngine.SceneManagement.SceneManager.LoadScene("fase3- Oficial"); 
            //}
        }

    }


    /********************************/
    /* Dados na Tela                */
    /********************************/

    void OnGUI()
    {
        //escreve na tela os acertos
        GUI.Box(new Rect(posX, posY, larguraTexto, alturaTexto), "Acertos: " + DadosBola.acertos);

    }
}

