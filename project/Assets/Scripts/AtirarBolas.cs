using UnityEngine;
using System.Collections;

public class AtirarBolas : MonoBehaviour {

    public GameObject bola;
    public Transform saidaBola;

    public Ray raio;
    public RaycastHit ponto;
    public Camera cam;


	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {

        //pega o ponto do mouse na tela e transforma em raio
        raio = cam.ScreenPointToRay(Input.mousePosition);

        //verificar se a bola está colindo (em 1000 metros) com alguma coisa através do raycast
        //if (Physics.Raycast(raio, ponto, 1000))
        //{
        //    //pega o ponto de colisao
        //    transform.LookAt(ponto.point);
        //}

        //atira bola quando 'b' é clicado
        if (Input.GetKeyDown("b"))
        {
            Instantiate(bola, saidaBola.position, transform.rotation);
        }
        

	}
}
