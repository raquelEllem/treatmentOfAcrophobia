using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BolaFase2 : MonoBehaviour
{

    Collision colisao;

	public int acertos;

    public Rigidbody rB;

    public bool teste = false;


    // Use this for initialization
    void Start()
    {
		acertos = 0;
       
        rB = transform.GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        //acelera a 9 m/s para frente
        rB.velocity = transform.forward * 9;
    }

   // IEnumerator Acerto()
  //  {
        //fica vermelho e depois de 2 segundos é destruído
  //      GetComponent<MeshRenderer>().material.color = Color.blue;
  //      yield return new WaitForSeconds(2);
  //      Destroy(gameObject);
   // }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.ToString());
        if (col.gameObject.tag == "inimigo")
        {
            
            gameObject.GetComponent<Renderer>().materials[0].color = Color.blue;
            teste = true; 
            acertos++;
            if (acertos == 2)
            {
                SceneManager.LoadScene("fase3- Oficial", LoadSceneMode.Additive);
            }

        }
    }
}

