using UnityEngine;
using System.Collections;

public class Alvo : MonoBehaviour
{

    public float vida = 100;
    bool acertarAlvo = false;

    void Update()
    {
        if (vida <= 0)
        {
            vida = 0;
            if (acertarAlvo == false)
            {
                acertarAlvo = true;
                StartCoroutine("Alvo");
            }
        }
    }

    IEnumerator Acerto()
    {
        //fica vermelho e depois de 2segundos é destruído
        GetComponent<MeshRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
