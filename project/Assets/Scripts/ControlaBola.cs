using UnityEngine;
using System.Collections;

public class ControlaBola : MonoBehaviour
{
    public GameObject Bola;
    public int contador;
    public bool check;





    // Use this for initialization
    void Start()
    {

       

        check = false;

        contador = 0;

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnCollisionEnter(Collision colisao)
    {
        if (colisao.gameObject.tag == "bola")
        {
            //Destroy(gameObject);
            gameObject.GetComponent<Renderer>().materials[0].color = Color.blue;
            check = true;
        


            //se acertar 3 bolinhas no alvo chama a próxima cena
            if (contador == 3)
            {
                contador = contador + 1;
                //UnityEngine.SceneManagement.SceneManager.LoadScene("ponte-fase3");
            }
        }

    }
}
