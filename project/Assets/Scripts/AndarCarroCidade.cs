using UnityEngine;
using System.Collections;

public class AndarCarroCidade : MonoBehaviour {

    public Transform Ponto1;
    public Transform Ponto2;
    public Transform Ponto3;

    bool parada1;
    public bool parada2;

    public GameObject Carro;
    UnityEngine.AI.NavMeshAgent AuxPosicaoNavMesh;
    Animation animacao;

    public Rigidbody rB;


    // Use this for initialization
    void Start()
    {
        rB = transform.GetComponent<Rigidbody>();

        AuxPosicaoNavMesh = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();

        animacao = Carro.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        // se clicar no 'c' carro anda
        if (Input.GetKeyDown("c"))
        {
            AuxPosicaoNavMesh.destination = Ponto1.position;
        }

        if (parada1 == true)
        {
            AuxPosicaoNavMesh.destination = Ponto2.position;
        }

        if (parada2 == true)
        {
            AuxPosicaoNavMesh.destination = Ponto3.position;
        }



    }

    void OnCollisionEnter(Collision colisao)
    {
        if (colisao.gameObject.tag == "parada1")
        {
            parada1 = true;
        }

        if (colisao.gameObject.tag == "parada2")
        {
            parada2 = true;
        }

    }
}