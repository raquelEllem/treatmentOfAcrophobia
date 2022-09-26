using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Bola : MonoBehaviour
{
    public Rigidbody rB;

    // Use this for initialization
    void Start()
    {
        rB = transform.GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        //acelera a 9 m/s para frente
        rB.velocity = transform.forward * 9;
    }
}





