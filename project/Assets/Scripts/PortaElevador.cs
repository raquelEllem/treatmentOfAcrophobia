using UnityEngine;
using System.Collections;

public class PortaElevador : MonoBehaviour {

    public GameObject PortaEsq;
    public GameObject PortaDir;

    public GameObject Usuario;
    public GameObject Portas;

    public float distancia;
   
    public bool abrir;
    public bool fechar;
    public bool aux;
    public bool aux2;

    Animation animacaoAbrirEsq;
    Animation animacaoAbrirDir;
    Animation animacaoFecharEsq;
    Animation animacaoFecharDir;


    public float tempo;

	// Use this for initialization
	void Start () {
        abrir = false;
        fechar = false;
        aux = false;
        aux2 = false;

        tempo = 0;

        animacaoAbrirEsq = PortaEsq.GetComponent<Animation>();
        animacaoAbrirDir = PortaDir.GetComponent<Animation>();
        animacaoFecharEsq = PortaEsq.GetComponent<Animation>();
        animacaoFecharDir = PortaDir.GetComponent<Animation>();

	}
	
	// Update is called once per frame
	void Update () {

        /***** ABRIR PORTA ****/
        if (!Usuario)
        {
            Usuario = GameObject.Find("FPSController");
            
        }
        else
        {
            // verifica a distancia entre o usuario e a porta
            distancia = Vector3.Distance(Usuario.transform.position, Portas.transform.position);
            if (distancia < 3 && aux == false)
            {
                abrir = true;
            } 
        }


        if (abrir == true && fechar == false)
        {
            animacaoAbrirEsq.Play("abrirEsq");
            animacaoAbrirDir.Play("abrirDir");
          
            aux = true;
            abrir = false;
            
        }


        /***** FECHAR PORTA ****/
        if (!Usuario)
        {
            Usuario = GameObject.Find("FPSController");
        }
        else
        {
            // verifica a distancia entre o usuario e a porta
            distancia = Vector3.Distance(Usuario.transform.position, Portas.transform.position);
            if (distancia < 1.6 && aux2 == false)
            {
                fechar  = true;
                tempo += Time.deltaTime;
            } 
        }

        // depois de entrar no elevador e passar 2 segundos a porta fecha
        if (fechar == true && abrir == false && tempo >= 2)
        {
            animacaoFecharEsq.Play("fecharEsq");
            animacaoFecharDir.Play("fecharDir");

            fechar = false;
            aux2 = true;

        }

 
    }

}
