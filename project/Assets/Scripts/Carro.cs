using UnityEngine;
using System.Collections;

public class Carro : MonoBehaviour {

    public float valorRotY;

    public Transform PontoCurvaEsquerda1;
    public Transform PontoCurvaEsquerda2;

    public bool curvaEsq;

    Animation animacaoCurvaEsq;
 

    // controla as velocidades 
    public float VelocidadeAtual;
    public float VelocidadeAceleracao;
    public float VelocidadeDesaceleracao;
    public float VelocidadeMax;
    float tempo;


    bool andar;

    // Use this for initialization
    void Start () {

        animacaoCurvaEsq = GetComponent<Animation>();
        andar = false;
	}
	
	// Update is called once per frame
	void Update () {

        //tempo += Time.deltaTime;

        //if (tempo > 5)
        //{
        //    andar = true;
        //}

        if (Input.GetKeyDown("v"))
        {
            andar = true;
        }

        if (andar == true)
        {
            VelocidadeAtual = VelocidadeAtual + VelocidadeAceleracao * Time.deltaTime;
            transform.Translate(VelocidadeAtual, 0, 0);
        }

        //evitar que o carro vá para tras a qualquer momento
        if (VelocidadeAtual < 0)
        {
            VelocidadeAtual = 0;
        }

        if (VelocidadeAtual >= VelocidadeMax)
        {
            VelocidadeAtual = VelocidadeMax;
        }

        // CurvaEsquerda(curvaEsq);
        if (curvaEsq == true)
        {
            //animacaoCurvaEsq.Play("curvaEsquerda");

        }
        

    }

    void OnCollisionEnter(Collision colisao)
    {
        if (colisao.gameObject.tag == "curvaEsq")
        {
            curvaEsq = true;
            
        }
    }

    void CurvaEsquerda(bool curvaEsquerda)
    {

        //if (curvaEsq == true)
        //{
        //    VelocidadeAtual = VelocidadeAtual + VelocidadeAceleracao * Time.deltaTime;
        //    transform.Rotate(0, -VelocidadeAtual * 3, 0);
        //    valorRotY = transform.rotation.y;
        //    if (valorRotY <= -0.7)
        //    {
        //        curvaEsq = false;
        //    }

        //}


    }
}
