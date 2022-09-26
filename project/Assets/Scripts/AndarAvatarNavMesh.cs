using UnityEngine;
using System.Collections;

public class AndarAvatarNavMesh : MonoBehaviour {

    public Transform Ponto;
    public GameObject Avatar;
    UnityEngine.AI.NavMeshAgent AuxPosicaoNavMesh;
    Animation animacao;

    Vector3 posicaoInicial;

    public bool check;


	// Use this for initialization
	void Start () {
        posicaoInicial = Avatar.transform.position;

        AuxPosicaoNavMesh = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();

        animacao = Avatar.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {

        AuxPosicaoNavMesh.destination = Ponto.position;

        //se o avatar estiver a 1 metro de distancia do ponto a animação para
        if(Vector3.Distance (Avatar.transform.position, Ponto.position) <= 1)
        {
            Avatar.transform.position = posicaoInicial;
        }
	}
}
