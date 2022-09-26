using UnityEngine;
using System.Collections;

public class AndarCarroPonte : MonoBehaviour
{

    public Transform Ponto;
    public GameObject Carro;
    UnityEngine.AI.NavMeshAgent AuxPosicaoNavMesh;
    Animation animacao;

    Vector3 posicaoInicial;

    public bool check;


    // Use this for initialization
    void Start()
    {
        posicaoInicial = Carro.transform.position;

        AuxPosicaoNavMesh = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();

        animacao = Carro.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        AuxPosicaoNavMesh.destination = Ponto.position;

        //se o carro estiver a 1 metro de distacia do ponto
        if (Vector3.Distance(Carro.transform.position, Ponto.position) <= 1)
        {
            Carro.transform.position = posicaoInicial;

        }
    }
}
