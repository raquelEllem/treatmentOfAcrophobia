using UnityEngine;
using System.Collections;

public class PortaVarandaAp : MonoBehaviour {

    public GameObject PortaAp;
    public GameObject Usuario;
    public GameObject Portas;


    public float distancia;
    public bool abrir;
    public bool check;

    Animation animacaoAbrirPorta;

	// Use this for initialization
	void Start () {

        abrir = false;
        distancia = 0;
        

        animacaoAbrirPorta = PortaAp.GetComponent<Animation>();
        
	}
	
	// Update is called once per frame
	void Update () {

        if (!Usuario)
        {
            Usuario = GameObject.Find("FPSController");
        }

        else
        {
            // verifica a distancia entre o usuario e a porta
            distancia = Vector3.Distance(Usuario.transform.position, Portas.transform.position);

            if (distancia < 3)
            {
                check = true;
            }
            

            if (distancia < 3 && abrir == false)
            {
                animacaoAbrirPorta.Play("abrirPortaAp");
                abrir = true;
            }
        }     
    }
}
