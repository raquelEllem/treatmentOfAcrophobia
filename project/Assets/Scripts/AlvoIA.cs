using UnityEngine;
using System.Collections;

public class AlvoIA : MonoBehaviour {

    public Transform Alvo;

    public Transform E1;
   // public Transform E2;
    public Transform Mira;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //se alvo estiver sem valor, procura o gameObject que tem o nome do ALVO
        if (!Alvo)
        {
            Alvo = GameObject.Find("alvo").transform;
        }

        MirarAlvo(E1, Mira);

	}

    void MirarAlvo (Transform Eixo1, Transform Mira) {

        Mira.LookAt(Alvo);
    }
}
