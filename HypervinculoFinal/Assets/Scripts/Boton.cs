using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour
{
    public Animator puerta1;
    public Animator puerta2;
    // Start is called before the first frame update
    void Start()
    {
        puerta1.SetBool ("abrir",false);
        puerta2.SetBool ("abrir",false);
    }

    void OnTriggerEnter(Collider other)
    {
        puerta1.SetBool ("abrir",true);
        puerta2.SetBool ("abrir",true);
    }
}
