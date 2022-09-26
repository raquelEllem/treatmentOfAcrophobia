using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ElevadorSobeTempo : MonoBehaviour
{

    // controla a velocidades do elevador
    public float VelocidadeAceleracao;
    public float VelocidadeAtual;
    public float VelocidadeDesaceleracao;
    public float VelocidadeMax;

    float aux;
    int contadorAndar;


    // controle
    public bool subir;
    public bool descer;
    public bool parar;

    public bool check;

    public GameObject Num0;
    public GameObject Num1;
    public GameObject Num2;
    public GameObject Num3;
    public GameObject Num4;
    public GameObject Num5;
    public GameObject Num6;
    public GameObject Num7;
    public GameObject Num8;
    public GameObject Num9;
    public GameObject Num10;
    public GameObject Num11;
    public GameObject Num12;
    public GameObject Num13;
    public GameObject Num14;
    public GameObject Num15;
    //public GameObject NumEsq6;
    //public GameObject NumEsq7;
    //public GameObject NumEsq8;
    //public GameObject NumEsq9;

    Collision colisao;


    // Use this for initialization
    void Start()
    {
        subir = false;
        parar = false;
        descer = false;

        contadorAndar = 0;

        // ANDARES
        Num0.GetComponent<Renderer>().materials[0].color = Color.clear;
        Num1.GetComponent<Renderer>().materials[0].color = Color.clear;
        Num2.GetComponent<Renderer>().materials[0].color = Color.clear;
        Num3.GetComponent<Renderer>().materials[0].color = Color.clear;
        Num4.GetComponent<Renderer>().materials[0].color = Color.clear;
        Num5.GetComponent<Renderer>().materials[0].color = Color.clear;
        Num6.GetComponent<Renderer>().materials[0].color = Color.clear;
        Num7.GetComponent<Renderer>().materials[0].color = Color.clear;
        Num8.GetComponent<Renderer>().materials[0].color = Color.clear;
        Num9.GetComponent<Renderer>().materials[0].color = Color.clear;
        Num10.GetComponent<Renderer>().materials[0].color = Color.clear;
        Num11.GetComponent<Renderer>().materials[0].color = Color.clear;
        Num12.GetComponent<Renderer>().materials[0].color = Color.clear;
        Num13.GetComponent<Renderer>().materials[0].color = Color.clear;
        Num14.GetComponent<Renderer>().materials[0].color = Color.clear;
        Num15.GetComponent<Renderer>().materials[0].color = Color.clear;
        //NumEsq6.GetComponent<Renderer>().materials[0].color = Color.clear;
        //NumEsq7.GetComponent<Renderer>().materials[0].color = Color.clear;
        //NumEsq8.GetComponent<Renderer>().materials[0].color = Color.clear;
        //NumEsq9.GetComponent<Renderer>().materials[0].color = Color.clear;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Se clicar no botão “B” do controle Rift ou "o" no teclado, o elevador sobe.   
        if (OVRInput.Get(OVRInput.Button.Two) || Input.GetKeyDown("o"))
        {
            subir = true;
            parar = false;
            descer = false;
        }

        // Se clicar no Thumbstick do controle Rift ou "p" no teclado, o elevador pausa a subida ou descida
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstick) || Input.GetKeyDown("p"))
        {
            parar = true;
            subir = false;
            descer = false;
        }

        // Se clicar no botão “A” do controle Rift ou "l" no teclado, o elevador desce.  
        if (OVRInput.Get(OVRInput.Button.One) || Input.GetKeyDown("l"))
        {
            descer = true;
            parar = false;
            subir = false;
        }

        //continua acelerando e subindo
        if (subir == true)
        {
            transform.Translate(0, VelocidadeAtual, 0);
            VelocidadeAtual = VelocidadeAtual + VelocidadeAceleracao / 10 * Time.deltaTime;
            parar = false;
        }
        
        //começa a descer
        if (descer == true)
        {
            VelocidadeAtual = VelocidadeAtual + VelocidadeAceleracao / 10 * Time.deltaTime;
            transform.Translate(0, -VelocidadeAtual, 0);
        }

        //começa a desacelerar e para
        if (parar == true)
        {
            VelocidadeAtual = VelocidadeAtual - VelocidadeDesaceleracao * Time.deltaTime;
            transform.Translate(0, 0, 0);
        }

        //limita a velocidade
        if (VelocidadeAtual > VelocidadeMax)
        {
            VelocidadeAtual = VelocidadeMax;
        }

        //não deixa descer
        if (VelocidadeAtual < 0)
        {
            VelocidadeAtual = 0;
        }

        // não passar do chão
        aux = transform.position.y;
        if (aux < 5.40)
        {
            parar = true;
            descer = false;
        }

        // não deixa subir muito - faz parar no 15° andar
        if (aux > 46.5)
        {
            parar = true;
            subir = false;
        }

        /******* POSIÇÃO DOS ANDARES - TOTAL: 15 andares **********/
        //terreo
        if (aux >= 5.8 && aux <= 8)
        {
            contadorAndar = 0;
        }
        
        //1º andar
        if (aux >= 8 && aux <= 10.6)
        {
            contadorAndar = 1;
        }

        //2º andar
        if (aux >= 10.6 && aux <= 13.2)
        {
            contadorAndar = 2;
        }

        //3º andar
        if (aux >= 13.2 && aux <= 15.8)
        {
            contadorAndar = 3;
        }

        //4º andar
        if (aux >= 15.8 && aux <= 18.4)
        {
            contadorAndar = 4;
        }

        //5º andar
        if (aux >= 18.4 && aux <= 21)
        {
            contadorAndar = 5;
        }

        //6º andar
        if (aux >= 21 && aux <= 23.6)
        {
            contadorAndar = 6;
        }

        //7º andar
        if (aux >= 23.6 && aux <= 26.2)
        {
            contadorAndar = 7;
        }

        //8º andar
        if (aux >= 26.2 && aux <= 28.8)
        {
            contadorAndar = 8;
        }
        
        //9º andar
        if (aux >= 28.8 && aux <= 31.4)
        {
            contadorAndar = 9;
        }

        //10º andar
        if (aux >= 31.4 && aux <= 34)
        {
            contadorAndar = 10;
        }

        //11º andar
        if (aux >= 34 && aux <= 36.6)
        {
            contadorAndar = 11;
        }

        //12º andar
        if (aux >= 36.6 && aux <= 39.2)
        {
            contadorAndar = 12;
        }

        //13º andar
        if (aux >= 39.2 && aux <= 41.8)
        {
            contadorAndar = 13;
        }

        //14º andar
        if (aux >= 41.8 && aux <= 44.4)
        {
            contadorAndar = 14;
        }

        //15º andar
        if (aux >= 44.4 && aux <= 47)
        {
            contadorAndar = 15;
            Invoke("MudarParaFase2", 10);
        }


        /****** LUZ ACENDE DE ACORDO COM O ANDAR ATUAL  ********************/
        switch (contadorAndar)
        {
            case 0:
                Num0.GetComponent<Renderer>().materials[0].color = Color.white;
                Num0.SetActive(true);

                Num1.SetActive(false);
                break;

            case 1:
                Num1.GetComponent<Renderer>().materials[0].color = Color.white;
                Num1.SetActive(true);
                               
                Num0.SetActive(false);
                Num2.SetActive(false);             
                break;

            case 2:
                Num2.GetComponent<Renderer>().materials[0].color = Color.white;
                Num2.SetActive(true);

                Num1.SetActive(false);
                Num3.SetActive(false);
                break;

            case 3:
                Num3.GetComponent<Renderer>().materials[0].color = Color.white;
                Num3.SetActive(true);

                Num2.SetActive(false);
                Num4.SetActive(false);
                break;

            case 4:
                Num4.GetComponent<Renderer>().materials[0].color = Color.white;
                Num4.SetActive(true);

                Num3.SetActive(false);
                Num5.SetActive(false);
                break;

            case 5:
                Num5.GetComponent<Renderer>().materials[0].color = Color.white;
                Num5.SetActive(true);

                Num4.SetActive(false);
                Num6.SetActive(false);
                break;

            case 6:
                Num6.GetComponent<Renderer>().materials[0].color = Color.white;
                Num6.SetActive(true);

                Num5.SetActive(false);
                Num7.SetActive(false);
                break;

            case 7:
                Num7.GetComponent<Renderer>().materials[0].color = Color.white;
                Num7.SetActive(true);

                Num6.SetActive(false);
                Num8.SetActive(false);
                break;

            case 8:
                Num8.GetComponent<Renderer>().materials[0].color = Color.white;
                Num8.SetActive(true);

                Num7.SetActive(false);
                Num9.SetActive(false);
                break;

            case 9:
                Num9.GetComponent<Renderer>().materials[0].color = Color.white;
                Num9.SetActive(true);

                Num8.SetActive(false);
                Num10.SetActive(false);
                break;

            case 10:
                Num10.GetComponent<Renderer>().materials[0].color = Color.white;
                Num10.SetActive(true);

                Num9.SetActive(false);
                Num11.SetActive(false);
                break;

            case 11:
                Num11.GetComponent<Renderer>().materials[0].color = Color.white;
                Num11.SetActive(true);

                Num10.SetActive(false);
                Num12.SetActive(false);
                break;

            case 12:
                Num12.GetComponent<Renderer>().materials[0].color = Color.white;
                Num12.SetActive(true);

                Num11.SetActive(false);
                Num13.SetActive(false);
                break;

            case 13:
                Num13.GetComponent<Renderer>().materials[0].color = Color.white;
                Num13.SetActive(true);

                Num12.SetActive(false);
                Num14.SetActive(false);
                break;

            case 14:
                Num14.GetComponent<Renderer>().materials[0].color = Color.white;
                Num14.SetActive(true);

                Num13.SetActive(false);
                Num15.SetActive(false);
                break;

            case 15:
                Num15.GetComponent<Renderer>().materials[0].color = Color.white;
                Num15.SetActive(true);

                Num14.SetActive(false);
                break;
        }
    }

    //Método para mudança de fase - só é necessário pq usa o Invoke. 
    //Esse método Invoke serve para fazer esperar um tempo determinado antes de carregar outro método
    void MudarParaFase2()
    {
        SceneManager.LoadScene("fase2 - Oficial");
    }



}
