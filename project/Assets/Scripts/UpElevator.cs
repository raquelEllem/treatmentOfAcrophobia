using UnityEngine;
using System.Collections;

public class UpElevator : MonoBehaviour
{

    public bool subindo;
    public bool descendo;
    public bool parado;
    public bool um;
    public bool dois;
    public bool tres;
    public bool descUm;
    public bool descDois;
    public bool descTres;

    public Transform terreo;
    public Transform primeiroAndar;
    public Transform segundoAndar;
    public Transform terceiroAndar;

    public float speed;

    public GameObject botao;


    // com FixedUpdate não fica travando
    void FixedUpdate()
    {

        /***** DESCE ****/
        if (descendo == true)
        {
            // 1º andar
            if (descUm == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, terreo.transform.position, speed * Time.deltaTime);
            }

            // 2º andar
            if (descDois == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, primeiroAndar.transform.position, speed * Time.deltaTime);
            }

            // 3º andar
            if (descTres == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, segundoAndar.transform.position, speed * Time.deltaTime);
            }
        }


        /***** SOBE ****/
        if (subindo == true)
        {
            // 1º andar
            if (um == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, primeiroAndar.transform.position, speed * Time.deltaTime);
            }

            // 2º andar
            if (dois == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, segundoAndar.transform.position, speed * Time.deltaTime);
            }

            // 3º andar
            if (tres == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, terceiroAndar.transform.position, speed * Time.deltaTime);
            }
        }
       
        
        /***** CONTROLA BOTÃO *****/
        // se o elevador estiver parado o botão fica vermelho
        if (transform.position == terreo.transform.position || transform.position == primeiroAndar.transform.position || transform.position == segundoAndar.transform.position || transform.position == terceiroAndar.transform.position)
        {
            botao.GetComponent<Renderer>().materials[0].color = Color.red;
            parado = true;
            subindo = false;
            descendo = false;

        }
        else
        // se o elevador estiver subindo/descendo o botão fica verde
        {
            botao.GetComponent<Renderer>().materials[0].color = Color.green;
            parado = false;
        }


        /***** TECLAS CLICADAS *****/
        if (parado == true)
        {
            // se a tecla 'u' for apertada o elevador SOBE
            if (Input.GetKeyDown("u"))
            {
                subindo = true;
                descendo = false;

                descUm = false;
                descDois = false;
                descTres = false;

                // 1° andar
                if (transform.position == terreo.transform.position)
                {
                    um = true;
                    dois = false;
                    tres = false;
                }

                // 2° andar
                if (transform.position == primeiroAndar.transform.position)
                {                    
                    um = false;
                    dois = true;
                    tres = false;
                }

                // 3° andar
                if (transform.position == segundoAndar.transform.position)
                {
                    um = false;
                    dois = false;
                    tres = true;
                }
            }

            // se a tecla 'j' for apertada o elevador DESCE
            if (Input.GetKeyDown("j"))
            {
                subindo = false;
                descendo = true;

                um = false;
                dois = false;
                tres = false;

                // 1° andar
                if (transform.position == primeiroAndar.transform.position)
                {
                    descUm = true;
                    descDois = false;
                    descTres = false;
                }

                // 2° andar
                if (transform.position == segundoAndar.transform.position)
                {
                    descUm = false;
                    descDois = true;
                    descTres = false;
                }

                // 3° andar
                if (transform.position == terceiroAndar.transform.position)
                {
                    descUm = false;
                    descDois = false;
                    descTres = true;
                }

            }//fim da tecla

        }//fim parado


    }
}


